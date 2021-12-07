using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Store
{
    public interface IOfficesRepository: IRepositoryBase<Offices>
    {
        void CreateOffices(Offices offices);
        void UpdateOffices(Offices offices);
        void DeleteOffices(Offices offices);
        Offices GetOfficesByOfficesCode(string OfficesCode);
    }
}
