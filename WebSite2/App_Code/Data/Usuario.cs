using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Usuario
/// </summary>
public class Usuario
{
    public string User { get; set; }
    public string Password { get; set; }
    public int Rol { get; set; }
    public string RolName { get; set; }
    public string Identificacion { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Correo { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string NroCuenta { get; set; }
    public bool StatusLogin { get; set; }

}