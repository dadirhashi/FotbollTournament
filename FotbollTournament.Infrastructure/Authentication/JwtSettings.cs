using System;
using System.Collections.Generic;
using System.Text;

namespace FotbollTournament.Infrastructure.Authentication
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; } = string.Empty;
    }
}
