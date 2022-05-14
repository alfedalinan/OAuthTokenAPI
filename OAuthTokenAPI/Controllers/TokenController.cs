using Microsoft.AspNetCore.Mvc;
using OAuthTokenAPI.Business.Entities;
using OAuthTokenAPI.Data.Interfaces;
using System.Threading.Tasks;

namespace OAuthTokenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [Route("generate")]
        [HttpPost]
        public async Task<ActionResult<TokenDetails>> Generate([FromBody] Payload payload)
        {
            if (ModelState.IsValid)
            {
                var tokens = _tokenService.Create(payload);

                return Ok(tokens);
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
