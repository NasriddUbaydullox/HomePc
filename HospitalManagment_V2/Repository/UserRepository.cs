using HospitalManagment_V2.DataAccess;
using HospitalManagment_V2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagment_V2.Repository;

public class UserRepository(Context context)
    : Repository<User>(context), IUserRepository
{
    public IQueryable<User?> GetAllActive()
    {
        return context.Users.Where(u => u.IsActive);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await context.Users
            .FirstOrDefaultAsync(u => u.Username == username && u.IsActive);
    }
}
