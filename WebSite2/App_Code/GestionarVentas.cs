using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de GestionarVentas
/// </summary>
public class GestionarVentas
{

    public List<Models.SP_ConsultarVentas_Result> ConsultarVentas()
    {
        List<Models.SP_ConsultarVentas_Result> LstVentas;
        try
        {
            using (Models.PCSWDBEntities ObjectBD = new Models.PCSWDBEntities())
            {
                LstVentas = ObjectBD.SP_ConsultarVentas().ToList();
            }
        }
        catch (Exception e)
        {
            string Mensaje = e.Message;
            LstVentas = null;
        }
        return LstVentas;
    }

    public List<Models.SP_ConsultarEstadisticasVentas_Result> ConsultarEstadisticas()
    {
        List<Models.SP_ConsultarEstadisticasVentas_Result> LstEstadisticas;
        try
        {
            using (Models.PCSWDBEntities ObjectBD = new Models.PCSWDBEntities())
            {
                LstEstadisticas = ObjectBD.SP_ConsultarEstadisticasVentas().ToList();     
            }
        }
        catch (Exception e)
        {
            string Mensaje = e.Message;
            LstEstadisticas = null;
        }
        return LstEstadisticas;
    }

    public bool GuardarVenta(int IdRegistroCompra)
    {
        Boolean Resultado = true;
        try
        {
            using (Models.PCSWDBEntities ObjectBD = new Models.PCSWDBEntities())
            {
                ObjectBD.SP_InsertarVentas(IdRegistroCompra);
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