using AutoMapper;
using Base.DTO;
using Base.Models;
using LicenseManager.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Base.Contract
{
    public interface IUserPreferenceSettingsRepository : IRepositoryBase<UserPreferenceSettings>
    {
        Task<ResultBool> Create(UserPreferenceSettingsDTO userPreferenceSettingsDTO);
        Task<ResultBool> Update(UserPreferenceSettingsUpdateDTO userPreferenceSettingsDTO, string userGuid, Guid productId);
        Task<ResultErrCode<IEnumerable<string>>> GetAllConfigByUserId(string userId);
        Task<ResultErrCode<string>> GetConfigByUserIdAndProductId(string userId,Guid productId);
        Task<ResultBool> Delete(string userId, Guid productId);

    }
}
