using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.WebUI.Repositories.Order.Dtos;
using DMSOnlineStore.WebUI.ViewModel.OrderCreated;

namespace DMSOnlineStore.WebUI.Repositories.Order
{
    public interface IOrder
    {
         Task<bool> CreateOrder(CreateOrderViewModel model,Guid userId);

    }
}
