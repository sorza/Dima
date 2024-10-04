﻿using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Orders;
using Dima.Core.Responses;

namespace Dima.Web.Handlers
{
    public class OrderHandler : IOrderHandler
    {
        public Task<Response<Order?>> CancelAsync(CancelOrderRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Order?>> CreateAsync(CreateOrderRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Order>?>> GetAllAsync(GetAllOrdersRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Order>> GetByNumberAsync(GetOrderByNumberRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Order?>> PayAsync(PayOrderRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Order>> RefundOrderRequest(RefundOrderRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
