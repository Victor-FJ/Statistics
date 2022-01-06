using CC.Storage.RavenDB;
using System;
using System.Collections.Generic;
using System.Linq;
using CC.DAL.Entities;
using DataAccess;

namespace DataAccess.Users.Models
{
    public class UserEntity : BaseEntity
    {
        public string LegacyId { get; set; }

        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public int CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FullPhoneNumber => $"{CountryCode}{PhoneNumber}";

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public bool ForcePasswordChange { get; set; } = false;
        public DateTime LastPasswordChangeDate { get; set; } = DateTime.UtcNow;

        public DateTime LastLoginDate { get; set; }

        public bool IsLockedOut { get; set; }
        public string LockedOutReason { get; set; }
        public DateTime? LockedOutDate { get; set; }

        public ValidationCode Validation { get; set; }
        public RefreshToken RefreshToken { get; set; }
        public ForgotPassword ForgotPassword { get; set; }

        public List<UserRole> Roles { get; set; } = new List<UserRole>();

        public Guid CurrentCompany { get; set; }
        public string CurrentCulture { get; set; }

        public bool SendSystemMessages { get; set; } = true;

        public bool IsExternal => Roles.Any(x => !string.IsNullOrWhiteSpace(x.UserExternalId));

        public int FailedLoginAttempts { get; set; }
    }
}
