using Microsoft.EntityFrameworkCore.Storage;
using Base.Contract;
using Base.Data;
using Server.Identity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Base.Models;

namespace Base.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;
        public RepositoryWrapper(IApplicationBuilder app)
        {
        }
        private IdentityServerDbContext _context;

        private ILicenseRepository _DataLicenseRepo;
        private IOrganizationRepository _DataOrganizationRepo;
        private IRightClaimsRepository _DataRightClaimsRepo;
        private ILicenseTypeRepository _DataLicenseTypeRepo;
        private IProductRepository _DataProductRepo;
        private IUserPreferenceSettingsRepository _DataUserPreferenceSettingsRepository;

        public IUserPreferenceSettingsRepository DataUserPreferenceSettingsRepository
        {
            get
            {
                if (_DataUserPreferenceSettingsRepository == null)
                {
                   _DataUserPreferenceSettingsRepository = new UserPreferenceSettingsRepository(_context, _mapper);
                }
                return _DataUserPreferenceSettingsRepository;
            }
        }
        public ILicenseTypeRepository DataLicenseTypeRepo
        {
            get
            {
                if (_DataLicenseTypeRepo == null) {
                    _DataLicenseTypeRepo = new LicenseTypeRepository(_context);
                }
                return _DataLicenseTypeRepo;
            }
        }

        public IProductRepository DataProductRepo
        {
            get
            {
                if (_DataProductRepo == null) {
                    _DataProductRepo = new ProductRepository(_context);
                }
                return _DataProductRepo;
            }
        }

        public ILicenseRepository DataLicenseRepo
        {
            get
            {
                if (_DataLicenseRepo == null) {
                    _DataLicenseRepo = new LicenseRepository(_context);
                }
                return _DataLicenseRepo;
            }
        }

        public IOrganizationRepository DataOrganizationRepo
        {
            get
            {
                if (_DataOrganizationRepo == null) {
                    _DataOrganizationRepo = new OrganizationRepository(_context, _userManager, _mapper);
                }
                return _DataOrganizationRepo;
            }
        }

        public IRightClaimsRepository DataRightClaimsRepo
        {
            get
            {
                if (_DataRightClaimsRepo == null) {
                    _DataRightClaimsRepo = new RightClaimsRepository(_context);
                }
                return _DataRightClaimsRepo;
            }
        }

        public RepositoryWrapper(IdentityServerDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IDbContextTransaction> StartTransaction()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }
        public void SetMapper(IMapper mapper)
        {
            _mapper = mapper;
        }
        public void SetUserManager(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
    }
}