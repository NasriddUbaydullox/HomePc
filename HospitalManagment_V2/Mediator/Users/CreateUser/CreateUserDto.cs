namespace HospitalManagment_V2.Mediator.Users.CreateUser;

public class CreateUserDto
{
    public string Username { get; set; }

    public string PasswordHash { get; set; }

    public string Email { get; set; }

    public int? RoleId { get; set; }
}
