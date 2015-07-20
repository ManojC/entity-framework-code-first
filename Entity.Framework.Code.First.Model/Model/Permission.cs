using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Framework.Code.First.Model.Model
{
    public class Permission
    {
        public long Id { get; set; }

        [MaxLength(50), Required]
        public string Type { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
