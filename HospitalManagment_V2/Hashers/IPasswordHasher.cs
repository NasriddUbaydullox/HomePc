namespace HospitalManagment_V2.Hashers;

public interface IPasswordHasher
{
    string HashPassword(string password);

    bool VerifyHash(string password, string hash);
}
