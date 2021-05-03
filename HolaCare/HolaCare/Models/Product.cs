using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HolaCare.Models
{
    public class Product
    {
        [Key]
        public string ID3code { get; set; }
        public string IDBrand { get; set; }
        public string IDSkintype { get; set; }
        public string IDProductType { get; set; }
        public string NameProduct { get; set; }
        public string NameProductType { get; set; }
        public string Description { get; set; }
        public string Linktobuy { get; set; }
        public byte[] Image { get; set; }
        public float PointProduct { get; set; }
        public Boolean DisabledPro { get; set; }
        public IList<IngreProduct> IngreProducts { get; set; }
        public Brand Brand { get; set; }
        public SkinType Skintype { get; set; }
        public ProductType ProductType { get; set; }
        public ICollection<CommentProduct> CommentProducts { get; set; }

    }
}
