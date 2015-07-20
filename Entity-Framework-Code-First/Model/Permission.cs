using System.ComponentModel.DataAnnotations;

namespace Entity.Framework.Code.First.Model
{
    public class Permission
    {
        public long Id { get; set; }
        [MaxLength(50)]
        public string Type { get; set; }
    }
}
