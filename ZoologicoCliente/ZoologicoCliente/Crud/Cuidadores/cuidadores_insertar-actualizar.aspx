<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="cuidadores_insertar-actualizar.aspx.cs" Inherits="Crud_Cuidadores_cuidadores_insertar_actualizar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <br />
    <div class="white">

        <h1>Insertar/Actualizar</h1>
        <br />

        <div id="floatDivFirst">
            <div class="form-group"> <!-- id -->
                <label for="id" class="control-label">ID</label>
                <asp:TextBox ID="txtbId" runat="server" type="text" class="form-control" name="id" placeholder="ID del cuidador" MaxLength="5"></asp:TextBox>
            </div>    

            <div class="form-group"> <!-- nombre -->
                <label for="nombre" class="control-label">Nombre</label>
                <asp:TextBox ID="txtbNombre" runat="server" type="text" class="form-control" name="nombre" placeholder="Nombre del cuidador" MaxLength="45"></asp:TextBox>
            </div>   

            <div class="form-group"> <!-- apellidos -->
                <label for="apellidos" class="control-label">Apellidos</label>
                <asp:TextBox ID="txtbApellidos" runat="server" type="text" class="form-control" name="apellidos" placeholder="Apellidos del cuidador" MaxLength="45"></asp:TextBox>
            </div>   

            <div class="form-group"> <!-- nacionalidad -->
                <label for="nacionalidad" class="control-label">Nacionalidad</label>
                <asp:TextBox ID="txtbNacionalidad" runat="server" type="text" class="form-control" name="nacionalidad" placeholder="Nacionalidad del cuidador" MaxLength="45"></asp:TextBox>
            </div>   
        </div>

        <div id="floatDivSecond">
            <div class="form-group"> <!-- telefono -->
                <label for="telefono" class="control-label">Telefono</label>
                <asp:TextBox ID="txtbTelefono" runat="server" type="text" class="form-control" name="telefono" placeholder="Telefono del cuidador" MaxLength="12" TextMode="Phone"></asp:TextBox>
            </div>   

            <div class="form-group"> <!-- estatus -->
                <label for="estatus" class="control-label">Estatus</label>
                <asp:TextBox ID="txtbEstatus" runat="server" type="text" class="form-control" name="estatus" placeholder="Estatus del cuidador" MaxLength="45"></asp:TextBox>
            </div>   

            <div class="form-group"> <!-- fecha_ingreso -->
                <label for="fecha_ingreso" class="control-label">Fecha de ingreso</label>
                <asp:TextBox ID="txtbFIngreso" runat="server" type="text" class="form-control" name="fecha_ingreso" placeholder="Fecha de ingreso del cuidador" TextMode="Date"></asp:TextBox>
            </div> 
        </div>

        <br />

        <div class="form-group"> <!-- Button -->
            <asp:Button ID="btnInsertar" runat="server" Text="Insertar" class="btn btn-primary" OnClientClick="return confirm('¿Realizar accion?'); " OnClick="btnInsertar_Click"/>
        </div>    

    </div>

</asp:Content>

