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

        if (GestUser.ValidateSesion())
        {

            GestionarVehiculos GestVehiculos = new GestionarVehiculos();

            var LstVehiculos = from ListVehicles in GestVehiculos.ConsultarVehiculos()
                               orderby ListVehicles.Cantidad ascending
                               select ListVehicles;

            GridViewPedidos.DataSource = LstVehiculos.ToList();


            /*DataGridViewButtonColumn colBotones = new DataGridViewButtonColumn();
            colBotones.Name = "colBotones";
            colBotones.HeaderText = "Valor Stock";*/


            GridViewPedidos.DataBind();
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