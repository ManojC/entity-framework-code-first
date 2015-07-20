using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Framework.Code.First.Model.Model
{
    public class User
    {
        public long Id { get; set; }

        [MaxLength(50), Required]
        public string Fname { get; set; }

        [MaxLength(50), Required]
        public string Lname { get; set; }

        public long? UserTypeId { get; set; }

        public UserType UserTypes { get; set; }

        public ICollection<Permission> Permissions { get; set; }
    }
}
