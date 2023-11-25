<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="TALLERUH.Equipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class= "contanie text-center">
        <h1>Equipos</h1>

        </div>
<div>

    <br />
    <asp:GridView runat="server" ID="Edatagrid" PageSize="10" HorizontalAlign="Center"
        CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
        RowStyle-CssClass="rows" AllowPaging="True" />
    <br />

</div>

    <div class="container text-center">
    Equipo ID: <asp:TextBox ID="EEquipoID" class="form-control" runat="server"></asp:TextBox>
    Usuario ID: <asp:TextBox ID="EUsuarioID" class="form-control" runat="server"></asp:TextBox>

    Tipo: <asp:DropDownList ID="DropDownListETipo" class="form-control" runat="server"></asp:DropDownList>
    
    Modelo: <asp:TextBox ID="EModelo" class="form-control" runat="server"></asp:TextBox>
    
    

</div>
<div class="container text-center">
    <br />
    <asp:Button ID="EButton1" class="btn btn-outline-primary" runat="server" Text="Agregar" OnClick="TButton1_Click" />
    <asp:Button ID="EButton2" class="btn btn-outline-secondary" runat="server" Text="Borrar" OnClick="TButton2_Click" />
    <asp:Button ID="EButton3" runat="server" class="btn btn-outline-danger" Text="Modificar" OnClick="TButton3_Click" />
    <asp:Button ID="EBconsulta" runat="server" class="btn btn-outline-danger" Text="Consultar" OnClick="TBconsulta_Click"/>
    <br />

</div>


    </div>
</asp:Content>
