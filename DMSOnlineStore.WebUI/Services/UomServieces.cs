using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Core.Interfaces;
using DMSOnlineStore.Infrastructure.Data.Tools;
using DMSOnlineStore.WebUI.Repositories;
using DMSOnlineStore.WebUI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMSOnlineStore.WebUI.Services
{
    public class UomServieces : EfRepository<UOMViewModel>
    {
        private readonly IAsyncRepository<UOMViewModel> _repository;
        public UomServieces(ApplicationDbContext context, DbSet<UOMViewModel> entity, IAsyncRepository<UOMViewModel> repository) : base(context, entity)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UOMViewModel>> Index()
        {
            var model = await _repository.GetAll();
            return model;
        }

    }
}
