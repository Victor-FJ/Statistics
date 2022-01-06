using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Users.Models
{
    [Serializable]
    public class RefreshToken
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
