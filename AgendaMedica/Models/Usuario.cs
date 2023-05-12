using System;
using System.Collections.Generic;

namespace AgendaMedica.Models;

public partial class Usuario
{
    public int IdUs { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public string NombreUs { get; set; } = null!;
}
