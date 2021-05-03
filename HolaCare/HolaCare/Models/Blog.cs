using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HolaCare.Models
{
    public class Blog
    {
        [Key]
        public string IDBlog { get; set; }
        public string IDTopic { get; set; }
        public string IDUser { get; set; }
        public string IDComposer { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public Boolean DisabledBlog { get; set; }
        public TopicBlog TopicBlog { get; set; }
        public User User { get; set; }
        public ICollection<CommentBlog> CommentBlogs { get; set; }
    }
}
