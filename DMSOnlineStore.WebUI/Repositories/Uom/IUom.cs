using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.WebUI.ViewModel;
using DMSOnlineStore.WebUI.ViewModel.UomViewModel;

namespace DMSOnlineStore.WebUI.Repositories.Uom
{
    public interface IUom
    {
        Task<bool> Add(UomFormViewModel model);
        Task<bool> Update(UomFormViewModel model);
        Task<bool> DeleteOrRestore(Guid id);
        Task<IEnumerable<UomFormViewModel>> GetAll(string name);
        Task<IEnumerable<UomFormViewModel>> Filter(string name);
        Task<IEnumerable<UomFormViewModel>> GetAllDeleted();
        Task<UomFormViewModel> Get(Guid id);


    }
}
