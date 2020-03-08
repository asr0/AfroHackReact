using AfroHackReact.Model;
using AfroHackReact.Validator;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AfroHackReact.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : Controller
    {
        private readonly IRepository _repository;

        public ApiController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Usuario/Cadastrar")]
        public IActionResult Cadastrar([FromBody]Usuario Usuario)
        {
            UsuarioValidator validator = new UsuarioValidator();

            var result = validator.Validate(Usuario);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            _repository.CriarUsuario(Usuario);

            return Ok();
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] Login login)
        {
            LoginValidator rules = new LoginValidator();

            var result = rules.Validate(login);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var usuario = _repository.Login(login.Email, login.Senha);

            if (usuario == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(usuario);
            }
        }

        [HttpGet("Usuario/Mentores")]
        public IActionResult ListarMentores([FromQuery]int CodigoUsuario)
        {
            if (CodigoUsuario <= 0)
            {
                return BadRequest();
            }
            var listaMentores = _repository.ListarMentores(CodigoUsuario);

            if (listaMentores == null)
            {
                return NoContent();
            }

            return Ok(listaMentores);
        }

        [HttpGet("HorariosDisponiveis")]
        public IActionResult HorariosDisponiveis()
        {
            var horarios = _repository.HorariosDisponiveis();

            if (horarios == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(horarios);
            }
        }
    }
}