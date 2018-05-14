using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.EntityClient;

public class GestionarVehiculos
{
    public List<Vehiculo> ConsultarVehiculos()
    {
        List<Vehiculo> LstVehiculo = new List<Vehiculo>();
        try
        {
            GestionarCompra GestCompra = new GestionarCompra();
            //Actualizar Estado Compras
            GestCompra.ActualizarEstadosCompra();

            using (Models.PCSWDBEntities ObjBDPCSW = new Models.PCSWDBEntities())
            {
                List<Models.SP_ConsultarVehiculo_Result> ListaVehiculos = ObjBDPCSW.SP_ConsultarVehiculo(null).ToList();
                if (ListaVehiculos.Count > 0)
                {
                    foreach (Models.SP_ConsultarVehiculo_Result Vehiculo in ListaVehiculos)
                    {
                        Vehiculo vehiculoIndividual = new Vehiculo
                        {
                            Id = Vehiculo.Id,
                            Modelo = Vehiculo.Modelo,
                            Marca = Vehiculo.Marca,
                            Cantidad = Vehiculo.Cantidad,
                            Precio = Vehiculo.Precio
                        };
                        LstVehiculo.Add(vehiculoIndividual);
                    }
                }
            }
        }
        catch (Exception e)
        {
            return null;
        }
        return LstVehiculo;
    }

    public bool ActualizarVehiculo(int Id, int Cantidad)
    {
        Boolean Resultado = true;
        try
        {
            using (Models.PCSWDBEntities ObjectBD = new Models.PCSWDBEntities())
            {
                ObjectBD.SP_ActualizarVehiculos(Id, Cantidad);
            }
        }
        catch (Exception e)
        {
            string Mensaje = e.Message;
            Resultado = false;
        }
        return Resultado;
    }

}