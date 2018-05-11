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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p class="auto-style2">
            <strong>Bienvenido al centro de Venta de vehículos de Malejo</strong></p>
        <p class="auto-style2">
            &nbsp;</p>
        <p class="auto-style2">
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </p>
        <p class="auto-style2">
            <asp:Button ID="Button1" runat="server" Text="Salir" Width="72px" />
        </p>
    </form>
</body>
</html>
