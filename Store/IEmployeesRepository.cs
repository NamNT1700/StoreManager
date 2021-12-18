using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public interface IEmployeesRepository: IRepositoryBase<Employees>
    {
        Task CreateEmployees(Employees employees);
        Task UpdateEmployees(Employees employees);
        void DeleteEmployees(Employees employees);
        Task<Employees> GetEmployeeByNumber(int employeeID);
        public IEnumerable<Employees> GetAllEmployees();
        
    }
}
