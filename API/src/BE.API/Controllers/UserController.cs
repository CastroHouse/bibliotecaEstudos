using System.Threading.Tasks;
using AutoMapper;
using BE.Domain.Dtos.Usuarios;
using BE.Domain.Entities;
using BE.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BE.API.Controllers
{
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUsuarioRepository _usuarioRepository;
        public UserController(IMapper mapper, UserManager<ApplicationUser> userManager, IUsuarioRepository usuarioRepository) : base(mapper)
        {
            _userManager = userManager;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost("nova-conta")]
        [AllowAnonymous]
        [SwaggerOperation("Endpoint para criar uma novo usuario")]
        public async Task<ActionResult> Registrar(CreateUsuarioDto dto)
        {
            if(!ModelState.IsValid) return CustomResponse(ModelState);
            
            var userLogin = new ApplicationUser
            {
                Email = dto.Email,
                UserName = dto.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(userLogin, dto.Senha);

            if (result.Succeeded)
            {
                var usuario = Mapper.Map<Usuario>(dto);
                usuario.AddUser(userLogin);

                dto.Endereco.usuarioId = usuario.Id;
                var emdereco = Mapper.Map<Endereco>(dto.Endereco);

                await _usuarioRepository.Adicionar(usuario);
                await _usuarioRepository.UnitOfWork.Commit();

                return CustomResponse();
            }
            foreach (var erro in result.Errors)
            {
                AdicionaErroProcessamento(erro.Description);
            }

            return CustomResponse();
        }
    }
}