using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Users.Models
{
    public class ValidationCode
    {
        public string Code { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
