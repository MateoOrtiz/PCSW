using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de GestionarCompra
/// </summary>
public class GestionarCompra
{
    public List<Models.SP_ConsultarCompras_Result> ConsultarCompras()
    {
        List<Models.SP_ConsultarCompras_Result> LstCompras;
        try
        {
            using (Models.PCSWDBEntities ObjectBD = new Models.PCSWDBEntities())
            {
                LstCompras = ObjectBD.SP_ConsultarCompras().ToList();
            }
        }
        catch (Exception e)
        {
            string Mensaje = e.Message;
            LstCompras = null;
        }
        return LstCompras;
    }

    public bool GuardarCompra(String Identificacion, int IdVehiculo)
    {
        Boolean Resultado = true;
        try
        {
            using (Models.PCSWDBEntities ObjectBD = new Models.PCSWDBEntities())
            {
                ObjectBD.SP_InsertarCompra(Identificacion, IdVehiculo);
            }
        }
        catch (Exception e)
        {
            string Mensaje = e.Message;
            Resultado = false;
        }
        return Resultado;
    }

    public bool ActualizarEstadosCompra()
    {
        Boolean Resultado = true;
        try
        {
            using (Models.PCSWDBEntities ObjectBD = new Models.PCSWDBEntities())
            {
                List<Models.SP_ConsultarComprasVencidas_Result> lstComprasVencidas = ObjectBD.SP_ConsultarComprasVencidas().ToList();

                if (lstComprasVencidas.Count > 0) {
                    foreach (Models.SP_ConsultarComprasVencidas_Result RegistroCompra in lstComprasVencidas) {
                        ObjectBD.SP_ActualizarEstadoCompra(RegistroCompra.Id, RegistroCompra.IdVehiculo);
                    }
                }
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