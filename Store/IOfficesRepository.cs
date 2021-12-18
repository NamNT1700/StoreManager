using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Store
{
    public interface IOfficesRepository: IRepositoryBase<Offices>
    {
        Task CreateOffices(Offices offices);
        Task UpdateOffices(Offices offices);
        void DeleteOffices(Offices offices);
        Task<Offices> GetOfficesByOfficesCode(int OfficesID);
        IEnumerable<Offices> GetAllOffices();
        Task<Offices> GetEmployeesInOfficeAsync(int OfficesID);
       

    }
}
