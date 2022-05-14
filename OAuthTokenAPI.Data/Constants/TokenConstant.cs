using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuthTokenAPI.Data.Constants
{
    public static class TokenConstant
    {
        public static readonly string AccessSecret = "ec97f5cd31ea66ad";
        public static readonly string RefreshSecret = "84baa5f16b796ffc";
        public static readonly int AccessExpiry = 43200;
        public static readonly int RefreshExpiry = 1296000;
    }
}
