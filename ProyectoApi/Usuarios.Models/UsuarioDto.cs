using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsers.Data.Dtos
{
    public class UsuarioDto
    {        
        public string Nombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public DateOnly FechaNacimiento { get; set; }        
        public string Email { get; set; } = null!;
        public string Telefono { get; set; }        
    }
}
