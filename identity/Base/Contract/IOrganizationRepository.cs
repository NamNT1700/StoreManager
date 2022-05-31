using Base.DTO;
using Base.DTO.Organization;
using Base.Models;
using LicenseManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Contract
{
    public interface IOrganizationRepository : IRepositoryBase<Organization>
    {
        Task<ResultBool> Create(OrganizationCreateDTO userPreferenceSettingsDTO);
        Task<ResultErrCode<bool>> CreateMany(IEnumerable<OrganizationCreateDTO> userPreferenceSettingsDTOs);
        Task<ResultBool> Update(OrganizationUpdateDTO  organizationUpdateDTO, Guid orgId);
        Task<ResultBool> UpdateMany(IEnumerable<OrganizationUpdateDTO> organizationUpdateDTOs);
        Task<ResultErrCode<IEnumerable<OrganizationGetDTO>>> GetAllOrganization();
        Task<ResultErrCode<IEnumerable<OrganizationGetDTO>>> GetAllOrganizationByName(string company_name);
        Task<ResultErrCode<OrganizationGetDTO>> GetOrganizationById(Guid orgId);
        Task<ResultBool> Delete(Guid orgId);
        Task<ResultBool> DeleteMany(IEnumerable<Guid> orgIds);
        Task<ResultErrCode<bool>> AddUserToOrg(Guid orgId, string userid);
        Task<ResultErrCode<bool>> AddAdminUserToOrg(Guid orgId, string userid);

    }
}