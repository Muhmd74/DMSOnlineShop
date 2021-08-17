using System.ComponentModel.DataAnnotations;

namespace DMSOnlineStore.WebUI.ViewModel
{
    public class UomFormViewModel
    {
        [Required,StringLength(50)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
    }
}
