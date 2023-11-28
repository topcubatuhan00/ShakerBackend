namespace Shaker.Domain.Models.UserModels;

public class CreateUserModel
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
