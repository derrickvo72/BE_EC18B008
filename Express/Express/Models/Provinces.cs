using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Express.Models
{
    public class Provinces
    {
        [Key]
        public Guid IDProvince { get; set; }
        public string ProvinceName { get; set; }
        public Boolean CentralProvince { get; set; }
        public string RegionName { get; set; }
        public ICollection<Districts> Districts { get; set; }
    }
}
