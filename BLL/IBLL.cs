using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace BLL
{
	public interface IBLL
	{
		IList<Department> GetAllDepartments();

		IList<Doctor> GetAllDoctors();
		IList<Doctor> GetAllDoctorsFromDepartment(string departmentName);
	}
}
