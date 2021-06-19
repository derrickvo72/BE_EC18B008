using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Express.Models
{
    public class Bill
    {
        [Key]
        public string IDBill { get; set; }
        public string SendAdd { get; set; }
        public string SendPhone { get; set; }
        public string ReceiveAdd { get; set; }
        public string ReceivePhone { get; set; }
        public float ShippingFee { get; set; }
        public float weight { get; set; }
        public string ShippingTime { get; set; }
        public string PaymentMethod { get; set; }
        public Boolean ShippingDone { get; set; }
        public virtual BillStatusDetail StatusDetail { get; set; }
        public virtual CommissionsRealTime CommisstionsRealTime { get; set; }
        public string Userid { get; set; }
        public Users User { get; set; }
        public string Compid { get; set; }

    }
}
