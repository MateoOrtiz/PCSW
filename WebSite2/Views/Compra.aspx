<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Compra.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://fonts.googleapis.com/css?family=Lato|Ubuntu" rel="stylesheet"> 
    <title></title>
    <style type="text/css">

        body {
            box-sizing: border-box;
            font-family: 'Ubuntu', sans-serif;
            display: flex;
            justify-content: center;
            align-items: center;
            margin: 0;
            padding-bottom: 32px;
            padding-top:100px;
        }

        
        h1 {
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

        .container {
            width: 500px;
            margin: 0 auto;
            display: flex;
            justify-content: center;
            align-items: center;
            flex-direction: column;
        }

        input, select {
            border: none;
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 8px;
            font-family:'Ubuntu', sans-serif;
            width: 55%;
            margin-bottom: 16px;
        }

        .button--salir {
            background: #730000;
        }


        select {
            width: 60%;
        }

         .text {
            text-align: center;
            margin: 32px 0;
        }


         .button {
            margin-top: 16px;
            padding: 8px;
            text-transform: uppercase;
            background: #d10000;
            color: white;
            cursor: pointer;
            transition: all .3s ease;
            margin: 32px 0 16px;
        }

         .button:hover {
            background: #be0000;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">

           <h1 class="auto-style2">Bienvenido al centro de compra de vehículos de Malejo</h1>

            <div class="container">
                <p class="text">Vehiculos disponibles:</p>
                <asp:DropDownList ID="ListaVehiculos" runat="server" OnSelectedIndexChanged="ListaVehiculos_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
                <asp:TextBox ID="TxtIdentificacion" placeholder="Identificación" runat="server"></asp:TextBox>
                <asp:Button ID="btnComprar" runat="server" CssClass="button" Text="Comprar" OnClick="btnComprar_Click" />
                <asp:Label ID="LblMarca" runat="server"></asp:Label>

                <asp:Label ID="LblModelo" runat="server"></asp:Label>
    
                <asp:Label ID="LblPrecio" runat="server"></asp:Label>
    
                <asp:Label ID="LblCantidad" runat="server"></asp:Label>
 
                <asp:Label ID="LblResultado" runat="server"></asp:Label>

                <asp:Button ID="brnsalirad" CssClass="button button--salir" runat="server" onclick="brnsalirad_Click" 
            Text="Salir" />
            </div>

            

    </form>
</body>
</html>
