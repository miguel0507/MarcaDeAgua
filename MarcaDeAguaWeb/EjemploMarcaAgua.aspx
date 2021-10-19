<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EjemploMarcaAgua.aspx.cs" Inherits="MarcaDeAguaWeb.EjemploMarcaAgua" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Creacion de Marca de Agua en Imagenes</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="BtnUpload" Text="Subir Archivo" runat="server" OnClick="Upload" />
        
        <div>
            <asp:Image ID="ImagenMarcaAgua" Width="650" Height="500" runat="server" Visible="false" />
        </div>
    </form>
</body>
</html>
