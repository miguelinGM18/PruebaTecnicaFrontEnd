using ApiUsers.Data.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Usuarios.Business;

namespace Usuarios.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(UsuarioDto request)
        {
            UsuarioBusiness business = new UsuarioBusiness();
            GeneralResponse<Object> response = business.PostUsuario(request);
            return StatusCode(response.Code, response);
        }
    }
}
