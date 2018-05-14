<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pedidos.aspx.cs" Inherits="Pedidos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            font-size: x-large;
            text-align: center;
        }
        .auto-style3 {
            font-size: x-large;
        }
        .auto-style4 {
            font-size: x-large;
            text-align: center;
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p class="auto-style4">
            <strong>Bienvenido al centro de pedido de vehículos de Malejo</strong></p>
        <p class="auto-style2">
            &nbsp;</p>
        <p class="auto-style3">
            <asp:GridView ID="GridViewPedidos" runat="server" OnSelectedIndexChanged="GridViewPedidos_SelectedIndexChanged" Width="934px" horizontalalign="Center" CssClass="auto-style2">
            </asp:GridView>
        </p>
        <p class="auto-style2">
            &nbsp;</p>
        <p class="auto-style2">
            <asp:Label ID="LblResultado" runat="server"></asp:Label>
        </p>
        <p class="auto-style2">
            <asp:Button ID="BtnSalir" runat="server" Text="Salir" Width="82px" Height="35px" OnClick="Button1_Click" />
        </p>
    </form>
</body>
</html>
