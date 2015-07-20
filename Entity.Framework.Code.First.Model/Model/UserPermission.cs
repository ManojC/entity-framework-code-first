namespace Entity.Framework.Code.First.Model.Model
{
    public class UserPermission
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long PermissionId { get; set; }

        public Permission Permission { get; set; }
        public User User { get; set; }
    }
}
