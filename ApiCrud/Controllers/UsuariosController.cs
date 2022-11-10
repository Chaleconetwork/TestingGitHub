using ApiCrud.Interfaces;
using ApiCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public readonly IUsuarioInterface _usuarioInterface;

        public UsuariosController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<Usuario>>> GetAll()
        {
            var getAll = await _usuarioInterface.GetAll();
            return Ok(getAll);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            var getById = await _usuarioInterface.GetById(id);
            return Ok(getById);
        }

        [HttpPost("insertar")]
        public async Task<ActionResult<Usuario>> InsertUser(Usuario usuario)
        {
            var insertUser = await _usuarioInterface.InsertUser(usuario);
            return Ok(insertUser);
        }
    }
}
