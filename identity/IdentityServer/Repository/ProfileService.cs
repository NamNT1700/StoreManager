//using IdentityModel;
//using IdentityServer4.Extensions;
//using IdentityServer4.Models;
//using IdentityServer4.Services;
//using Base.Models;
//using Microsoft.AspNetCore.Identity;
//using Base.Contract;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using IdentityServer4;
//using Newtonsoft.Json;
//using AutoMapper;
//using Server.Identity.DTO;
//using IdentityServer4.Events;
//using Server.Identity.Even;
//using Server.Identity.Util;

//namespace Server.Identity.Repository
//{
//    public class ProfileService : IProfileService
//    {
//        protected UserManager<User> _userManager;
//        protected IRepositoryWrapper _RepositoryWrapper;
//        protected IMapper _mapper;
//        private IEventService _eventService;

//        public ProfileService(UserManager<User> userManager, IRepositoryWrapper repositoryWrapper, IMapper mapper, IEventService eventService)
//        {
//            _userManager = userManager;
//            _RepositoryWrapper = repositoryWrapper;
//            _mapper = mapper;
//            _eventService = eventService;
//        }

//        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
//        {
//            //>Processing
//            var user = await _userManager.GetUserAsync(context.Subject);

//            UserDTO userDTO = _mapper.Map<UserDTO>(user);
//            Claim userclaim = new Claim(IdentityServerConstants.StandardScopes.Profile,
//                                        JsonConvert.SerializeObject(userDTO, Formatting.None,
//                                        new JsonSerializerSettings
//                                        {
//                                            NullValueHandling = NullValueHandling.Ignore
//                                        }));

//            List<Claim> claims = new List<Claim>();
//            if (userclaim != null)
//                claims.Add(userclaim);

//            string clientID = context.Client.ClientId;
//            License license = await _RepositoryWrapper.DataLicenseRepo.FindLicenseByUserId(user.Id, clientID);
//            if(license != null)
//            {              
//                IEnumerable<ProductClaim> productClaims = license.LicenseType.LicenseTypeProductClaims.ToList().ConvertAll(x => x.ProductClaim);

//                IEnumerable<LicenseClaims> licenseClaims = license.LicenseClaims.ToList();

//                if (productClaims != null)
//                    claims = productClaims.ToList().ConvertAll(x => new Claim(x.ClaimType, x.ClaimValue));
//                if (userclaim != null)
//                    claims.Add(userclaim);

//                DateTime OfflineExpDate = DateTime.Now.AddDays(license.LicenseType.OfflineRange);
//                DateTime LicenseExpridate = license.Expridate;

//                var OfflineExpDateTick = Common.ToUnixTimestamp(OfflineExpDate);
//                var LicenseExpridateTick = Common.ToUnixTimestamp(LicenseExpridate);
//                claims.Add(new Claim("OfflineExp", OfflineExpDateTick.ToString()));
//                claims.Add(new Claim("LicenseExp", LicenseExpridateTick.ToString()));

//                if (licenseClaims != null)
//                    claims.Concat(licenseClaims.ToList().ConvertAll(x => new Claim(x.Type, x.Value)));
//            }
//            context.IssuedClaims.AddRange(claims);
//            //await _eventService.RaiseAsync(new LicenseServiceFailure("License is null"));
//        }

//        public async Task IsActiveAsync(IsActiveContext context)
//        {
//            //>Processing
//            var user = await _userManager.GetUserAsync(context.Subject);
//            context.IsActive = (user != null) && user.IsActive;
//        }
//    }
//}