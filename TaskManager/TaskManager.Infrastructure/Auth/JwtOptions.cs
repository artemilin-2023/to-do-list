using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Infrastructure.Auth
{
    public class JwtOptions
    {
        public required string SecretKey { get; set; }
        public int ExpiresHours { get; set; }
    }
}
