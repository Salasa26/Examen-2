<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="TALLERUH.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class= "contanie text-center">
        <h3>Usuarios</h3>
        
    </div>
    <div>

        <br />
        <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
            CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" AllowPaging="True" />
        <br />

    </div>

        <div class="container text-center">
        Codigo ID: <asp:TextBox ID="tCodigo" class="form-control" runat="server"></asp:TextBox>
        Nombre: <asp:TextBox ID="tNombre" class="form-control" runat="server"></asp:TextBox>
        Correo Electronico: <asp:TextBox ID="tCElectronico" class="form-control" runat="server"></asp:TextBox>
        Telefono: <asp:TextBox ID="tTelefono" class="form-control" runat="server"></asp:TextBox>

    </div>
    <div class="container text-center">
        <br />
        <asp:Button ID="Button1" class="btn btn-outline-primary" runat="server" Text="Agregar" OnClick="Button1_Click" />
        <asp:Button ID="Button2" class="btn btn-outline-secondary" runat="server" Text="Borrar" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" class="btn btn-outline-danger" Text="Modificar" OnClick="Button3_Click" />
        <asp:Button ID="Bconsulta" runat="server" class="btn btn-outline-danger" Text="Consultar" OnClick="Bconsulta_Click" />
        <br />

    </div>




</asp:Content>
