using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BE.API.Dtos.Auth;
using BE.API.Extensions;
using BE.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BE.API.Controllers
{
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _userSign;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppSettings _appSettings;
        public AuthController(IMapper mapper, SignInManager<ApplicationUser> userSign, UserManager<ApplicationUser> userManager, IOptions<AppSettings> appSettings) : base(mapper)
        {
            _userSign = userSign;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost("Autenticar")]
        public async Task<ActionResult> Login(UsuarioLoginDto dto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _userSign.PasswordSignInAsync(dto.Email, dto.Senha, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(await GerarJwt(dto.Email));
            }

            if (result.IsLockedOut)
            {
                AdicionaErroProcessamento("Usuário bloqueado temporariamente.");
                return CustomResponse();
            }

            AdicionaErroProcessamento("Usuário ou senha incorretos.");
            return CustomResponse();

        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<UsuarioRepostaLoginDto> GerarJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);

            var identityClaims = await ObterClaimsUsuario(claims, user);
            var encodedToken = CodificarToken(identityClaims);

            return ObterRespostaToken(encodedToken, user, claims);

        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ClaimsIdentity> ObterClaimsUsuario([FromQuery] ICollection<Claim> claims, ApplicationUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            foreach (var role in userRoles)
            {
                claims.Add(new Claim("Role", role));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            return identityClaims;
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public string CodificarToken(ClaimsIdentity identityClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public UsuarioRepostaLoginDto ObterRespostaToken(string encodedToken, ApplicationUser user, [FromQuery] IEnumerable<Claim> claims) => new UsuarioRepostaLoginDto
        {
            AccessToken = encodedToken,
            ExpireIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
            UsuarioToken = new UsuarioTokenDto
            {
                Id = user.Id,
                Email = user.Email,
                Claims = claims.Select(o => new UsuarioClaimDto { Type = o.Type, Value = o.Value })
            }
        };
        [ApiExplorerSettings(IgnoreApi = true)]
        private static long ToUnixEpochDate(DateTime date) => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}