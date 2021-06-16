using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Express.Models
{
    public class CommissionsRule
    {
        [Key]
        public Guid IDComR { get; set; }      
        public float ComPerBill { get; set; }
        public Boolean Disabled { get; set; }
        public Guid IDCompany { get; set; }
        public ShipCompany ShipCompany { get; set; }
        public ICollection<CommissionsRealTime> CommisstionsRealTimes { get; set; }
    }
}
