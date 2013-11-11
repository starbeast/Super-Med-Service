using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataRepositories;
using DAL.Interfaces;
using DomainModel;
using DAL;

namespace BLL
{
    public class Bll:IBLL
    {
	    private readonly IDepartmentRepository _departmentRepository;
	    private readonly IDoctorRepository _doctorRepository;
	    private readonly IPatientRepository _patientRepository;
	    private readonly ITicketRepository _ticketRepository;
	    private readonly IRangeRepository _rangeRepository;

		public Bll()
		{
			_departmentRepository = new DepartmentRepository();
			_doctorRepository = new DoctorRepository();
			_patientRepository = new PatientRepository();
			_ticketRepository = new TicketRepository();
			_rangeRepository = new RangeRepository();
		}

	    public IList<Department> GetAllDepartments()
	    {
		    return _departmentRepository.GetAll() as IList<Department>;
	    }

	    public IList<Doctor> GetAllDoctors()
	    {
		    return _doctorRepository.GetAll() as IList<Doctor>;
	    }

	    public IList<Doctor> GetAllDoctorsFromDepartment(string departmentName)
	    {
			return _doctorRepository.GetList(d => d.Department.DepName.Equals(departmentName));
	    }
    }
}
