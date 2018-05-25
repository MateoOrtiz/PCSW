<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Estadisticas.aspx.cs" Inherits="Pedidos" %>

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
            text-align: center;
        }
        .auto-style4 {
            font-size: xx-large;
            text-align: center;
            color: #FF0000;
            line-height: 115%;
            font-family: Calibri, sans-serif;
        }
        .auto-style5 {
            font-size: x-large;
            text-align: center;
            width: 496px;
        }
        .auto-style6 {
            font-size: x-large;
            text-align: center;
            width: 493px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p class="auto-style4" style="mso-ascii-theme-font: minor-latin; mso-fareast-font-family: Calibri; mso-fareast-theme-font: minor-latin; mso-hansi-theme-font: minor-latin; mso-bidi-font-family: &quot;Times New Roman&quot;; mso-bidi-theme-font: minor-bidi; mso-ansi-language: ES-CO; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
            <strong>Vehículos con mayor aceptación</strong></p>
        <p class="auto-style2">
            &nbsp;</p>
        <p class="auto-style3">
            <asp:GridView ID="GridViewEstadisticas" runat="server" OnSelectedIndexChanged="GridViewPedidos_SelectedIndexChanged" Width="934px" horizontalalign="Center" CssClass="auto-style2">
            </asp:GridView>
        </p>
        <p class="auto-style5">
            Nro de vehiculos vendidos&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="LblVehiculosVendidos" runat="server" Text="Label"></asp:Label>
        </p>
        <p class="auto-style6">
            Total recaudado en ventas&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="LblTotalVentas" runat="server" Text="Label"></asp:Label>
        </p>
        <p class="auto-style2">
            &nbsp;</p>
        <p class="auto-style2">
            <asp:Label ID="LblResultado" runat="server"></asp:Label>
        </p>

        <div class="auto-style3">
                    &nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Views/Venta.aspx">Registros de compra</asp:HyperLink>

            </div>

        <p class="auto-style2">
            &nbsp;</p>
        <p class="auto-style2">
            <asp:Button ID="BtnSalir" runat="server" Text="Salir" Width="82px" Height="35px" OnClick="Button1_Click" />
        </p>
    </form>
</body>
</html>
