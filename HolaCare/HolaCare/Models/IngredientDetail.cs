using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HolaCare.Models
{
    public class IngredientDetail
    {
        [Key]
        public string IDIngre { get; set; }
        public string NameIngre { get; set; }
        public string Uses { get; set; }
        public string Function { get; set; }
        public float PointIngre { get; set; }
        public IList<IngreProduct> IngreProducts { get; set; }

    }
}
