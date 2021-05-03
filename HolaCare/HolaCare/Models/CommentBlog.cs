using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HolaCare.Models
{
    public class CommentBlog
    {
        [Key]
        public string IDCmtBlog { get; set; }        
        public string IDBlog { get; set; }
        public string Description { get; set; }
        public string ComposerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime TimeCmtBlog { get; set; }
        public string Image { get; set; }
        public Boolean DisabledCmtblog { get; set; }
        public Blog Blog { get; set; }
    }
}
