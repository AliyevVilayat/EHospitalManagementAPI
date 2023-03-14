namespace EHospital.Application.Exceptions;

public class AlreadyDeActiveException:Exception
{
    public AlreadyDeActiveException() : base(message: "This object already Deactive")
    {

    }

    public AlreadyDeActiveException(string message) : base(message: message)
    {

    }
}
