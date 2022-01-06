using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Users.Models
{
    public class ForgotPassword
    {
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
