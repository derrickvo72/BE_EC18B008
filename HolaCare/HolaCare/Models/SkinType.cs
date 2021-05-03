using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HolaCare.Models
{
    public class SkinType
    {
        [Key]
        public string IDSkinType { get; set; }
        public string NameSkinType { get; set; }
        public string Description { get; set; }
        public Boolean DisabledSkinType { get; set; }
        public ICollection<Product> Products { get; set; }        
        public ICollection<Point> Points { get; set; }        
    }
}
