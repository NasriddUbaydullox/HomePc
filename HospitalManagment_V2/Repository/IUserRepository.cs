using HospitalManagment_V2.DataAccess.Entities;

namespace HospitalManagment_V2.Repository;

public interface IUserRepository : IRepository<User>
{
    IQueryable<User?> GetAllActive();

    Task<User?> GetByUsernameAsync(string username);
}
