using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace AgendaMedica.Models;

public partial class Usuario
{
    public int IdUs { get; set; }
    [Required, MinLength(1, ErrorMessage = "La {0} debe tener al menos {1} caracteres"), MaxLength(200)]
    public string NombreUs { get; set; } = null!;
    public string Usuario1 { get; set; } = null!;
    public string Clave { get; set; } = null!;
}
