using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HolaCare.Models
{
    public class Brand
    {
        [Key]
        public string IDBrand { get; set; }
        public string BrandName { get; set; }
        public string DescriptionBrand { get; set; }
        public Boolean DisabledBrand { get; set; }
        public ICollection<Product> Products { get; set; }
      
    }
}
