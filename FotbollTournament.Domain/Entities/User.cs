using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotbollTournament.Domain.Entities
{
    public class User
    { 
        public int Id { get; set; }
        public string Password { get; set; } = string.Empty;
        public string UserName { get; set; }    = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "User";

        public bool VerifyPassword(string input)
        {
            return Password == input;
        }

    }
}
