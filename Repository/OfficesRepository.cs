using Entities;
using Entities.Models;
using Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class OfficesRepository: RepositoryBase<Offices>, IOfficesRepository
    {
        public OfficesRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
   }

