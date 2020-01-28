using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestDeloitte.Models
{
    public class UserModel
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public List<string> Tags { get; set; }

    }
}
