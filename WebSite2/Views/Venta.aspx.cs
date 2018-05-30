using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;

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
                //
                //Guardar lod datos en archivo plano
                if (!Directory.Exists(@"C:\Users\da_ni\OneDrive\Documents\Semester number 8 supposedly\Proyecto construcción de software\Proyecto de proyecto"))
                {
                    Directory.CreateDirectory(@"C:\Users\da_ni\OneDrive\Documents\Semester number 8 supposedly\Proyecto construcción de software\Proyecto de proyecto");
                }

                TextWriter sw = new StreamWriter(@"C:\Users\da_ni\OneDrive\Documents\Semester number 8 supposedly\Proyecto construcción de software\Proyecto de proyecto\Factura.txt");
                int rowcount = GridViewCompras.Rows.Count;
                for (int i = 0; i < rowcount; i++)
                {
                    if(GridViewCompras.Rows[i].Cells[0].Text == txtIdcompra.Text)
                    {

                    sw.WriteLine(Environment.NewLine + "Identifiación del registro de compra: " + GridViewCompras.Rows[i].Cells[0].Text + "\t"
                                 + Environment.NewLine + "Fecha del pedido: " + GridViewCompras.Rows[i].Cells[1].Text + "\t"
                                 + Environment.NewLine + "Vehículo activo" + GridViewCompras.Rows[i].Cells[2].Text + "\t"
                                 + Environment.NewLine + "Marca: " + GridViewCompras.Rows[i].Cells[3].Text + "\t"
                                 + Environment.NewLine + "Modelo: " + GridViewCompras.Rows[i].Cells[4].Text + "\t"
                                 + Environment.NewLine + Environment.NewLine + "Valor a pagar: " + GridViewCompras.Rows[i].Cells[5].Text + "\t"
                                 + Environment.NewLine + Environment.NewLine + "Información del cliente" + Environment.NewLine + "Identificación: " + GridViewCompras.Rows[i].Cells[6].Text + "\t"
                                 + Environment.NewLine + Environment.NewLine + "Nombre: " + GridViewCompras.Rows[i].Cells[7].Text + "\t"
                                 + Environment.NewLine + "Apellidos: " + GridViewCompras.Rows[i].Cells[8].Text + "\t"
                                 + Environment.NewLine + "Correo: " + GridViewCompras.Rows[i].Cells[9].Text + "\t"
                                 + Environment.NewLine + "Dirección: " + GridViewCompras.Rows[i].Cells[10].Text + "\t"
                                 + Environment.NewLine + "Número de cuenta: " + GridViewCompras.Rows[i].Cells[11].Text + "\t"
                                 + Environment.NewLine + "Teléfono: " + GridViewCompras.Rows[i].Cells[12].Text + "\t"
                                 + Environment.NewLine + Environment.NewLine +"      MUCHAS GRACIAS POR SU COMPRA :)"
                                 + Environment.NewLine + Environment.NewLine);

                    }

                }
                sw.Close();
                //Mensaje de éxito
                LblResultado.Text = "Factura exportada a un archivo plano.";
                //
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