using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Express.Models
{
    public class Users
    {
        [Key]
        public string IDUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Authen { get; set; }
        public ICollection<Bill> Bills { get; set; }
        public string SubDisid { get; set; }
        public virtual SubDistricts SubDistrict { get; set; }
    }
}
