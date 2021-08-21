using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.WebUI.ViewModel.CartShipping;

namespace DMSOnlineStore.WebUI.Repositories.CartShipping
{
    public interface ICartShipping
    {
          Task<IEnumerable<CartShippingViewModel>> CartItems(Guid userId);
          Task<bool> UpdateQuantity(Guid orderDetailsId, int quantity);
          Task<bool> DeleteItem(Guid orderDetailsId);
    }
}
