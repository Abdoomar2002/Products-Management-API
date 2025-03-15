﻿using System.Net;
using System.Text.Json;
using Products_Management_API.Server.Exceptions;

namespace Products_Management_API.Server.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = exception is ApiException apiEx
                ? apiEx.StatusCode
                : (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                error = exception.Message,
                statusCode
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
