using System;
using System.Collections.Generic;

namespace Usuarios.DataAccess.DataAccess;

public partial class UsersTestMiguelEmanuelSanchezRamo
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string ApellidoPaterno { get; set; } = null!;

    public string? ApellidoMaterno { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public string Email { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }
}
