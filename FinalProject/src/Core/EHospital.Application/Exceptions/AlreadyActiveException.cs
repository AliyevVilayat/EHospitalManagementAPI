namespace EHospital.Application.Exceptions;

public class AlreadyActiveException:Exception
{
    public AlreadyActiveException():base(message:"This object already Active")
    {

    }

    public AlreadyActiveException(string message) : base(message: message)
    {

    }
}
