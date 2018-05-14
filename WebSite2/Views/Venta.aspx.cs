using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Venta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GestionarUsuario GestUser = new GestionarUsuario();

        LblResultado.Text = "";

        if (GestUser.ValidateSesion())
        {

            /*GestionarVentas GestVentas = new GestionarVentas();
            List<Models.SP_ConsultarEstadisticasVentas_Result> LstEstadisticas = GestVentas.ConsultarEstadisticas();
            GridViewCompras.DataSource = LstEstadisticas;
            GridViewCompras.DataBind();*/

            GestionarCompra GestCompra = new GestionarCompra();
            List<Models.SP_ConsultarCompras_Result> LstCompras = GestCompra.ConsultarCompras();
            GridViewCompras.DataSource = LstCompras;
            GridViewCompras.DataBind();

        }
        else
        {
            LblResultado.Text = "Sesión invalida, pruebe saliendo e ingresando de nuevo.";
        }
    }

    protected void GridViewCompras_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        System.Web.HttpContext.Current.Session["sessionString"] = null;
        Response.Redirect("Login.aspx");
    }
}