using System;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class GestionarUsuario
{
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
        Boolean Resultado = false;
        try
        {
            using (Models.PCSWDBEntities ObjectBD = new Models.PCSWDBEntities())
            {
                List<Models.SP_ConsultarUsuario_Result> LstUsuarios = ObjectBD.SP_ConsultarUsuario(null).ToList();

                var UsersFound = LstUsuarios.Where(x => x.Usuario.ToLower() == User.User.ToLower() || x.Identificacion == User.Identificacion).ToList();
                Resultado = (UsersFound.Count > 0) ? true : false;

            }
        }
        catch (Exception e)
        {
            string Mensaje = e.Message;
            Resultado = true;
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
}

