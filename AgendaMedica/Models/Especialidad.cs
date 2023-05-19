using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace AgendaMedica.Models;

public partial class Especialidad
{
    public int IdEsp { get; set; }

    [Required, MinLength(3, ErrorMessage ="La {0} debe tener minimo {1} caracteres"),  MaxLength(50)]
    public string Especialidad1 { get; set; } = null!;

    public virtual ICollection<Agendar> Agendars { get; set; } = new List<Agendar>();
}
