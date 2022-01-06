using System;
using System.Collections.Generic;

namespace DataAccess.Users.Models
{
    public class UserRole
    {
        public Guid RoleId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid ThirdPartyId { get; set; } = Guid.Empty;
        public string UserExternalId { get; set; }
        public bool IsActive { get; set; } = true;

        public UserRole()
        {
            
        }

        public UserRole(Guid roleId, Guid companyId)
        {
            RoleId = roleId;
            CompanyId = companyId;
        }

        public static IEqualityComparer<UserRole> UserRoleComparer { get; } = new UserRoleEqualityComparer();

        private sealed class UserRoleEqualityComparer : IEqualityComparer<UserRole>
        {
            public bool Equals(UserRole x, UserRole y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.RoleId.Equals(y.RoleId) && x.CompanyId.Equals(y.CompanyId) && x.ThirdPartyId.Equals(y.ThirdPartyId) && x.UserExternalId == y.UserExternalId && x.IsActive == y.IsActive;
            }

            public int GetHashCode(UserRole obj)
            {
                unchecked
                {
                    var hashCode = obj.RoleId.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.CompanyId.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.ThirdPartyId.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.UserExternalId != null ? obj.UserExternalId.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ obj.IsActive.GetHashCode();
                    return hashCode;
                }
            }
        }
    }
}
