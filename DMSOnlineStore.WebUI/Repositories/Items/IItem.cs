using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.WebUI.ViewModel;
using DMSOnlineStore.WebUI.ViewModel.ItemsViewModel;

namespace DMSOnlineStore.WebUI.Repositories.Items
{
    public interface IItem
    {

        Task<ItemFormViewModel> Add(ItemFormViewModel model);
        Task<ItemFormViewModel> Update(ItemFormViewModel model);
        
        Task<bool> DeleteOrRestore(Guid id);
        Task<bool> ChangeActivity(Guid id);
        Task<IEnumerable<ItemsViewModel>> Filter(string name);
        Task<IEnumerable<ItemsViewModel>> GetAll();
        Task<IEnumerable<ItemsViewModel>> GetAllDeleted();
        Task<ItemFormViewModel> Get(Guid id);
    }
}
