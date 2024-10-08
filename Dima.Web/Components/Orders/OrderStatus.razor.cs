using Dima.Core.Enums;
using Microsoft.AspNetCore.Components;

namespace Dima.Web.Components.Orders
{
    public partial class OrderStatusComponent : ComponentBase
    {
        #region Properties
        [Parameter, EditorRequired] public EOrderStatus Status { get; set; }

        #endregion
    }
}
