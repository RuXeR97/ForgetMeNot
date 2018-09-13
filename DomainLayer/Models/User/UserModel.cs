namespace DomainLayer.Models.User
{
    public class UserModel : IUserModel
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
