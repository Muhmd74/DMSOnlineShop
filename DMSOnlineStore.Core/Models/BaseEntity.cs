using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DMSOnlineStore.Core.Models
{
   public class BaseEntity
    {
  
        public Guid Id { get; set; }
    }
}
