using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Core.Models;
using DMSOnlineStore.WebUI.ViewModel.CardHomeViewModel;

namespace DMSOnlineStore.WebUI.Repositories.CardHome
{
    public interface ICard
    {
        Task<IEnumerable<CardHomeViewModel>> GetCards(string name);
        Task<bool> AddItemToCart(Guid id,Guid userId);

    }
}
