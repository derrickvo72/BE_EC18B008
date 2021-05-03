using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HolaCare.Models
{
    public class User
    {
        [Key]
        public string IDUser { get; set; }
        public string IDPoint { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public Boolean Male { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Avatar { get; set; }
        public Boolean Authen { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        public Point Point { get; set; }
    }
}
