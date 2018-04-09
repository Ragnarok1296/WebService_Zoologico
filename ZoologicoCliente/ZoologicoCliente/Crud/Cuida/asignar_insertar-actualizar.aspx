<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="asignar_insertar-actualizar.aspx.cs" Inherits="Crud_Cuida_asignar_insertar_actualizar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1>Insertar</h1>
    <br />  

    <div class="form-group"> <!-- id -->
        <label for="id" class="control-label">ID</label>
        <asp:TextBox ID="txtbID" runat="server" type="text" class="form-control" name="id" placeholder="ID de la asignacion" TextMode="Number" MaxLength="10"></asp:TextBox>
    </div>

    <div class="form-group"> <!-- id_cuidador -->
        <label for="id_cuidador" class="control-label">Cuidador</label>
        <asp:DropDownList CssClass="form-control" ID="ddlCuidador" runat="server"></asp:DropDownList>
        <asp:DropDownList CssClass="form-control" ID="ddlIDCuidador" runat="server" Visible="false"></asp:DropDownList>
    </div>   

    <div class="form-group"> <!-- id_animal -->
        <label for="id_animal" class="control-label">Animal</label>
        <asp:DropDownList CssClass="form-control" ID="ddlAnimal" runat="server"></asp:DropDownList>
        <asp:DropDownList CssClass="form-control" ID="ddlIDAnimal" runat="server" Visible="false"></asp:DropDownList>
    </div>  
    
    <div class="form-group"> <!-- turno -->
        <label for="turno" class="control-label">Turno</label>
        <asp:TextBox ID="txtbTurno" runat="server" type="text" class="form-control" name="turno" placeholder="Turno del cuidador" MaxLength="45"></asp:TextBox>
    </div>  

    <div class="form-group"> <!-- fecha -->
        <label for="fecha" class="control-label">Fecha</label>
        <asp:TextBox ID="txtbFecha" runat="server" type="text" class="form-control" name="fecha" placeholder="Fecha" TextMode="Date"></asp:TextBox>
    </div>   
    
    <br />

    <div class="form-group"> <!-- Button -->
        <asp:Button ID="btnInsertar" runat="server" Text="Insertar" class="btn btn-primary" OnClientClick="return confirm('¿Realizar accion?'); " OnClick="btnInsertar_Click"/>
    </div>    

</asp:Content>

