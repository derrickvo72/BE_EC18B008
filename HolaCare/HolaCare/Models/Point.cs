using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HolaCare.Models
{
    public class Point
    {
        [Key]
        public string IDPoint { get; set; }
        public string IDSkinType { get; set; }
        public float PAcneType { get; set; }
        public float PPastUsing { get; set; }
        public float PDailyHabit { get; set; }
        public float PMealHabit { get; set; }
        public byte[] Image { get; set; }
        public float PTotal { get; set; }
        public SkinType Skintype { get; set; }

    }
}
