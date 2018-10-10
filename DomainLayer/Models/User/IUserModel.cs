namespace DomainLayer.Models.User
{
    public interface IUserModel
    {
        string Login { get; set; }
        string Password { get; set; }
        int UserId { get; set; }
        int SettingsId { get; set; }
    }
}