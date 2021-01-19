using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BE.Domain.Dtos.Editora;
using BE.Domain.Data;
using BE.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BE.API.Controllers
{
    [Route("api/v1/editora")]
    public class EditoraController : ControllerBase
    {
        private readonly IRepository<Editora> _editoraRepository;
        public EditoraController(IMapper mapper, IRepository<Editora> editoraRepository) : base(mapper)
        {
            _editoraRepository = editoraRepository;
        }

        [HttpGet]
        [Authorize]
        [SwaggerOperation("Endpoint para listar todas as editoras.")]
        public async Task<ActionResult> Get()
        {
            var editorasDomain = await _editoraRepository.ObterTodos();

            var editoras = Mapper.Map<IList<ListEditoraDto>>(editorasDomain);

            return CustomResponse(editoras);
        }
    }
}