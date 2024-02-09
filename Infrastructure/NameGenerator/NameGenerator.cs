using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class NameGenerator
    {
        public static string GenerateUnique()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

    }
}
