using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Express.Models
{
    public class ShippingFee
    {
        [Key]
        public Guid IDFee { get; set; }
        public Boolean Disabled { get; set; }
        public float MaxKg { get; set; }
        public float Noitinh_Ngoaithanh { get; set; }
        public float Noitinh_Noithanh { get; set; }
        public float Noitinh_Kgthem { get; set; }
        public string Noitinh_TGGiao { get; set; }
        public float Noivung_Ngoaithanh { get; set; }
        public float Noivung_Noithanh { get; set; }
        public float Noivung_Kgthem { get; set; }
        public string Noivung_TGGiao { get; set; }
        public float Lienvung_Ngoaithanh_Low { get; set; }
        public float Lienvung_Ngoaithanh_Fast { get; set; }
        public float Lienvung_Noithanh_Low { get; set; }
        public float Lienvung_Noithanh_Fast { get; set; }
        public float Lienvung_Kgthem_Low { get; set; }
        public float Lienvung_Kgthem_Fast { get; set; }
        public string Noivung_TGGiao_Low { get; set; }
        public string Noivung_TGGiao_Fast { get; set; }
        public float LienvungDB_Ngoaithanh_Low { get; set; }
        public float LienvungDB_Ngoaithanh_Fast { get; set; }
        public float LienvungDB_Noithanh_Low { get; set; }
        public float LienvungDB_Noithanh_Fast { get; set; }
        public float LienvungDB_Kgthem_Low { get; set; }
        public float LienvungDB_Kgthem_Fast { get; set; }
        public string NoivungDB_TGGiao_Low { get; set; }
        public string NoivungDB_TGGiao_Fast { get; set; }
        public Guid Compid { get; set; }
        public ShipCompany ShipCompany { get; set; }
    }
}
