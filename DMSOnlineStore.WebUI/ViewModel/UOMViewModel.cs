using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSOnlineStore.Core.Models;

namespace DMSOnlineStore.WebUI.ViewModel
{
    public class UOMViewModel : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
