using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestDeloitte.Models
{
    public class UserDetailsModel:UserModel
    {
        public string Picture { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        [DataType(DataType.MultilineText)]
        public string About { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Registered { get; set; }
    }
}
