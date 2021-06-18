using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Express.Models
{
    public class BillStatusDetail
    {
        [Key]
        public string IDStatus { get; set; }
        public string Prepair { get; set; }
        public string ShipReceive { get; set; }
        public string Shipping { get; set; }
        public string PostReceive { get; set; }
        public string ShippingToC { get; set; }
        public string ShippingDone { get; set; }
        public string Billid { get; set; }
        public virtual Bill Bill { get; set; }
    }
}
