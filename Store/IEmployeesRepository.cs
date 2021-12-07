using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public interface IEmployeesRepository: IRepositoryBase<Employees>
    {
        void CreateEmployees(Employees employees);
        void UpdateEmployees(Employees employees);
        void DeleteEmployees(Employees employees);
    }
}
