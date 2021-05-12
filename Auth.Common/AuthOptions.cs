using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Auth.Common
{
    public class AuthOptions
    {
        public string Issuer { get; set; } // тот кто сгенерировал
        public string Audience { get; set; } // для кого сгенерировал
        public string Secret { get; set; } // секретная стока для генерации ключа
        public int TokenLifetime { get; set; }
        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}
