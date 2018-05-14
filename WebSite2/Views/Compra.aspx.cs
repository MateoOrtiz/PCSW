using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    public static class Globales
    {
        public static string UserID = System.Web.HttpContext.Current.Session["sessionString"] as String;
    }

    public List<Vehiculo> LstVehiculos;

    protected void Page_Load(object sender, EventArgs e)
    {
        GestionarUsuario GestUser = new GestionarUsuario();

        if (GestUser.ValidateSesion())
        {
            btnComprar.Enabled = true;
            GestionarVehiculos GestVehiculos = new GestionarVehiculos();
            this.LstVehiculos = GestVehiculos.ConsultarVehiculos();

            if (ListaVehiculos.Items.Count == 0)
            {
                if (ListaVehiculos != null)
                {
                    //Inicial
                    ListaVehiculos.Items.Add(new ListItem("Seleccione vehículo", "0"));

                    foreach (Vehiculo Vehicle in LstVehiculos)
                    {
                        ListItem oItem = new ListItem(Vehicle.Marca + " - " + Vehicle.Modelo, Convert.ToString(Vehicle.Id));
                        //Objeto droplist
                        ListaVehiculos.Items.Add(oItem);
                    }
                }
            }
        }
        else
        {
            btnComprar.Enabled = false;
            LblResultado.Text = "Sesión invalida, pruebe saliendo e ingresando de nuevo.";
        }
    }

    protected void brnsalirad_Click(object sender, EventArgs e)
    {
        System.Web.HttpContext.Current.Session["sessionString"] = null;
        Response.Redirect("Login.aspx");
    }

    public void Descripcion()
    {
        LblMarca.Text = "";
        LblModelo.Text = "";
        LblPrecio.Text = "";
        LblCantidad.Text = "";

        if (Convert.ToInt32(ListaVehiculos.SelectedValue) != 0)
        {
            var Vehiculo = this.LstVehiculos.Where(x => x.Id == Convert.ToInt32(ListaVehiculos.SelectedValue)).ToList()[0];

            LblMarca.Text = "Marca:         " + Vehiculo.Marca;
            LblModelo.Text = "Modelo:        " + Vehiculo.Modelo;
            LblPrecio.Text = "Precio:        " + Vehiculo.Precio;
            LblCantidad.Text = "Unidades disp: " + Vehiculo.Cantidad;
        }
    }

    protected void btnComprar_Click(object sender, EventArgs e)
    {
        if ((Convert.ToInt32(ListaVehiculos.SelectedValue) != 0 && TxtIdentificacion.Text.Trim().Length > 0))
        {
            if (TxtIdentificacion.Text.Equals(Globales.UserID))
            {
                GestionarCompra GestCompra = new GestionarCompra();

                if (GestCompra.GuardarCompra(TxtIdentificacion.Text, (Convert.ToInt32(ListaVehiculos.SelectedValue))))
                {
                    LimpiarCampos();
                    LblResultado.Text = "Pedido de compra realizado con éxito.";
                }
                else
                {
                    LblResultado.Text = "Ocurrió un error en el proceso, vuelva a intentarlo, si el problema persiste comuníquese al número (+57)3217279322.";
                }
            }
            else
            {
                LblResultado.Text = "La identificación no corresponde al usuario en sesión.";
            }
        }
        else
        {
            LblResultado.Text = "Seleccione el tipo de vehículo y digite el número de identificación.";
        }
    }

    public void LimpiarCampos() {

        LblMarca.Text = "";
        LblModelo.Text = "";
        LblPrecio.Text = "";
        LblCantidad.Text = "";
        TxtIdentificacion.Text = "";
        ListaVehiculos.SelectedIndex = 0;
        ListaVehiculos.Dispose();

    }


    protected void ListaVehiculos_SelectedIndexChanged(object sender, EventArgs e)
    {
        Descripcion();
    }
}