<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="veterinarios_insertar-actualizar.aspx.cs" Inherits="Crud_Cuidadores_veterinarips_insertar_actualizar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <br />
    <div class="white">

        <h1>Insertar/Actualizar</h1>
        <br />

        <div id="floatDivFirst">
            <div class="form-group"> <!-- id -->
                <label for="id" class="control-label">ID</label>
                <asp:TextBox ID="txtbId" runat="server" type="text" class="form-control" name="id" placeholder="ID del veterinario" MaxLength="10" TextMode="Number"></asp:TextBox>
            </div>    

            <div class="form-group"> <!-- nombre -->
                <label for="nombre" class="control-label">Nombre</label>
                <asp:TextBox ID="txtbNombre" runat="server" type="text" class="form-control" name="nombre" placeholder="Nombre del veterinario" MaxLength="45"></asp:TextBox>
            </div>   

            <div class="form-group"> <!-- apellidos -->
                <label for="apellidos" class="control-label">Apellidos</label>
                <asp:TextBox ID="txtbApellidos" runat="server" type="text" class="form-control" name="apellidos" placeholder="Apellidos del veterinario" MaxLength="45"></asp:TextBox>
            </div>   
        </div>

        <div id="floatDivSecond">
            <div class="form-group"> <!-- especialidad -->
                <label for="especialidad" class="control-label">Especialidad</label>
                <asp:TextBox ID="txtbEspecialidad" runat="server" type="text" class="form-control" name="especialidad" placeholder="Especialidad del veterinario" MaxLength="45"></asp:TextBox>
            </div>   

            <div class="form-group"> <!-- fecha_ingreso -->
                <label for="fecha_ingreso" class="control-label">Fecha de ingreso</label>
                <asp:TextBox ID="txtbFechaIngreso" runat="server" type="text" class="form-control" name="fecha_ingreso" placeholder="Fecha de ingreso del veterinario" TextMode="Date"></asp:TextBox>
            </div>   

            <div class="form-group"> <!-- salario -->
                <label for="salario" class="control-label">Salario</label>
                <asp:TextBox ID="txtbSalario" runat="server" type="text" class="form-control" name="peso" placeholder="Salario del veterinario ($)"></asp:TextBox>
            </div> 
        </div>

        <br />

        <div class="form-group"> <!-- Button -->
            <asp:Button ID="btnInsertar" runat="server" Text="Insertar" class="btn btn-primary" OnClientClick="return confirm('¿Realizar accion?'); " OnClick="btnInsertar_Click"/>
        </div>
        
    </div>

</asp:Content>

