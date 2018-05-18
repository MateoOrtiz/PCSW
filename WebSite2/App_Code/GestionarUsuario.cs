using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class GestionarUsuario
{
    bool invalid = true;
    //Validacion de formato de correo valido
    public bool IsValidEmail(string strIn)
    {
        invalid = true;
        if (String.IsNullOrEmpty(strIn))
            return false;

        // Use IdnMapping class to convert Unicode domain names.
        try
        {
            strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                  RegexOptions.None);
        }
        catch (Exception)
        {
            return false;
        }

        if (!invalid)
        {
            return false;
        }
        // Return true if strIn is in valid email format.
        try
        {
            return Regex.IsMatch(strIn,
                  @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                  @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                  RegexOptions.IgnoreCase);
        }
        catch (Exception)
        {
            return false;
        }
    }

    //Dominios validos
    private string DomainMapper(Match match)
    {
        // IdnMapping class with default property values.
        IdnMapping idn = new IdnMapping();

        string domainName = match.Groups[2].Value;
        try
        {
            domainName = idn.GetAscii(domainName);
        }
        catch (ArgumentException)
        {
            invalid = false;
        }
        return match.Groups[1].Value + domainName;
    }

    public bool GuardarUsuario(Usuario User)
    {
        Boolean Resultado = true;
        try
        {
            using (Models.PCSWDBEntities ObjectBD = new Models.PCSWDBEntities())
            {
                ObjectBD.SP_InsertarUsuario(User.Identificacion, User.Nombre, User.Apellidos,
                                            User.Direccion, User.Telefono, User.NroCuenta,
                                            User.User, User.Password, User.Rol,User.Correo);
            }
        }
        catch (Exception e)
        {
            string Mensaje = e.Message;
            Resultado = false;
        }
        return Resultado;
    }

    public bool ValidarUsuarioExiste(Usuario User)
    {
        Boolean Resultado = true;
        try
        {
            using (Models.PCSWDBEntities ObjectBD = new Models.PCSWDBEntities())
            {
                List<Models.SP_ConsultarUsuario_Result> LstUsuarios = ObjectBD.SP_ConsultarUsuario(null).ToList();

                var UsersFound = LstUsuarios.Where(x => x.Usuario.ToLower() == User.User.ToLower() || x.Identificacion == User.Identificacion).ToList();
                Resultado = (UsersFound.Count > 0) ? false : true;
            }
        }
        catch (Exception e)
        {
            string Mensaje = e.Message;
            Resultado = false;
        }

        return Resultado;
    }

    public Usuario ValidarUsuarioLogin(string User, string Password)
    {      
        Usuario UserResponse = new Usuario();
        UserResponse.StatusLogin = false;
        try
        { 
            using (Models.PCSWDBEntities ObjectBD = new Models.PCSWDBEntities())
            {
                List<Models.SP_ConsultarUsuario_Result> LstUsuarios = ObjectBD.SP_ConsultarUsuario(null).ToList();
                var UsersFound = LstUsuarios.Where(x => x.Usuario.Equals(User) && x.Pass.Equals(Password)).ToList();

                if (UsersFound.Count > 0) {

                    UserResponse.Rol = UsersFound[0].RolId;
                    UserResponse.RolName = UsersFound[0].RolName;
                    UserResponse.Identificacion = UsersFound[0].Identificacion;
                    UserResponse.Nombre = UsersFound[0].Nombre;
                    UserResponse.Apellidos = UsersFound[0].Apellidos;
                    UserResponse.Direccion = UsersFound[0].Direccion;
                    UserResponse.Telefono = UsersFound[0].Telefono;
                    UserResponse.NroCuenta = UsersFound[0].NroCuenta;
                    UserResponse.StatusLogin = true;
                }
            }
        }
        catch (Exception e)
        {
            string Mensaje = e.Message;
            UserResponse.StatusLogin = false;
        }
        return UserResponse;
    }

    public Boolean ValidateSesion() {
        try {
            String Sesion = System.Web.HttpContext.Current.Session["sessionString"] as String;
            if (Sesion.Length > 0) {
                return true;
            }
        }
        catch (Exception e) {
            return false;
        }
        return false;
    }
}

