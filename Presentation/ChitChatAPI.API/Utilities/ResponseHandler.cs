using ChitChatAPI.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ChitChatAPI.API.Utilities
{
    public static class ResponseHandler
    {
        public static IActionResult CreateResponse<T>(T response) where T : class
        {
            if (response is null)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            var responseTypeProperty = typeof(T).GetProperty("Response");
            if (responseTypeProperty == null)
            {
                throw new ArgumentException("Response object does not contain a 'Response' property.");
            }

            var responseObject = responseTypeProperty.GetValue(response);
            if (responseObject == null)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            var responseTypePropertyNested = responseObject.GetType().GetProperty("ResponseType");
            var messagePropertyNested = responseObject.GetType().GetProperty("Message");

            if (responseTypePropertyNested == null || messagePropertyNested == null)
            {
                throw new ArgumentException("Response object does not contain required properties 'ResponseType' or 'Message'.");
            }

            var responseType = (ResponseType)responseTypePropertyNested.GetValue(responseObject);
            var message = messagePropertyNested.GetValue(responseObject)?.ToString();

            return responseType switch
            {
                ResponseType.Success => new OkObjectResult(response),
                ResponseType.Unauthorized => new UnauthorizedObjectResult(new { message }),
                ResponseType.ValidationError => new BadRequestObjectResult(new { message }),
                ResponseType.Conflict => new ConflictObjectResult(new { message }),
                ResponseType.NotFound => new NotFoundObjectResult(new { message }),
                ResponseType.ServerError => new ObjectResult(new { message = "An internal server error occurred." })
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                },
                _ => new StatusCodeResult(StatusCodes.Status500InternalServerError)
            };
        }
    }
}
