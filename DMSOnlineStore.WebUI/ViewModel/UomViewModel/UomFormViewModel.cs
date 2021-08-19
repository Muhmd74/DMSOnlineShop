using System;
using System.ComponentModel.DataAnnotations;
using DMSOnlineStore.Core.Models;

namespace DMSOnlineStore.WebUI.ViewModel.UomViewModel
{
    public class UomFormViewModel 
    {
        public Guid Id { get; set; }
        [Required,StringLength(50)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }
    }
}
