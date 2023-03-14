namespace EHospital.Application.Exceptions;

public class AlreadyRegisteredException:Exception
{
    public AlreadyRegisteredException(string message) : base(message: message)
    {

    }
}
