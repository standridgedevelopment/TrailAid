using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Front_End_Console_App.Models.Register
{
    public class TokenCreate
    {
        public string grant_type = "password";
        public string username { get; set; }
        public string password { get; set; }
    }
}
