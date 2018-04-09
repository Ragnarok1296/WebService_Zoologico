<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="agendar_insertar-actualizar.aspx.cs" Inherits="Crud_Agendar_agendar_insertar_actualizar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1>Insertar</h1>
    <br />

    <div class="form-group"> <!-- id -->
        <label for="id" class="control-label">ID</label>
        <asp:TextBox ID="txtbId" runat="server" type="text" class="form-control" name="id" placeholder="ID de la revision" MaxLength="10" TextMode="Number"></asp:TextBox>
    </div>    

    <div class="form-group"> <!-- descripcion -->
        <label for="descripcion" class="control-label">Descripcion</label>
        <asp:TextBox ID="txtbDescripcion" runat="server" type="text" class="form-control" name="descripcion" placeholder="Descripcion de la revision" TextMode="MultiLine" MaxLength="45"></asp:TextBox>
    </div>   

    <div class="form-group"> <!-- fecha_ingreso -->
        <label for="fecha_ingreso" class="control-label">Fecha de ingreso</label>
        <asp:TextBox ID="txtbFechaIngreso" runat="server" type="text" class="form-control" name="fecha_ingreso" placeholder="ej: 2018-12-31" TextMode="Date"></asp:TextBox>
    </div>   

    <div class="form-group"> <!-- fecha_salida -->
        <label for="fecha_salida" class="control-label">Fecha de Salida</label>
        <asp:TextBox ID="txtbFechaSalida" runat="server" type="text" class="form-control" name="fecha_salida" placeholder="ej: 2018-12-31" TextMode="Date"></asp:TextBox>
    </div>   

    <div class="form-group"> <!-- tratamiento -->
        <label for="tratamiento" class="control-label">Tratamiento</label>
        <asp:TextBox ID="txtbTratamiento" runat="server" type="text" class="form-control" name="tratamiento" placeholder="Tratamiento para el animal" MaxLength="45" TextMode="MultiLine"></asp:TextBox>
    </div>   

    <div class="form-group"> <!-- observaciones -->
        <label for="observaciones" class="control-label">Observaciones</label>
        <asp:TextBox ID="txtbObservaciones" runat="server" type="text" class="form-control" name="observaciones" placeholder="Observaciones del animal" TextMode="MultiLine" MaxLength="45"></asp:TextBox>
    </div>   

    <div class="form-group"> <!-- estatus -->
        <label for="estatus" class="control-label">Estatus</label>
        <asp:TextBox ID="txtbEstatus" runat="server" type="text" class="form-control" name="estatus" placeholder="Estatus del animal" MaxLength="45"></asp:TextBox>
    </div>   

    <div class="form-group"> <!-- id_animal -->
        <label for="id_animal" class="control-label">Animal</label>
        <asp:DropDownList CssClass="form-control" ID="ddlAnimal" runat="server"></asp:DropDownList>
        <asp:DropDownList CssClass="form-control" ID="ddlIDAnimal" runat="server" Visible="false"></asp:DropDownList>
    </div>   

    <div class="form-group"> <!-- id_veterinario -->
        <label for="id_veterinario" class="control-label">Veterinario</label>
        <asp:DropDownList CssClass="form-control" ID="ddlVeterinario" runat="server"></asp:DropDownList>
        <asp:DropDownList CssClass="form-control" ID="ddlIDVeterinario" runat="server" Visible="false"></asp:DropDownList>
    </div>   

    <div class="form-group"> <!-- concentrado -->
        <label for="concentrado" class="control-label">Concentrado</label>
        <asp:TextBox ID="txtbConcentrado" runat="server" type="text" class="form-control" name="concentrado" placeholder="Concentrado" MaxLength="11" TextMode="Number"></asp:TextBox>
    </div>   
    
    <br />

    <div class="form-group"> <!-- Button -->
        <asp:Button ID="btnInsertar" runat="server" Text="Insertar" class="btn btn-primary" OnClientClick="return confirm('¿Realizar accion?'); " OnClick="btnInsertar_Click"/>
    </div>    

</asp:Content>

