using Entities;
using Entities.Models;
using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class OfficesRepository: RepositoryBase<Offices>, IOfficesRepository
    {
        public OfficesRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateOffices(Offices offices)
        {
            Create(offices);
        }

        public void DeleteOffices(Offices offices)
        {
            Delete(offices);
        }

        public Offices GetOfficesByOfficesCode(string OfficesCode)
        {
            return FindByCondition(OfficesCode => OfficesCode.OfficeCode.Equals(OfficesCode))
            .FirstOrDefault();
        }

        public void UpdateOffices(Offices offices)
        {
            Update(offices);
        }
    }
   }

