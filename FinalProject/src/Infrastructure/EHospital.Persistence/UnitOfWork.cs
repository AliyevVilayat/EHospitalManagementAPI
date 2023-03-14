using EHospital.Application;
using EHospital.Application.Repositories;
using EHospital.Persistence.Contexts;
using EHospital.Persistence.Repositories;

namespace EHospital.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly EHospitalDbContext _context;
    private  IServiceReadRepository? _serviceReadRepository;
    private  IServiceWriteRepository? _serviceWriteRepository;
    private  IRoomReadRepository? _roomReadRepository;
    private  IRoomWriteRepository? _roomWriteRepository;
    private  IResultServiceReadRepository? _resultServiceReadRepository;
    private  IResultServiceWriteRepository? _resultServiceWriteRepository;
    private  IRegistrationReadRepository? _registrationReadRepository;
    private  IRegistrationWriteRepository? _registrationWriteRepository;
    private  IReceptionistReadRepository? _receptionistReadRepository;
    private  IReceptionistWriteRepository? _receptionistWriteRepository;
    private  IPatientReadRepository? _patientReadRepository;
    private  IPatientWriteRepository? _patientWriteRepository;
    private  IInsuranceReadRepository? _insuranceReadRepository;
    private  IInsuranceWriteRepository?  _insuranceWriteRepository;
    private  IFieldReadRepository? _fieldReadRepository;
    private  IFieldWriteRepository? _fieldWriteRepository;
    private  IDoctorReadRepository? _doctorReadRepository;
    private  IDoctorWriteRepository? _doctorWriteRepository;
    private  IGenderReadRepository? _genderReadRepository;
    private  IBloodGroupReadRepository? _bloodGroupReadRepository;
    private  IUserRepository? _userRepository;
    private  IRoleRepository? _roleRepository;

    public UnitOfWork(EHospitalDbContext context)
    {
        _context = context;
    }

    public IServiceReadRepository ServiceReadRepository => _serviceReadRepository??= new ServiceReadRepository(_context);

    public IServiceWriteRepository ServiceWriteRepository => _serviceWriteRepository??= new ServiceWriteRepository(_context);

    public IRoomReadRepository RoomReadRepository => _roomReadRepository ??= new RoomReadRepository(_context);

    public IRoomWriteRepository RoomWriteRepository => _roomWriteRepository ??= new RoomWriteRepository(_context);

    public IResultServiceReadRepository ResultServiceReadRepository => _resultServiceReadRepository ??= new ResultServiceReadRepository(_context);

    public IResultServiceWriteRepository ResultServiceWriteRepository => _resultServiceWriteRepository ??= new ResultServiceWriteRepository(_context);

    public IRegistrationReadRepository RegistrationReadRepository => _registrationReadRepository ??= new RegistrationReadRepository(_context);

    public IRegistrationWriteRepository RegistrationWriteRepository => _registrationWriteRepository ??= new RegistrationWriteRepository(_context);

    public IReceptionistReadRepository ReceptionistReadRepository => _receptionistReadRepository ??= new ReceptionistReadRepository(_context);

    public IReceptionistWriteRepository ReceptionistWriteRepository => _receptionistWriteRepository ??= new ReceptionistWriteRepository(_context);

    public IPatientReadRepository PatientReadRepository => _patientReadRepository ??= new PatientReadRepository(_context);

    public IPatientWriteRepository PatientWriteRepository => _patientWriteRepository ??= new PatientWriteRepository(_context);

    public IInsuranceReadRepository InsuranceReadRepository => _insuranceReadRepository ??= new InsuranceReadRepository(_context);

    public IInsuranceWriteRepository InsuranceWriteRepository => _insuranceWriteRepository ??= new InsuranceWriteRepository(_context);

    public IFieldReadRepository FieldReadRepository => _fieldReadRepository ??= new FieldReadRepository(_context);

    public IFieldWriteRepository FieldWriteRepository => _fieldWriteRepository ??= new FieldWriteRepository(_context);

    public IDoctorReadRepository DoctorReadRepository => _doctorReadRepository ??= new DoctorReadRepository(_context);

    public IDoctorWriteRepository DoctorWriteRepository => _doctorWriteRepository ??= new DoctorWriteRepository(_context);

    public IGenderReadRepository GenderReadRepository => _genderReadRepository ??= new GenderReadRepository(_context);

    public IBloodGroupReadRepository BloodGroupReadRepository => _bloodGroupReadRepository ??= new BloodGroupReadRepository(_context);

    public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);

    public IRoleRepository RoleRepository => _roleRepository ??= new RoleRepository(_context);

    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync();
    }
}
