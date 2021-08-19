using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.WebUI.Repositories.Order.Dtos;

namespace DMSOnlineStore.WebUI.Repositories.Order
{
    public interface IOrder
    {
         Task<bool> AddToCard(OrderItems model);

    }
}
