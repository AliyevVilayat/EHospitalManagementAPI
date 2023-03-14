namespace EHospital.Application.Services;

public interface IAdminService
{
    public Task ToActiveDoctorAsync(string id);
    public Task ToActiveFieldAsync(string id);
    public Task ToActiveInsuranceAsync(string id);
    public Task ToActivePatientAsync(string id);
    public Task ToActiveReceptionistAsync(string id);
    public Task ToActiveRoomAsync(string id);
    public Task ToActiveServiceAsync(string id);
    public Task ToActiveUserAsync(string id);
}
