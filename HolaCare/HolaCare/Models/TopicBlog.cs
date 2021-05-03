using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace HolaCare.Models
{
    public class TopicBlog
    {
        [Key]
        public string IDTopicBlog { get; set; }
        public string NameTopicBlog { get; set; }
        public Boolean DisabledTopicBlog { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        
    }
}
