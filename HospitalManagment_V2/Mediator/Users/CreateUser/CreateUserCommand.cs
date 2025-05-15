using HospitalManagment_V2.DataAccess.Entities;
using HospitalManagment_V2.Repository;
using MediatR;

namespace HospitalManagment_V2.Mediator.Users.CreateUser;

public record CreateUserCommand(CreateUserDto dto) : IRequest<int>;

public class CreateUserCommandHandler(IUserRepository repo) : IRequestHandler<CreateUserCommand, int>
{
    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Username = request.dto.Username,
            PasswordHash = request.dto.PasswordHash,
            Email = request.dto.Email,
            RoleId = request.dto.RoleId,
        };
        await repo.AddAsync(user);
        return user.UserId;
    }
}
