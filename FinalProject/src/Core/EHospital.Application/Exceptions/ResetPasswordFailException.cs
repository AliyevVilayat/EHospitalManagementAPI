namespace EHospital.Application.Exceptions;

public class ResetPasswordFailException:Exception
{
    public ResetPasswordFailException() : base(message: "There was a problem resetting the password.")
    {

    }

    public ResetPasswordFailException(string message) : base(message: message)
    {

    }
}
