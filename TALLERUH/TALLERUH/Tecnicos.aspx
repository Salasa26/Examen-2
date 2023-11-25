<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="TALLERUH.Tecnicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class= "contanie text-center">
        <h1>Tecnicos</h1>

        </div>
<div>

    <br />
    <asp:GridView runat="server" ID="Tdatagrid" PageSize="10" HorizontalAlign="Center"
        CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
        RowStyle-CssClass="rows" AllowPaging="True" />
    <br />

</div>

    <div class="container text-center">
    Tecnico ID: <asp:TextBox ID="tCodigoTec" class="form-control" runat="server"></asp:TextBox>
    Nombre: <asp:TextBox ID="tNombre" class="form-control" runat="server"></asp:TextBox>

    Especialidad: <asp:DropDownList ID="DropDownListEspecialidad" class="form-control" runat="server"></asp:DropDownList>
    
    

</div>
<div class="container text-center">
    <br />
    <asp:Button ID="TButton1" class="btn btn-outline-primary" runat="server" Text="Agregar" OnClick="TButton1_Click" />
    <asp:Button ID="TButton2" class="btn btn-outline-secondary" runat="server" Text="Borrar" OnClick="TButton2_Click" />
    <asp:Button ID="TButton3" runat="server" class="btn btn-outline-danger" Text="Modificar" OnClick="TButton3_Click" />
    <asp:Button ID="TBconsulta" runat="server" class="btn btn-outline-danger" Text="Consultar" OnClick="TBconsulta_Click" />
    <br />

</div>



    
</asp:Content>
