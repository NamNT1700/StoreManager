using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Store
{
    public interface IOrdersRepository: IRepositoryBase<Orders>
    {
        IEnumerable<Orders> OrdersByCustomers(int customersNumber);
    }
}
