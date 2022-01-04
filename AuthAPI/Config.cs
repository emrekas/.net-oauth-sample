using IdentityServer4.Models;
using System.Collections.Generic;

namespace AuthAPI
{
    public static class Config
    {
        #region Scopes
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("Employee.Write","Employee write permission"),
                new ApiScope("Employee.Read","Employee read permission")
            };
        }
        #endregion
        #region Resources
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("Employee"){ Scopes = { "Employee.Write", "Employee.Read" } },
            };
        }
        #endregion
        #region Clients
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                        {
                            ClientId = "EmployeeAPI",
                            ClientName = "EmployeeAPI",
                            ClientSecrets = { new Secret("employee".Sha256()) },
                            AllowedGrantTypes = { GrantType.ClientCredentials },
                            AllowedScopes = { "Employee.Write", "Employee.Read" }
                        }
            };
        }
        #endregion
    }
}
