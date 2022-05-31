using AutoMapper;
using Base.Contract;
using Base.Data;
using Base.DTO;
using Base.DTO.Organization;
using Base.Models;
using LicenseManager.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Identity.Repository
{
    public class OrganizationRepository : RepositoryBase<Organization>, IOrganizationRepository
    {
        IMapper _mapper;
        UserManager<User> _userManager;
        public OrganizationRepository(IdentityServerDbContext context,UserManager<User> userManager,IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ResultBool> Create(OrganizationCreateDTO orgDTO)
        {
            var org = await FindByCondition(x => x.Company_name.Equals(orgDTO.Company_name)).FirstOrDefaultAsync();
            if (org != null)
                return new ResultBool() { result = false, msg = "this company is already exist" };
            org = _mapper.Map<Organization>(orgDTO);
            Create(org);
            await SaveAsync();
            return new ResultBool() { result = true, msg = "Create successful!" };
        }

        public async Task<ResultErrCode<bool>> CreateMany(IEnumerable<OrganizationCreateDTO> orgDTOs)
        {
            //validate
            var anyDuplicate = orgDTOs.ToList().GroupBy(x => x.Company_name).Any(g => g.Count() > 1);
            if (anyDuplicate == true)
                return new ResultErrCode<bool>() { ErrCode = 1, data = false, msg = "this list contain duplicate company name" };
            //Create
            var org = await FindByCondition(x => orgDTOs.ToList().ConvertAll(o => o.Company_name).Contains(x.Company_name)).FirstOrDefaultAsync();
            if (org != null)
                return new ResultErrCode<bool>() { ErrCode = 2, data = false, msg = "this list contain any company is already exist" };
            var orgs = _mapper.Map<IEnumerable<Organization>>(orgDTOs);
            //orgs.ToList().ForEach(x => {
            //    x.Users.Add(new User()
            //    {
            //        UserName = $"{x.Company_name}_Admin",
            //        CompanyName = x.Company_name
            //    });

            //});
            CreateMany(orgs);
            await SaveAsync();
            return new ResultErrCode<bool>() {ErrCode = 0, data = true, msg = "Create successful!" };
        }

        public async Task<ResultBool> Delete(Guid orgId)
        {
            var org = await FindByCondition(x => x.Guid.Equals(orgId)).FirstOrDefaultAsync();
            if (org == null)
                return new ResultBool() { result = false, msg = "this company is not exist" };
            Delete(org);
            await SaveAsync();
            return new ResultBool() { result = true, msg = "Delete successful!" };
        }

        public async Task<ResultBool> DeleteMany(IEnumerable<Guid> orgIds)
        {
            var orgs = await FindByCondition(x => orgIds.ToList().Contains(x.Guid)).ToListAsync();
            if (orgs?.Count() == 0)
                return new ResultBool() { result = false, msg = "list of companys is not exist" };
            DeleteMany(orgs);
            await SaveAsync();
            return new ResultBool() { result = true, msg = "Delete successful!" };
        }

        public async Task<ResultErrCode<IEnumerable<OrganizationGetDTO>>> GetAllOrganization()
        {
            var orgs = await FindAll().ToListAsync();
            if (orgs?.Count != 0)
            {
                var orgDTOs = _mapper.Map<IEnumerable<OrganizationGetDTO>>(orgs);
                return new ResultErrCode<IEnumerable<OrganizationGetDTO>>() { ErrCode = 0, data = orgDTOs, msg = "Data Organizations!" };
            }
            return new ResultErrCode<IEnumerable<OrganizationGetDTO>>() { ErrCode = 1, msg = "Data Organizations null or Empty!" };
        }

        public async Task<ResultErrCode<OrganizationGetDTO>> GetOrganizationById(Guid orgId)
        {
            var org = await FindByCondition(x => x.Guid.Equals(orgId)).FirstOrDefaultAsync();
            if (org != null)
            {
                var orgDTOs = _mapper.Map<OrganizationGetDTO>(org);
                return new ResultErrCode<OrganizationGetDTO>() { ErrCode = 0, data = orgDTOs, msg = "Data Organizations!" };
            }
            return new ResultErrCode<OrganizationGetDTO>() { ErrCode = 1, msg = "Data Organizations null or Empty!" };
        }

        public async Task<ResultErrCode<IEnumerable<OrganizationGetDTO>>> GetAllOrganizationByName(string company_name)
        {
            var orgs = await FindByCondition(x => x.Company_name.Equals(company_name)).ToListAsync();
            if (orgs?.Count != 0)
            {
                var orgDTOs = _mapper.Map<IEnumerable<OrganizationGetDTO>>(orgs);
                return new ResultErrCode<IEnumerable<OrganizationGetDTO>>() { ErrCode = 0, data = orgDTOs, msg = "Data Organizations!" };
            }
            return new ResultErrCode<IEnumerable<OrganizationGetDTO>>() { ErrCode = 1, msg = "Data Organizations null or Empty!" };
        }

        public async Task<ResultBool> Update(OrganizationUpdateDTO organizationUpdateDTO, Guid orgId)
        {
            var org = await FindByCondition(x => x.Guid.Equals(orgId)).FirstOrDefaultAsync();
            if (org == null)
                return new ResultBool() { result = false, msg = "this company is not exist" };
            Organization orgDTO = _mapper.Map<OrganizationUpdateDTO, Organization>(organizationUpdateDTO,org);
            Update(orgDTO);
            await SaveAsync();
            return new ResultBool() { result = true, msg = "Update successful!" };
        }

        public async Task<ResultBool> UpdateMany(IEnumerable<OrganizationUpdateDTO> organizationUpdateDTOs)
        {
            var orgs = await FindByCondition(x => organizationUpdateDTOs.ToList().ConvertAll(y => y.Guid).Contains(x.Guid)).ToListAsync();
            if (orgs?.Count() == 0)
                return new ResultBool() { result = false, msg = "list of companys is not exist" };
            IEnumerable<Organization> orgUpdates = _mapper.Map<IEnumerable<OrganizationUpdateDTO>, IEnumerable<Organization>>(organizationUpdateDTOs, orgs);
            UpdateMany(orgUpdates);
            await SaveAsync();
            return new ResultBool() { result = true, msg = "Update successful!" };
        }

        public async Task<ResultErrCode<bool>> AddAdminUserToOrg(Guid orgId, string userid)
        {
           var org = await FindByCondition(x => x.Guid.Equals(orgId)).Include(x =>x.Users).FirstOrDefaultAsync();
            if (org == null)
                return new ResultErrCode<bool>() { ErrCode = 1, msg = "Organizations is not exist!" };
            if (org.Users.Any(x => x.Id.Equals(userid)))
                return new ResultErrCode<bool>() { ErrCode = 2, msg = "user is already exist in this organization!" };
            User user = _userManager.FindByIdAsync(userid).Result;
            if(user == null)
                return new ResultErrCode<bool>() { ErrCode = 3, msg = "user is not exist!" };

            if (org.Users?.Count != 0)
                return new ResultErrCode<bool>() { ErrCode = 4, msg = "Can't add more user with role Admin!" };
            
            await _userManager.AddToRoleAsync(user, "Admin");
            org.Users.Add(user);
            Update(org);
            await SaveAsync();
            return new ResultErrCode<bool>() { ErrCode = 0, msg = "Add user successful!" };
        }

        public async Task<ResultErrCode<bool>> AddUserToOrg(Guid orgId, string userid)
        {
            var org = await FindByCondition(x => x.Guid.Equals(orgId)).Include(x => x.Users).FirstOrDefaultAsync();
            if (org == null)
                return new ResultErrCode<bool>() { ErrCode = 1, msg = "Organizations is not exist!" };
            if (org.Users.Any(x => x.Id.Equals(userid)))
                return new ResultErrCode<bool>() { ErrCode = 2, msg = "User is already exist in this organization!" };
            User user = _userManager.FindByIdAsync(userid).Result;
            if (user == null)
                return new ResultErrCode<bool>() { ErrCode = 3, msg = "User is not exist!" };
            org.Users.Add(user);
            Update(org);
            await SaveAsync();
            return new ResultErrCode<bool>() { ErrCode = 0, msg = "Add user successful!" };
        }
    }
}