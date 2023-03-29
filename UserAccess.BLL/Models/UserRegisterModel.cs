namespace UserAccess.BLL.Models;

public class UserRegisterModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Currency { get; set; }
    public string Country { get; set; }
}