﻿using Dima.Api.Common.Api;
using Dima.Api.Models;
using Dima.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Dima.Api.Endpoints.Identity
{
    public class LogouEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
          => app.MapPost("/logout", HandleAsync).RequireAuthorization();

        private static async Task<IResult> HandleAsync(SignInManager<User> signInManager)
        {
            await signInManager.SignOutAsync();
            return Results.Ok();
        }
    }
}
