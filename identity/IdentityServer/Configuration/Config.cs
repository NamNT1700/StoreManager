using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.OpenApi.Writers;
using System.Collections.Generic;
using System.Security.Claims;

namespace Server.Identity.Configuration
{
    public class Config
    {
        private static string[] allowedScopes =
        {
            IdentityServerConstants.StandardScopes.OfflineAccess,
            IdentityServerConstants.StandardScopes.OpenId,
            
            "API",
            "BimService"
        };

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                //new IdentityResources.Profile(),
                new IdentityResources.Email(),
                //new IdentityResource("roles", new[] { "admin" }),

            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("API")
                {
                     Scopes = new List<string> { "API" },
                     UserClaims = { "role" },
                     ApiSecrets =
                     {
                        new Secret("TopSecret".Sha256()),
                     }
                },
                new ApiResource("BimService")
                {
                    Scopes = new List<string> { "BimService" },
                    ApiSecrets={new Secret("TopSecret".Sha256()) }
                },
                new ApiResource("Admin")
                {
                    Scopes = new List<string> { "Admin" },
                    ApiSecrets={new Secret("TopSecret".Sha256()) }
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScope()
        {
            return new List<ApiScope>
            {
               new ApiScope("API", "Main API Resource"),
               new ApiScope("BimService", "Main API Resource"),
               new ApiScope("Admin", "FullRoles")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                new Client{
                    ClientId = "ConstruxivViewer",
                    
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowOfflineAccess = true,
                    
                    RefreshTokenUsage = TokenUsage.ReUse,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    AllowAccessTokensViaBrowser = true,
                    ClientSecrets =
                    {
                        new Secret("ConstruxivViewersecret".Sha256())
                    },
                    AllowedScopes = { "API"},//allowedScopes
                   
                },
                // new Client{
                //    ClientId = "Admin",
                //    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                //    AllowOfflineAccess = true,
                //    AllowedCorsOrigins={"http://localhost/"},
                //    RefreshTokenUsage = TokenUsage.ReUse,
                //    UpdateAccessTokenClaimsOnRefresh = true,
                //    RefreshTokenExpiration = TokenExpiration.Sliding,
                //    AllowAccessTokensViaBrowser = true,
                //    ClientSecrets =
                //    {
                //        new Secret("Adminsecret".Sha256())
                //    },
                //    AllowedScopes = {
                //        // IdentityServerConstants.StandardScopes.Profile,
                //          IdentityServerConstants.StandardScopes.OpenId,
                //         "Admin" 
                //     }//allowedScopes
                //}
            };
        }
    }
}