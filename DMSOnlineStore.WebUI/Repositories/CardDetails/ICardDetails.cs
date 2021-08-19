using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.WebUI.ViewModel.CardDetails;
using DMSOnlineStore.WebUI.ViewModel.CardHomeViewModel;

namespace DMSOnlineStore.WebUI.Repositories.CardDetails
{
    public interface ICardDetails
    {
        Task<CardDetailsViewModel> CardDetails(Guid id);
    }
}
