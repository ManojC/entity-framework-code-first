using System.ComponentModel.DataAnnotations;
namespace Entity.Framework.Code.First.Model
{
    public class User
    {
        public long Id { get; set; }
        [MaxLength(50)]
        public string Fname { get; set; }
        [MaxLength(50)]
        public string Lname { get; set; }
        public long UserTypeId { get; set; }
        public UserType UserTypes { get; set; }
    }
}
