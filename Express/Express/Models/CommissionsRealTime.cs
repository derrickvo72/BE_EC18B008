using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Express.Models
{
    public class CommissionsRealTime
    {
        [Key]
        public Guid IDComRT { get; set; }
        public float Value { get; set; }
        public Boolean Approved { get; set; }
        public Guid Billid { get; set; }
        public virtual Bill Bill { get; set; }
        public Guid IDComR { get; set; }
        public CommissionsRule CommissionsRule { get; set; }
    }
}
