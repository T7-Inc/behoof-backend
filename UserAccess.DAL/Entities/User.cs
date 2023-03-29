using Microsoft.AspNetCore.Identity;

namespace UserAccess.DAL.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Currency { get; set; }
    public string Country { get; set; }
    public byte[]? Photo { get; set; }
    //?public string SubscriptionId { get; set; }
}