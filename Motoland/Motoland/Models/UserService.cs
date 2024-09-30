public interface IUserService
{
    bool ValidateUser(string email, string password);
}

public class UserService : IUserService
{
    public bool ValidateUser(string email, string password)
    {
        // Logika do walidacji użytkownika z bazy danych
        // Zwróć true, jeśli dane są poprawne, w przeciwnym razie false
        return email == "test@example.com" && password == "password";
    }
}
