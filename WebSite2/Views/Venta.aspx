<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Venta.aspx.cs" Inherits="Venta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
            text-align: center;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style2">
            <h1 class="auto-style1">Bienvenido al centro de Venta de vehículos de Malejo</h1>
            <div style="text-align: center">
                <br />
                <br />
                <p class="auto-style3">
            <asp:GridView ID="GridViewCompras" runat="server" OnSelectedIndexChanged="GridViewCompras_SelectedIndexChanged" Width="934px" horizontalalign="Center" CssClass="auto-style2">
            </asp:GridView>
        </p>
            </div>
            <div class="auto-style2">
                <strong><span class="auto-style3">Generar factura de compra</span></strong><br />
                <br />
                Id de compra&nbsp;&nbsp;
                <asp:TextBox ID="txtIdcompra" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnFacturar" runat="server" OnClick="BtnFacturar_Click" Text="Facturar" />
                <br />
                <br />
                <asp:Label ID="LblResultado2" runat="server"></asp:Label>
                <br />
                <asp:Label ID="LblResultado" runat="server"></asp:Label>
                <br />
                <br />
                <div class="auto-style3">
                    &nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Views/Estadisticas.aspx">Ver estadísticas de venta</asp:HyperLink>

            </div>
                <br />
                <asp:Button ID="BtnSalir" runat="server" Text="salir" Width="90px" OnClick="Button1_Click" />
                <br />
                <br />
                <br />
                <br />
            </div>
        </div>
    </form>
</body>
</html>
