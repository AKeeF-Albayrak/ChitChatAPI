using ChitChatAPI.Aplication.Abstractions.Repositories;
using ChitChatAPI.Aplication.Abstractions.Services;
using ChitChatAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Aplication.Features.Command.User.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private IUserReadRepository _userReadRepository;
        private IRefreshTokenWriteRepository _refreshTokenWriteRepository;
        private IRefreshTokenReadRepository _refreshTokenReadRepository;
        private ITokenService _tokenService;
        public LoginUserCommandHandler(IUserReadRepository userReadRepository, IRefreshTokenWriteRepository refreshTokenWriteRepository, ITokenService tokenService, IRefreshTokenReadRepository refreshTokenReadRepository)
        {
            _userReadRepository = userReadRepository;
            _refreshTokenWriteRepository = refreshTokenWriteRepository;
            _tokenService = tokenService;
            _refreshTokenReadRepository = refreshTokenReadRepository;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userReadRepository.CheckLoginCredentials(request.UsernameOrEmail, request.Password);
            if (user == null)
            {
                return new LoginUserCommandResponse()
                {
                    Response = new Domain.Dtos.Response.Response
                    {
                        Success = false,
                        Message = "Invalid Credentials!",
                        ResponseType = Domain.Enums.ResponseType.NotFound,
                    }
                };
            }

            var _token = await _refreshTokenReadRepository.GetTokenByUserIdAndIpAdressAsync(user.Id, request.IpAdress);

            if(_token != null && _token.ExpiryDate > DateTime.Now)
            {
                return new LoginUserCommandResponse()
                {
                    Response = new Domain.Dtos.Response.Response
                    {
                        Success = true,
                        Message = "Success!",
                        ResponseType = Domain.Enums.ResponseType.Success,
                    },
                    Token = _token.Token
                };
            }

            if(_token.ExpiryDate < DateTime.Now)
            {
                _token.IsValid = false;
                await _refreshTokenWriteRepository.UpdateEntityAsync(_token);
            }

            Guid id = Guid.NewGuid();

            RefreshToken token = new RefreshToken
            {
                Id = id,
                Token = _tokenService.GenerateToken(user.Username, user.Id, id),
                ExpiryDate = DateTime.Now.AddDays(7),
                IsValid = true,
                UserId = user.Id,
                IpAddress = request.IpAdress
            };

            await _refreshTokenWriteRepository.AddAsync(token);
            await _refreshTokenWriteRepository.SaveChangesAsync();

            return new LoginUserCommandResponse()
            {
                Response = new Domain.Dtos.Response.Response
                {
                    Success = true,
                    Message = "Success!",
                    ResponseType = Domain.Enums.ResponseType.Success,
                },
                Token = token.Token
            };
        }
    }
}
