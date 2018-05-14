using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btnguardar_Click(object sender, EventArgs e)
    {
        GestionarUsuario GestionarUser = new GestionarUsuario();

        Usuario ObjUsuario = new Usuario()
        {
            User = txtUser.Text,
            Password = txtPassword.Text,
            Rol = Convert.ToInt32(ListTipoUsuario.SelectedValue),
            Identificacion = txtIdentificacion.Text,
            Nombre = txtNombre.Text,
            Apellidos = txtApellidos.Text,
            Correo = txtCorreo.Text,
            Direccion = txtDireccion.Text,
            Telefono = txtTelefono.Text,
            NroCuenta = txtNroCuenta.Text
        };

        if (ObjUsuario.User.Length > 0
            && ObjUsuario.Password.Length > 0
            && ObjUsuario.Rol > 0
            && ObjUsuario.Identificacion.Length > 0
            && ObjUsuario.Nombre.Length > 0
            && ObjUsuario.Apellidos.Length > 0
            && ObjUsuario.Correo.Length > 0
            && ObjUsuario.Direccion.Length > 0
            && ObjUsuario.Telefono.Length > 0
            && ObjUsuario.NroCuenta.Length > 0
            )
        {

            if (!ValidarCampoNumerico(ObjUsuario.Identificacion) || !ValidarCampoNumerico(ObjUsuario.Telefono) || !ValidarCampoNumerico(ObjUsuario.NroCuenta))
            {
                lblresultado.Text = "Los campos Identificación, Telefono y Número de cuenta son de tipo Numerico.";
            }
            else
            {
                if (GestionarUser.IsValidEmail(ObjUsuario.Correo))
                {
                    if (!GestionarUser.ValidarUsuarioExiste(ObjUsuario))
                    {
                        GestionarUser.GuardarUsuario(ObjUsuario);
                        lblresultado.Text = "Usuario registrado con éxito.";
                    }
                    else
                    {
                        lblresultado.Text = "Ya existe un usuario con el mismo nombre de usuario o identificación.";
                    }
                }
                else
                {

                    lblresultado.Text = "Formato de correo invalido.";
                }
            }
        }
        else
        {
            lblresultado.Text = "Todos los campos del formulario son obligatorios.";
        }


    }

    public Boolean ValidarCampoNumerico(string Numero)
    {
        try
        {
            double Conversion;

            Conversion = Convert.ToDouble(Numero);
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return false;
        }

        return true;
    }
}
