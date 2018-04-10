<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="animales_insertar-actualizar.aspx.cs" Inherits="Crud_Animales_animales_insertar_actualizart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <br />
    <div class="white">

        <h1>Insertar/Actualizar</h1>
        <br />

        <div id="floatDivFirst">

            <div class="form-group"> <!-- id -->
                <label for="id" class="control-label">ID</label>
                <asp:TextBox ID="txtbId" runat="server" type="text" class="form-control" name="id" placeholder="ID del animal" MaxLength="11" TextMode="Number"></asp:TextBox>
            </div>    

            <div class="form-group"> <!-- nombre -->
                <label for="nombre" class="control-label">Nombre</label>
                <asp:TextBox ID="txtbNombre" runat="server" type="text" class="form-control" name="nombre" placeholder="Nombre del animal" MaxLength="45"></asp:TextBox>
            </div>   

            <div class="form-group"> <!-- especie -->
                <label for="especie" class="control-label">Especie</label>
                <asp:TextBox ID="txtbEspecie" runat="server" type="text" class="form-control" name="especie" placeholder="Especie del animal" MaxLength="45"></asp:TextBox>
            </div>   

            <div class="form-group"> <!-- pais_origen -->
                <label for="pais_origen" class="control-label">Pais de origen</label>
                <asp:TextBox ID="txtbPaisOrigen" runat="server" type="text" class="form-control" name="pais_origen" placeholder="Pais de origen del animal" MaxLength="45"></asp:TextBox>
            </div>   

            <div class="form-group"> <!-- estatus -->
                <label for="estatus" class="control-label">Estatus</label>
                <asp:TextBox ID="txtbEstatus" runat="server" type="text" class="form-control" name="estatus" placeholder="Estatus del animal" MaxLength="45"></asp:TextBox>
            </div>   

            <div class="form-group"> <!-- peso -->
                <label for="peso" class="control-label">Peso</label>
                <asp:TextBox ID="txtbPeso" runat="server" type="text" class="form-control" name="peso" placeholder="Peso del animal (Kg)"></asp:TextBox>
            </div>   

        </div>

        <div id="floatDivSecond" >

            <div class="form-group"> <!-- altura -->
                <label for="altura" class="control-label">Altura</label>
                <asp:TextBox ID="txtbAltura" runat="server" type="text" class="form-control" name="altura" placeholder="Altura del animal (mts)"></asp:TextBox>
            </div>   

            <div class="form-group"> <!-- dieta -->
                <label for="dieta" class="control-label">Dieta</label>
                <asp:TextBox ID="txtbDieta" runat="server" type="text" class="form-control" name="dieta" placeholder="Dieta del animal" MaxLength="45"></asp:TextBox>
            </div>   

            <div class="form-group"> <!-- sexo -->
                <label for="sexo" class="control-label">Sexo</label>
                <asp:TextBox ID="txtbSexo" runat="server" type="text" class="form-control" name="sexo" placeholder="Sexo del animal (M o H)" MaxLength="1"></asp:TextBox>
            </div>   

            <div class="form-group"> <!-- nivel_riesgo -->
                <label for="nivel_riesgo" class="control-label">Nivel de riesgo</label>
                <asp:TextBox ID="txtbNivelRiesgo" runat="server" type="text" class="form-control" name="nivel_riesgo" placeholder="Nivel de riesgo del animal" MaxLength="45"></asp:TextBox>
            </div>   

            <div class="form-group"> <!-- id_habitad -->
                <label for="id_habitad" class="control-label">Habitat</label>
                <asp:DropDownList CssClass="form-control" ID="ddlHabitat" runat="server"></asp:DropDownList>
                <asp:DropDownList CssClass="form-control" ID="ddlID" runat="server" Visible="false"></asp:DropDownList>
            </div>   

            <div class="form-group"> <!-- pres_prop -->
                <label for="pres_prop" class="control-label">Prestado o Propiedad</label>
                <asp:DropDownList CssClass="form-control" ID="ddlPres" runat="server">
                    <asp:ListItem>Permanente</asp:ListItem>
                    <asp:ListItem>Prestado</asp:ListItem>
                </asp:DropDownList>
            </div>
            
        </div>

        <br />

        <div class="form-group"> <!-- Button -->
            <asp:Button ID="btnInsertar" runat="server" Text="Insertar" class="btn btn-primary" OnClientClick="return confirm('¿Realizar accion?'); " OnClick="btnInsertar_Click"/>
        </div>
        
    </div>

</asp:Content>

