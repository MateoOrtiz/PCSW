using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class Venta : System.Web.UI.Page
{

   

    protected void Page_Load(object sender, EventArgs e)
    {
        GestionarUsuario GestUser = new GestionarUsuario();

        LblResultado.Text = "";

        txtIdcompra.Enabled = false;
        BtnFacturar.Enabled = false;

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

            txtIdcompra.Enabled = true;
            BtnFacturar.Enabled = true;

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

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    protected void BtnFacturar_Click(object sender, EventArgs e)
    {

        GestionarCompra GestCompra = new GestionarCompra();
        List<Models.SP_ConsultarCompras_Result> LstCompras = GestCompra.ConsultarCompras();

        GestionarVentas GestionVenta = new GestionarVentas();

        if (txtIdcompra.Text.Length > 0)
        {
           var Lista =  LstCompras.Where(x => x.Activo == true && x.IdRegistroCompra == Convert.ToUInt32(txtIdcompra.Text)).ToList();

            if (Lista.Count > 0)
            {
                GestionVenta.GuardarVenta(Convert.ToInt32(txtIdcompra.Text));

                //Refrescar vista
                GridViewCompras.DataSource = LstCompras;

                Page_Load(sender, e);

                GridViewCompras.DataBind();

                LblResultado.Text = "Venta de vehículo realizada con éxito..";

                

            }
            else {
                LblResultado.Text = "El Id de compra no está activo.";
            }          
        }
        else {
            LblResultado.Text = "Id de compra no válido.";
        }
    }
}