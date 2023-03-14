using EHospital.Application.Repositories;

namespace EHospital.Application;

public interface IUnitOfWork
{
    IServiceReadRepository ServiceReadRepository { get; }
    IServiceWriteRepository ServiceWriteRepository { get; }
    IRoomReadRepository RoomReadRepository { get; }
    IRoomWriteRepository RoomWriteRepository { get; }
    IResultServiceReadRepository ResultServiceReadRepository { get; }
    IResultServiceWriteRepository ResultServiceWriteRepository { get; }
    IRegistrationReadRepository RegistrationReadRepository { get; }
    IRegistrationWriteRepository RegistrationWriteRepository { get; }
    IReceptionistReadRepository ReceptionistReadRepository { get; }
    IReceptionistWriteRepository ReceptionistWriteRepository { get; }
    IPatientReadRepository PatientReadRepository { get; }
    IPatientWriteRepository PatientWriteRepository { get; }
    IInsuranceReadRepository InsuranceReadRepository { get; }
    IInsuranceWriteRepository InsuranceWriteRepository { get; }
    IFieldReadRepository FieldReadRepository { get; }
    IFieldWriteRepository FieldWriteRepository { get; }
    IDoctorReadRepository DoctorReadRepository { get; }
    IDoctorWriteRepository DoctorWriteRepository { get; }
    IGenderReadRepository GenderReadRepository { get; }
    IBloodGroupReadRepository BloodGroupReadRepository { get; }
    IUserRepository UserRepository { get; }
    IRoleRepository RoleRepository { get; }
    Task<int> SaveAsync(CancellationToken cancellationToken = default);
}
