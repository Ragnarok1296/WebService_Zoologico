<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="habitats_insertar-actualizar.aspx.cs" Inherits="Crud_Habitats_habitats_insertar_actualizar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <br />
    <div class="white">

        <h1>Insertar/Actualizar</h1>
        <br />

        <div class="form-group"> <!-- id -->
            <label for="id" class="control-label">ID</label>
            <asp:TextBox ID="txtbId" runat="server" type="text" class="form-control" name="id" placeholder="ID del habitad" MaxLength="5"></asp:TextBox>
        </div>    

        <div class="form-group"> <!-- descripciom -->
            <label for="descripcion" class="control-label">Descripcion</label>
            <asp:TextBox ID="txtbDescripcion" runat="server" type="text" class="form-control" name="descripcion" placeholder="Descripcion del habitad" MaxLength="45" TextMode="MultiLine"></asp:TextBox>
        </div>   

        <div class="form-group"> <!-- clima -->
            <label for="clima" class="control-label">Clima</label>
            <asp:TextBox ID="txtbClima" runat="server" type="text" class="form-control" name="clima" placeholder="Clima del habitad" MaxLength="45"></asp:TextBox>
        </div>   

        <div class="form-group"> <!-- dimension -->
            <label for="dimension" class="control-label">Dimension</label>
            <asp:TextBox ID="txtbDimension" runat="server" type="text" class="form-control" name="dimension" placeholder="Dimension del habitad (mts)"></asp:TextBox>
        </div>   

        <br />

        <div class="form-group"> <!-- Button -->
            <asp:Button ID="btnInsertar" runat="server" Text="Insertar" class="btn btn-primary" OnClientClick="return confirm('¿Realizar accion?'); " OnClick="btnInsertar_Click"/>
        </div>
        
    </div>

</asp:Content>

