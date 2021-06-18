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
        public string IDComRT { get; set; }
        public float Value { get; set; }
        public Boolean Approved { get; set; }
        public string Billid { get; set; }
        public virtual Bill Bill { get; set; }
        public string IDComR { get; set; }
        public CommissionsRule CommissionsRule { get; set; }
    }
}
