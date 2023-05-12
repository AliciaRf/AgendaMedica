using System;
using System.Collections.Generic;

namespace AgendaMedica.Models;

public partial class Agendar
{
    public int IdAg { get; set; }

    public DateTime FechaAg { get; set; }

    public TimeSpan HoraAg { get; set; }

    public int IdEsp { get; set; }

    public int IdAte { get; set; }

    public string RutPac { get; set; } = null!;

    public string NomPac { get; set; } = null!;

    public string ApePac { get; set; } = null!;

    public int IdPrev { get; set; }

    public string FonoPac { get; set; } = null!;

    public string DirPac { get; set; } = null!;

    public int IdSector { get; set; }

    public virtual Atencion IdAteNavigation { get; set; } = null!;

    public virtual Especialidad IdEspNavigation { get; set; } = null!;

    public virtual Prevision IdPrevNavigation { get; set; } = null!;

    public virtual Sector IdSectorNavigation { get; set; } = null!;

    public virtual Paciente RutPacNavigation { get; set; } = null!;
}
