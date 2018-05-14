using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pedidos : System.Web.UI.Page
{

    public static class Globales
    {
        public static string UserID = System.Web.HttpContext.Current.Session["sessionString"] as String;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        GestionarUsuario GestUser = new GestionarUsuario();

        LblResultado.Text = "";
        LblTotalVentas.Text = "0";
        LblVehiculosVendidos.Text = "0";

        if (GestUser.ValidateSesion())
        {

            GestionarVentas GestVentas = new GestionarVentas();
            List<Models.SP_ConsultarEstadisticasVentas_Result> LstEstadisticas = GestVentas.ConsultarEstadisticas();
            GridViewEstadisticas.DataSource = LstEstadisticas;
            GridViewEstadisticas.DataBind();

            decimal VentasTotales = 0;
            int VehiculosVendidos = 0;

            foreach (SP_ConsultarEstadisticasVentas_Result Estadistica in LstEstadisticas)
            {
                VentasTotales += Convert.ToDecimal(Estadistica.Total_Ventas);
                VehiculosVendidos += Convert.ToInt32(Estadistica.Cantidad);
            }
            LblTotalVentas.Text = Convert.ToString(VentasTotales);
            LblVehiculosVendidos.Text = Convert.ToString(VehiculosVendidos);
        }
        else {
            LblResultado.Text = "Sesión invalida, pruebe saliendo e ingresando de nuevo.";
        }
    }

    protected void GridViewPedidos_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        System.Web.HttpContext.Current.Session["sessionString"] = null;
        Response.Redirect("Login.aspx");
    }
}