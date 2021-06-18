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
        public Boolean Prepair { get; set; }
        public Boolean ShipReceive { get; set; }
        public Boolean Shipping { get; set; }
        public Boolean PostReceive { get; set; }
        public Boolean ShippingToC { get; set; }
        public Boolean ShippingDone { get; set; }
        public string Billid { get; set; }
        public virtual Bill Bill { get; set; }
    }
}
