namespace EHospital.Application.Exceptions;

public class AddRoleFailException:Exception
{
    public AddRoleFailException():base(message:"")
    {

    }
    public AddRoleFailException(string message) : base(message: message)
    {

    }
}
