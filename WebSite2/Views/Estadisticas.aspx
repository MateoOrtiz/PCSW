<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Estadisticas.aspx.cs" Inherits="Pedidos" %>

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
        }

        h1 {
            text-transform: uppercase;
            background: #d10000;
            color: white;
            width: 100%;
            margin: 0;
            position: fixed;
            top: 0;
            left: 0;
            padding: 16px 0;
            text-align:center;
            width: 100%;
        }

        table {
            width: 95%;
            margin: 0 auto;
            margin-top: 100px;
        }

        th {
            padding: 8px 4px;
            background: #eea2a2;
            text-align:center;
            border: 1px solid #ccc;
        }

        td {
            text-align:center;
            padding: 4px;
             border: 1px solid #ccc;
        }

        tr {
          
        }

        tr:nth-child(2n+1) {
            background: #fae7e7;
        }

        form {
            margin: 0 auto;
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
            margin: 32px 0 16px;
        }

        .button--salir {
            background: #730000;
        }


        .button:hover {
            background: #be0000;
        }

        .text {
            text-align: center;
            margin: 32px 0;
        }

        .link {
            text-decoration: none;
            color: #d10000;
         
        }

        .container {
            width: 500px;
            margin: 0 auto;
            display: flex;
            justify-content: center;
            align-items: center;
            flex-direction: column;
        }

        .input--id {
            margin: 16px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Vehículos con mayor aceptación</h1>
        <p class="auto-style3">
            <asp:GridView ID="GridViewEstadisticas" runat="server" OnSelectedIndexChanged="GridViewPedidos_SelectedIndexChanged" Width="934px" horizontalalign="Center" CssClass="auto-style2">
            </asp:GridView>
        </p>
        <p class="auto-style5">
            Nro de vehiculos vendidos
            <asp:Label ID="LblVehiculosVendidos" runat="server" Text="Label"></asp:Label>
        </p>
        <p class="auto-style6">
            Total recaudado en ventas
            <asp:Label ID="LblTotalVentas" runat="server" Text="Label"></asp:Label>
        </p>
        <p class="auto-style2">
            <asp:Label ID="LblResultado" runat="server"></asp:Label>
        </p>

        <div class="auto-style3">
            <asp:HyperLink CssClass="link" ID="HyperLink1" runat="server" NavigateUrl="~/Views/Venta.aspx">Registros de compra</asp:HyperLink>

            </div>
        <p class="auto-style2">
            <asp:Button class="button" ID="BtnSalir" runat="server" Text="Salir" Width="82px" Height="35px" OnClick="Button1_Click" />
        </p>
    </form>
</body>
</html>
