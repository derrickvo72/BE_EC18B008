using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Express.Models
{
    public class ShipCompany
    {
        [Key]
        public string IDCompany { get; set; }
        public string CompanyName { get; set; }
        public string ComAddress { get; set; }
        public string MST { get; set; }
        public string Email { get; set; }
        public string RegisterDay { get; set; }
        public string EndDay { get; set; }
        public string SubDisid { get; set; }
        public virtual SubDistricts SubDistrict { get; set; }
        public ICollection<CommissionsRule> CommissionsRules { get; set; }
        public ICollection<ShippingFee> ShippingFees { get; set; }
        public ICollection<ShipDiscount> ShipDiscounts { get; set; }
    }
}
