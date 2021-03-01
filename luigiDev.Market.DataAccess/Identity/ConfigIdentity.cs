using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace luigiDev.Market.DataAccess.Identity
{
    public class ConfigIdentity
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

        public static IEnumerable<ApiResource> GetApiResources() => new List<ApiResource>
        {
            new ApiResource("MarketApi", "Market Api")
        };

        public static IEnumerable<Client> GetClients() => new List<Client>
        {
            new Client
            {
                ClientId = "MarketApi",
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "MarketApi" },
                AllowedGrantTypes = GrantTypes.Implicit,
                AllowAccessTokensViaBrowser = true,
                AllowedCorsOrigins = { "https://localhost:5001" }
            }
        };
    }
}
