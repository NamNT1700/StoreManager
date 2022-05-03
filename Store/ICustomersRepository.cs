using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store
{
    public interface ICustomersRepository : IRepositoryBase<Customers>
    {

        IEnumerable<Customers> GetAllCustomers();
        Task<Customers> GetCumstomersByID(int CustumersID);
        Customers GetCumstomersByPostalCode(Guid PostalCode);
        Customers GetCustomersWithDetails(int CustumersID);

        Task CreateCustomers(Customers customers);
        Task UpdateCustomers(Customers customers);
        void DeleteCustomers(Customers customers);
    }
}
