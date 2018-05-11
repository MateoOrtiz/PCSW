﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pedidos
    {
        public int Id { get; set; }
        public Nullable<int> IdVehiculo { get; set; }
        public int Cantidad { get; set; }
    
        public virtual Vehiculos Vehiculos { get; set; }
    }
}
namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Personas
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public string NroCuenta { get; set; }
        public string Correo { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
    }
}
namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RegistrosCompra
    {
        public RegistrosCompra()
        {
            this.Ventas = new HashSet<Ventas>();
        }
    
        public int Id { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> IdVehiculo { get; set; }
        public System.DateTime Fecha { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
        public virtual Vehiculos Vehiculos { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Roles
    {
        public Roles()
        {
            this.UsuariosRol = new HashSet<UsuariosRol>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
    
        public virtual ICollection<UsuariosRol> UsuariosRol { get; set; }
    }
}
namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuarios
    {
        public Usuarios()
        {
            this.Personas = new HashSet<Personas>();
            this.RegistrosCompra = new HashSet<RegistrosCompra>();
            this.UsuariosRol = new HashSet<UsuariosRol>();
        }
    
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Pass { get; set; }
    
        public virtual ICollection<Personas> Personas { get; set; }
        public virtual ICollection<RegistrosCompra> RegistrosCompra { get; set; }
        public virtual ICollection<UsuariosRol> UsuariosRol { get; set; }
    }
}
namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UsuariosRol
    {
        public int Id { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> IdRol { get; set; }
    
        public virtual Roles Roles { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehiculos
    {
        public Vehiculos()
        {
            this.Pedidos = new HashSet<Pedidos>();
            this.RegistrosCompra = new HashSet<RegistrosCompra>();
        }
    
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    
        public virtual ICollection<Pedidos> Pedidos { get; set; }
        public virtual ICollection<RegistrosCompra> RegistrosCompra { get; set; }
    }
}
namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ventas
    {
        public int Id { get; set; }
        public Nullable<int> IdRegistroCompra { get; set; }
        public System.DateTime Fecha { get; set; }
    
        public virtual RegistrosCompra RegistrosCompra { get; set; }
    }
}
namespace Models
{
    using System;
    
    public partial class SP_ConsultarUsuario_Result
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Pass { get; set; }
        public int IdPersona { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string NroCuenta { get; set; }
        public int RolId { get; set; }
        public string RolName { get; set; }
    }
}