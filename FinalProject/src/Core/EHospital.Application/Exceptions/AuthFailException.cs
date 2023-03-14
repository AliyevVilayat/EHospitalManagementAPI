namespace EHospital.Application.Exceptions;

public class AuthFailException:Exception
{
    public AuthFailException():base(message: "Username or password is invalid")
    {

    }

    public AuthFailException(string message) : base(message: message)
    {

    }
}
