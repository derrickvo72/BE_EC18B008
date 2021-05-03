using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HolaCare.Models
{
    public class IngreProduct
    {
        public string ID3code { get; set; }
        public Product Product { get; set; }

        public string IDIngre { get; set; }
        public IngredientDetail IngredientDetail { get; set; }
    }
}
