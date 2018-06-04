<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registro.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://fonts.googleapis.com/css?family=Lato|Ubuntu" rel="stylesheet"> 
    <style type="text/css">
        body {
            box-sizing: border-box;
            font-family: 'Ubuntu', sans-serif;
            display: flex;
            justify-content: center;
            align-items: center;
            margin: 0;
            padding-bottom: 32px;
        }

        h3 {
            text-transform: uppercase;
            background: #d10000;
            color: white;
            width: 100%;
            margin: 0;
            position: absolute;
            top: 0;
            left: 0;
            padding: 16px 0;
            text-align:center;
        }

        form {
            width: 30%;
            margin: 0 auto;
            display: flex;
            justify-content: center;
            align-items: center;
            flex-direction: column;
            border: 1px solid #ccc;
            margin-top: 50px;
            box-shadow: 2px 3px 5px #ccc;
            padding: 70px 50px 25px;
            border-radius: 8px;
            position:relative;
        }

        .item {
            display: flex;
            justify-content: space-between;
            align-items: center;
            width: 100%;
            padding: 12px 0;
 
        }

        input, select {
            border: none;
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 8px;
            font-family:'Ubuntu', sans-serif;
            width: 55%;
        }

        select {
            width: 60%;
        }

        .button {
            margin-top: 16px;
            padding: 8px;
            text-transform: uppercase;
            background: #d10000;
            color: white;
            cursor: pointer;
            transition: all .3s ease;
        }

        .button:hover {
            background: #be0000;
        }

        .text {
            text-align: center;
            margin: 32px 0 16px;
        }

        .link {
            text-decoration: none;
            color: #d10000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h3 class="">Registro de usuario</h3>
            <div class="item">
                Identificación:
                <asp:TextBox ID="txtIdentificacion" runat="server" placeholder="Identificación"></asp:TextBox>
            </div>

            <div class="item">
                Nombre:
                <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre"></asp:TextBox>
            </div>
            
            <div class="item">
                Apellidos:
                <asp:TextBox ID="txtApellidos" runat="server" placeholder="Apellidos"></asp:TextBox>
            </div>

            <div class="item">
                Correo:
                <asp:TextBox ID="txtCorreo" runat="server" placeholder="Correo"></asp:TextBox>
            </div>
            
            <div class="item">
                Dirección:
                <asp:TextBox ID="txtDireccion" runat="server" placeholder="Dirección"></asp:TextBox>
            </div>

            <div class="item">
                Teléfono:
                <asp:TextBox ID="txtTelefono" runat="server" placeholder="Teléfono"></asp:TextBox>
            </div>

            <div class="item">
                Nro cuenta:
                <asp:TextBox ID="txtNroCuenta" runat="server" placeholder="Nro cuenta"></asp:TextBox>
            </div>

            <div class="item">
                Usuario: 
                <asp:TextBox ID="txtUser" runat="server" placeholder="Usuario"></asp:TextBox>
            </div>

            <div class="item">
                Contraseña:
                <asp:TextBox ID="txtPassword" runat="server" placeholder="Contraseña"></asp:TextBox>
            </div>

            <div class="item">
                Tipo de usuario:
                <asp:DropDownList ID="ListTipoUsuario" runat="server">
                    <asp:ListItem Selected="True" Value="1">Cliente</asp:ListItem>
                    <asp:ListItem Value="2">Jefe de taller</asp:ListItem>
                </asp:DropDownList>
            </div>

            <asp:Button class="button" ID="Btnguardar" runat="server" OnClick="Btnguardar_Click" Text="Guardar" Width="110px" />

            <asp:Label ID="lblresultado" runat="server" Text=""></asp:Label>

           <asp:HyperLink class="link text" ID="HyperLink1" runat="server" NavigateUrl="~/Views/login.aspx">Iniciar sesión</asp:HyperLink>
    </form>
</body>
</html>
