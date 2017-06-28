using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer.IdentityServices
{
    public static class ConfigServer
    {
        public static List<TestUser> GetUSers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "SID123",
                    Username = "chefy",
                    Password = "P@ssword",
                    Claims =
                    {
                        new Claim("UserType", "Provider")
                    }
                },
                new TestUser
                {
                     SubjectId = "SID456",
                     Username = "pelos65",
                     Password = "P@ssword",
                     Claims =
                    {
                        new Claim("USerType", "Reviwer")
                    }
                }
            };
        }

        public static List<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("reviews.api"),
                new ApiResource("reservations.api")
            };
        }

        public static List<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "reviews_client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientName = "Postman Client",
                    AllowedScopes = { "reviews.api" },
                    ClientSecrets =
                    {
                        new Secret("secret123".Sha256())
                    },
                    Claims =
                    {
                        new Claim("ClientType", "Mobil")
                    }
                }
            };
        }
    }
}
