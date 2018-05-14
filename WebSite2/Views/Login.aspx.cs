using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.HttpContext.Current.Session["sessionString"] = null;
    }
    protected void btnValidar_Click(object sender, EventArgs e)
    {
        GestionarUsuario GestionarUser = new GestionarUsuario();

        if (txtUsuario.Text.Trim().Length > 0 && txtClave.Text.Trim().Length > 0)
        {

            Usuario ObjUsuario = GestionarUser.ValidarUsuarioLogin(txtUsuario.Text, txtClave.Text);

            if (ObjUsuario.StatusLogin)
            {
                ObjUsuario.User = txtUsuario.Text;
                ObjUsuario.Password = txtClave.Text;
                lblresultado.Text = "Usuario valido.";

                //Se verifica el tipo de usuario logueado y se le muestra la pantalla correspondiente a el rol
                System.Web.HttpContext.Current.Session["sessionString"] = ObjUsuario.Identificacion;
                if (ObjUsuario.Rol == Convert.ToInt32(TipoUsuario.Cliente))
                {
                    Response.Redirect("Compra.aspx");
                }
                else
                {
                    //Caso Jefe de Taller
                    Response.Redirect("Venta.aspx");
                }
            }
            else
            {
                lblresultado.Text = "Usuario no registrado, para realizar el registro de clic en el vínculo.";
            }
        }
        else
        {
            lblresultado.Text = "Los campos Usuario y Contraseña son obligatorios.";
        }


    }


}