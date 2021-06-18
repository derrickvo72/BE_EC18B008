using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Express.Models
{
    public class SubDistricts
    {
        [Key]
        public string IDSubDistrict { get; set; }
        public string SubDistrictName { get; set; }
        public virtual Users User { get; set; }
        public string Disid { get; set; }
        public Districts District { get; set; }
        public virtual ShipCompany ShipCompany { get; set; }
    }
}
