using System;
using System.Collections.Generic;

namespace AgendaMedica.Models;

public partial class Especialidad
{
    public int IdEsp { get; set; }

    public string Especialidad1 { get; set; } = null!;

    public virtual ICollection<Agendar> Agendars { get; set; } = new List<Agendar>();
}
