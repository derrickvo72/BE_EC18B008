using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Express.Models
{
    public class ShippingFee
    {
        [Key]
        public string IDFee { get; set; }
        public string NameFee { get; set; }
        public float Price { get; set; }
        public string TGGiao { get; set; }
        public float MaxKg { get; set; }
        public float PricePerKg { get; set; }
        public Boolean Disabled { get; set; }     
        public string Compid { get; set; }
        public ShipCompany ShipCompany { get; set; }
    }
}
