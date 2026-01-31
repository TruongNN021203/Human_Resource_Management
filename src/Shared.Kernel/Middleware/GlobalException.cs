using System.Net;
using System.Text.Json;
using Ecommerce.SharedLibrary.Logs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shared.Kernel.Middleware;
public class GlobalException(RequestDelegate next ) 
{

    public async Task InvokeAsync(HttpContext context)
    { //Declare default variables
            string message = "Sorry, internal server error occurrend. Kindly try again!!";
            int StatusCode = (int)HttpStatusCode.InternalServerError;
            string title = "Error";
        try
        {
            await next(context);
             //check if exception is too many request //429 status code.
                if (context.Response.StatusCode == StatusCodes.Status429TooManyRequests)
                {
                    title = "Warning";
                    message = "Too many request";
                    StatusCode = (int)StatusCodes.Status429TooManyRequests;
                    await ModifyHeader(context, title, message, StatusCode);

                }
                //check if response is unauthorize //401 status code
                if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
                {
                    title = "Alert";
                    message = "Your are not authorized to access";
                    StatusCode = (int)StatusCodes.Status401Unauthorized;

                    await ModifyHeader(context, title, message, StatusCode);
                }

                //if response is forbidden //403

                if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
                {
                    title = "Out of access";
                    message = "Your are not allow/require to access";
                    StatusCode = (int)StatusCodes.Status403Forbidden;

                    await ModifyHeader(context, title, message, StatusCode);
                }
        }
        catch (Exception ex)
        {
             //Log original exceptions/file, debugger, console
                LogException.LogExceptions(ex);

                //check if exception is timeout
                if (ex is TaskCanceledException || ex is TimeoutException)
                {
                    title = "Out of time";
                    message = "REquest timeout .... try again";
                    StatusCode = StatusCodes.Status408RequestTimeout;
                }


                // if none of the exceptions then do the default(at declare)
                // if exceptions is caught 

                await ModifyHeader(context, title, message, StatusCode);
        }
    }
     private async Task ModifyHeader(HttpContext context, string title, string message, int StatusCode)
        {
            //display scary-frr message to client
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(new ProblemDetails()
            {
                Detail = message,
                Status = StatusCode,
                Title = title,
            }), CancellationToken.None);
            return;
        }
}