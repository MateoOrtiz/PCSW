<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Venta.aspx.cs" Inherits="Venta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
            position: absolute;
            top: 0;
            left: 0;
            padding: 16px 0;
            text-align:center;
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
        <div class="">
            <h1 class="">Bienvenido al centro de Venta de vehículos de Malejo</h1>
            <div>
                <p class="">
                    <asp:GridView ID="GridViewCompras" runat="server" OnSelectedIndexChanged="GridViewCompras_SelectedIndexChanged" >
                    </asp:GridView>
                </p>
            </div>
            <div class="container">
                <strong><span class="text">Generar factura de compra</span></strong><br />
                <br />
                Id de compra
                <asp:TextBox ID="txtIdcompra" placeholder="Id de compra" CssClass="input--id" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>

                <asp:Button ID="BtnFacturar" CssClass="button"  runat="server" OnClick="BtnFacturar_Click" Text="Facturar" />

                <asp:Label ID="LblResultado2" runat="server"></asp:Label>

                <asp:Label ID="LblResultado" runat="server"></asp:Label>

                <div class="">

                    <asp:HyperLink CssClass="link" ID="HyperLink1" runat="server" NavigateUrl="~/Views/Estadisticas.aspx">Ver estadísticas de venta</asp:HyperLink>

                </div>
                <asp:Button CssClass="button button--salir"  ID="BtnSalir" runat="server" Text="salir" OnClick="Button1_Click" />
            </div>
        </div>
    </form>
</body>
</html>
