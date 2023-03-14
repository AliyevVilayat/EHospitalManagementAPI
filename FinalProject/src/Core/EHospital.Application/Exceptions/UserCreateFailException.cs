namespace EHospital.Application.Exceptions;

public class UserCreateFailException:Exception
{
    public UserCreateFailException(string message) : base(message: message)
    {

    }
}
