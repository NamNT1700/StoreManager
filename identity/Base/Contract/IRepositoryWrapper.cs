using AutoMapper;
using Base.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Contract
{
    public interface IRepositoryWrapper
    {
        public ILicenseRepository DataLicenseRepo { get; }
        public IOrganizationRepository DataOrganizationRepo { get; }
        public IRightClaimsRepository DataRightClaimsRepo { get; }
        public ILicenseTypeRepository DataLicenseTypeRepo { get; }
        public IProductRepository DataProductRepo { get; }
        public IUserPreferenceSettingsRepository DataUserPreferenceSettingsRepository { get; }

        public Task<IDbContextTransaction> StartTransaction();

        public void CommitTransaction();

        public void RollbackTransaction();

        public Task SaveChangesAsync();

        public void SetMapper(IMapper mapper);
        public void SetUserManager(UserManager<User> userManager);
    }
}