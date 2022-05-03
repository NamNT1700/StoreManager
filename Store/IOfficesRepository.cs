using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store
{
    public interface IOfficesRepository : IRepositoryBase<Offices>
    {
        Task CreateOffices(Offices offices);
        Task UpdateOffices(Offices offices);
        void DeleteOffices(Offices offices);
        Task<Offices> GetOfficesByOfficesCode(int OfficesID);
        IEnumerable<Offices> GetAllOffices();
        Task<Offices> GetEmployeesInOfficeAsync(int OfficesID);


    }
}
