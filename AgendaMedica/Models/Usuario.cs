using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace AgendaMedica.Models;

public partial class Usuario
{
    public int IdUs { get; set; }

    public string NombreUs { get; set; } = null!;
    
    public string Usuario1 { get; set; } = null!;
    
    public string Clave { get; set; } = null!;
}
