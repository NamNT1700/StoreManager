﻿using Entities;
using Entities.Models;
using Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class EmployeesRepository: RepositoryBase<Employees>, IEmployeesRepository
    {
        public EmployeesRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
