using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Entity.Framework.Code.First.Model.Model
{
    public class UserType
    {
        public UserType()
        {
            Users = new Collection<User>();
        }

        public long Id { get; set; }
        [MaxLength(50), Required]
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
