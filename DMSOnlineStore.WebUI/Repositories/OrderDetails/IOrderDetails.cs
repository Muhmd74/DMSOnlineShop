using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Core.Enums;
using DMSOnlineStore.WebUI.ViewModel.OrderTableViewModel;

namespace DMSOnlineStore.WebUI.Repositories.OrderDetails
{
    public interface IOrderDetails
    {
        Task<List<OrderTableViewModel>> GetOrders();
        Task<bool> ChangeStatueOrder(Guid id, StatueType statue);
        Task<OrderTableDetailsViewModel> OrderDetails(Guid id);
    }
}
