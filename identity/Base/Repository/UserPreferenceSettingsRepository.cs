using AutoMapper;
using Base.Contract;
using Base.Data;
using Base.DTO;
using Base.Models;
using LicenseManager.DTO;
using Microsoft.EntityFrameworkCore;
using Server.Identity.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Base.Repository
{
    class UserPreferenceSettingsRepository : RepositoryBase<UserPreferenceSettings>, IUserPreferenceSettingsRepository
    {
        IMapper _mapper;
        public UserPreferenceSettingsRepository(IdentityServerDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<ResultBool> Create(UserPreferenceSettingsDTO userPreferenceSettingsDTO)
        {
            var userSetting = await FindByCondition(x => x.UserGuid.Equals(userPreferenceSettingsDTO.UserGuid) &&
                                                   x.ProductId.Equals(userPreferenceSettingsDTO.ProductId)).FirstOrDefaultAsync();
            if (userSetting != null)
                return new ResultBool() { result = false, msg = "setting by this user and product is already exist" };
            var UserPreferenceSettings = _mapper.Map<UserPreferenceSettings>(userPreferenceSettingsDTO);
            Create(UserPreferenceSettings);
            await SaveAsync();
            return new ResultBool() { result = true, msg = "Create successful!" };
        }

        public async Task<ResultBool> Delete(string userId, Guid productId)
        {
            var userSetting = await FindByCondition(x => x.UserGuid.Equals(userId) &&
                                                   x.ProductId.Equals(productId)).FirstOrDefaultAsync();
            if (userSetting == null)
                return new ResultBool() { result = false, msg = "setting by this user and product is not exist" };
            Delete(userSetting);
            await SaveAsync();
            return new ResultBool() { result = true, msg = "Create successful!" };
        }

        public async Task<ResultErrCode<IEnumerable<string>>> GetAllConfigByUserId(string userId)
        {
            var userSettings = await FindByCondition(x => x.UserGuid.Equals(userId)).ToListAsync();
            if(userSettings?.Count != 0)
                return new ResultErrCode<IEnumerable<string>>() { ErrCode = 0,data = userSettings.ConvertAll(x => x.Settings),  msg = "Setting datas!" };
            return new ResultErrCode<IEnumerable<string>>() { ErrCode = 1, data = null , msg = "Setting datas null or empty!" };

        }

        public async Task<ResultErrCode<string>> GetConfigByUserIdAndProductId(string userId, Guid productId)
        {
            var userSetting = await FindByCondition(x => x.UserGuid.Equals(userId) &&
                                                          x.ProductId.Equals(productId)).FirstOrDefaultAsync();
            if (userSetting != null)
                return new ResultErrCode<string>() { ErrCode = 0, data = userSetting.Settings, msg = "Setting data!" };
            return new ResultErrCode<string>() { ErrCode = 1, data = null, msg = "Setting data is null!" };
        }

        public async Task<ResultBool> Update(UserPreferenceSettingsUpdateDTO userPreferenceSettingsDTO, string userGuid, Guid productId)
        {
            var userSetting = await FindByCondition(x => x.UserGuid.Equals(userGuid) &&
                                                  x.ProductId.Equals(productId)).FirstOrDefaultAsync();
            if (userSetting != null)
                return new ResultBool() { result = false, msg = "setting by this user and product is already exist" };
            userSetting.Settings = userPreferenceSettingsDTO.Settings;
            Update(userSetting);
            await SaveAsync();
            return new ResultBool() { result = true, msg = "Update successful!" };
        }
    }
}
