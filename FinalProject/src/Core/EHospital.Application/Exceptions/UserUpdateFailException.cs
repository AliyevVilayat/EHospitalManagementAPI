namespace EHospital.Application.Exceptions;

public class UserUpdateFailException:Exception
{
    public UserUpdateFailException(string message) : base(message: message)
    {

    }
}
