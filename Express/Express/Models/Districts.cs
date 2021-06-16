using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Express.Models
{
    public class Districts
    {
        [Key]
        public Guid IDDistrict { get; set; }
        public string DistrictName { get; set; }
        public Boolean CentralDistrict { get; set; }
        public ICollection<SubDistricts> SubDistricts { get; set; }
        public Guid Proid { get; set; }
        public Provinces Province { get; set; }
    }
}
