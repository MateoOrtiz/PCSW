using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Vehiculo
/// </summary>
public class Vehiculo
{
    public int Id { get; set; }
    public string Modelo { get; set; }
    public string Marca { get; set; }
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }
}