using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Express.Models
{
    public class ShipDiscount
    {
        [Key]
        public Guid IDDis { get; set; }
        public string DisName { get; set; }
        public float ValueDis { get; set; }
        public Guid Compid { get; set; }
        public ShipCompany ShipCompany { get; set; }
    }
}
