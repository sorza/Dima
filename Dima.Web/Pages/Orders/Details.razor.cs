﻿using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Orders;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Orders
{
    public partial class  DetailsPage : ComponentBase
    {
        #region Parameters

        [Parameter] public string Number { get; set; } = string.Empty;

        #endregion

        #region Properties

        public Order Order { get; set; } = null!;
        #endregion

        #region Services

        [Inject] IOrderHandler Handler { get; set; } = null!;
        [Inject] ISnackbar Snackbar { get; set; } = null!;

        #endregion Overrides

        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            var request = new GetOrderByNumberRequest { Number = Number };

            var result = await Handler.GetByNumberAsync(request);

            if (result.IsSuccess)
                Order = result.Data!;
            else
            {
                Snackbar.Add(result.Message!, Severity.Error);
            }
        }
        #endregion

        #region Methods

        public void RefreshState(Order order)
        {
            Order = order;
            StateHasChanged();
        }

        #endregion
    }
}
