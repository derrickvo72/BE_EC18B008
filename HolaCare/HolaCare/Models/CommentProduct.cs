using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HolaCare.Models
{
    public class CommentProduct
    {
        [Key]
        public string IDCmtProduct { get; set; }
        public string IDProduct { get; set; }
        public string Description { get; set; }
        public string ComposerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime TimeCmtProduct { get; set; }
        public string Image { get; set; }
        public Boolean DisabledCmtProduct { get; set; }
        public Product Product { get; set; }
    }
}
