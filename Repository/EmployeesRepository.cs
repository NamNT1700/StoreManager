using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeesRepository: RepositoryBase<Employees>, IEmployeesRepository
    {
        public EmployeesRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Employees> GetAllEmployees()
        {
            return FindAll()
                .OrderBy(o => o.EmployeeId)
                .ToList();
        }
       
        public async Task CreateEmployees(Employees employees)
        {
           
           await Task.Run(()=>Create(employees));
        }

        public void DeleteEmployees(Employees employees)
        {
            Delete(employees);
        }

        public async Task<Employees> GetEmployeeByNumber(int employeeID)
        {
            return await  FindByCondition(em => em.EmployeeId.Equals(employeeID))
           .FirstOrDefaultAsync();
        }

        public async Task UpdateEmployees(Employees employees)
        {
            await Task.Run(() => Update(employees));
        }
    }
}
