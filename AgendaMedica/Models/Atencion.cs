using System;
using System.Collections.Generic;

namespace AgendaMedica.Models;

public partial class Atencion
{
    public int IdAte { get; set; }

    public string NombreAte { get; set; } = null!;

    public virtual ICollection<Agendar> Agendars { get; set; } = new List<Agendar>();
}
