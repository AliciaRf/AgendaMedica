using System;
using System.Collections.Generic;

namespace AgendaMedica.Models;

public partial class Paciente
{
    public int IdPac { get; set; }

    public string RutPac { get; set; } = null!;

    public string NombrePac { get; set; } = null!;

    public string ApellidosPac { get; set; } = null!;

    public int EdadPac { get; set; }

    public string FonoPac { get; set; } = null!;

    public string DireccionPac { get; set; } = null!;

    public string? EmailPac { get; set; }
}
