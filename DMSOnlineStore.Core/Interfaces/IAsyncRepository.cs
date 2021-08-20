using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DMSOnlineStore.Core.Models;

namespace DMSOnlineStore.Core.Interfaces
{
    public interface IAsyncRepository<TModel> where TModel : class
    {
        Task<TModel> GetById(Guid id);
        Task<IEnumerable<TModel>> GetAll();
        Task<TModel> Add(TModel model);
        Task<bool> Update(TModel model);
        Task<bool> Delete(Guid id);
    }
}
