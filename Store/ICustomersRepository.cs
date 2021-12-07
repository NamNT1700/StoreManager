using Store;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Store
{
    public interface ICustomersRepository: IRepositoryBase<Customers>
    {

        IEnumerable<Customers> GetAllCustomers();
        Customers GetCumstomersByNumber(int CustumersNumber);
        Customers GetCumstomersByPostalCode(Guid PostalCode);
        Customers GetCustomersWithDetails(int CustumersNumber);
        //int GetNumberForCustomers(Customers CustumersNumber);

        void CreateCustomers(Customers customers);
        void UpdateCustomers(Customers customers);
        void DeleteCustomers(Customers customers);
    }
}
