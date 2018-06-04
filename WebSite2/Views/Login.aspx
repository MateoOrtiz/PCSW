<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

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
            width: 20%;
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

        input {
            border: none;
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 8px;
            font-family:'Ubuntu', sans-serif;
            width: 55%;
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
            margin: 42px 0 16px;
        }

        .link {
            text-decoration: none;
            color: #d10000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <h3 class="">iniciar sesión</h3>

        <div class="item">
            <span>Usuario:</span>
            <asp:TextBox ID="txtUsuario" runat="server" placeholder="Usuario"></asp:TextBox>
        </div>
        <div class="item">  
            <span>Contraseña:</span>
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
        </div>
        <div class="">            
            <asp:Button class="button" ID="btnValidar" runat="server" OnClick="btnValidar_Click" Text=" Ingresar " Width="124px" />
        </div>
        <div class="text">
            <asp:Label ID="lblresultado" runat="server" Text="Para registrarse de click en el siguiente enlace"></asp:Label>
        </div>
        <div class="">
            <asp:HyperLink class="link" ID="HyperLink1" runat="server" NavigateUrl="~/Views/registro.aspx">Registrarme</asp:HyperLink>
        </div>

    </form>
</body>
</html>
