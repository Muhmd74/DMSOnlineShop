using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DMSOnlineStore.Core.Interfaces;

namespace DMSOnlineStore.Core.Models
{
   public class User : BaseEntity , IAggregateRoot
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
