using OAuthTokenAPI.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuthTokenAPI.Data.Interfaces
{
    public interface ITokenService
    {
        TokenDetails Create(Payload payload);
    }
}
