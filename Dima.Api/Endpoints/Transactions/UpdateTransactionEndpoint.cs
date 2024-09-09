﻿using Dima.Api.Common.Api;
using Dima.Api.Models;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Transactions
{
    public class UpdateTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
           => app.MapPut("/{id}", HandleAsync)
       .WithName("Transactions: Update")
       .WithSummary("Atualiza uma transação")
       .WithDescription("Atualiza uma transação")
       .WithOrder(2)
       .Produces<Response<Transaction?>>();
        private static async Task<IResult> HandleAsync(ClaimsPrincipal user, ITransactionHandler handler, UpdateTransactionRequest request, long id)
        {
            var result = await handler.UpdateAsync(request);

            request.UserId = user.Identity?.Name ?? string.Empty;
            request.Id = id;

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
