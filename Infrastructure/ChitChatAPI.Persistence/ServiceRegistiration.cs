﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.IO;
using ChitChatAPI.Persistence.Contexts;
using ChitChatAPI.Aplication.Abstractions.Repositories;
using ChitChatAPI.Persistence.Concretes.Repositories;
using ChitChatAPI.Aplication.Abstractions.Services;
using ChitChatAPI.Persistence.Concretes.Services;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddUserSecrets(typeof(ServiceRegistration).Assembly)
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' is not found.");
        }

        services.AddDbContext<ChitChatDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IUserReadRepository, UserReadRepository>();
        services.AddScoped<IUserWriteRepository, UserWriteRepository>();

        services.AddScoped<IRefreshTokenReadRepository, RefreshTokenReadRepository>();
        services.AddScoped<IRefreshTokenWriteRepository, RefreshTokenWriteRepository>();

        services.AddScoped<IGroupMessageReadRepository, GroupMessageReadRepository>();
        services.AddScoped<IGroupMessageWriteRepository , GroupMessageWriteRepository>();

        services.AddScoped<IGroupReadRepository, GroupReadRepository>();
        services.AddScoped<IGroupWriteRepository , GroupWriteRepository>();

        services.AddScoped<IGroupUserReadRepository, GroupUserReadRepository>();
        services.AddScoped<IGroupUserWriteRepository , GroupUserWriteRepository>();

        services.AddScoped<ITokenService, TokenService>();
    }
}
