using System;
using System.Collections.Generic;
using System.Text;

namespace FotbollTournament.Application.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
       public string Username { get; set; }
       public IEnumerable<string> Roles { get; set; }

        public AuthResponseDto(string token, string username, IEnumerable<string> role)
        {
            Token = token;
            Username = username;
            Roles = role;
        }
    }
}
