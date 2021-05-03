using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HolaCare.Models
{
    public class ProductType
    {
        [Key]
        public string IDProductType { get; set; }
        public string NameProductType { get; set; }
        public string Description { get; set; }
        public Boolean DisabledProductType { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
