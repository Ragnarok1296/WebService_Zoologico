<%@ Page Title="Animales" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="animales.aspx.cs" Inherits="Crud_Animales_animales" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
    <div class="white">

        <h1>Tabla de Animales</h1>
        <div class="form-group floatButton" > <!-- Button -->
                <asp:Button ID="btnAsigna" runat="server" Text="Asignar" class="btn btn-success" center-align="true" OnClick="btnCuida_Click" />
                <asp:Button ID="btnRevision" runat="server" Text="Revision" class="btn btn-warning" center-align="true" OnClick="btnRevision_Click" />
        </div> 
        <br />

        <div Class="table bs-table">
            <asp:GridView ID="GridView_Animales" runat="server"
                AutoGenerateColumns="False"
                CssClass="table table-bordered bs-table"
                DataKeyNames="id"
                AllowPaging="true" OnRowCommand="GridView_Animales_RowCommand" OnPageIndexChanging="GridView_Animales_PageIndexChanging">

                <Columns>

                    <%--campos no editables...--%>
                    <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" InsertVisible="False" ReadOnly="True" SortExpression="nombre" />
                    <asp:BoundField DataField="especie" HeaderText="Especie" ReadOnly="True" SortExpression="especie" />
                    <asp:BoundField DataField="pais_origen" HeaderText="Pais de origen" ReadOnly="True" SortExpression="pais_origen" />
                    <asp:BoundField DataField="estatus" HeaderText="Estatus" ReadOnly="True" SortExpression="status" />
                    <asp:BoundField DataField="peso" HeaderText="Peso (kg)" ReadOnly="True" SortExpression="peso" />
                    <asp:BoundField DataField="altura" HeaderText="Altura (mts)" ReadOnly="True" SortExpression="altura" />
                    <asp:BoundField DataField="dieta" HeaderText="Dieta" ReadOnly="True" SortExpression="dieta" />
                    <asp:BoundField DataField="sexo" HeaderText="Sexo" ReadOnly="True" SortExpression="sexo" />
                    <asp:BoundField DataField="nivel_riesgo" HeaderText="Nivel de Riesgo" ReadOnly="True" SortExpression="nivel_riesgo" />
                    <asp:BoundField DataField="id_habitad" HeaderText="Habitat" ReadOnly="True" SortExpression="id_habitad" />
                    <asp:BoundField DataField="pres_prop" HeaderText="Prestado o propio" ReadOnly="True" SortExpression="pres_prop" />

                    <%--botones de acción sobre los registros...--%>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="300px">
                        <ItemTemplate>
                            <%--Botones de eliminar y editar cliente...--%>
                            <asp:Button ID="btnDelete" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Eliminar" OnClientClick="return confirm('¿Eliminar registro?'); " CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                            <asp:Button ID="btnEdit" runat="server" Text="Editar" CssClass="btn btn-info" CommandName="Editar" OnClientClick="return confirm('¿Editar registro?'); " CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                            <asp:Button ID="btnPDF" runat="server" Text="PDF" CssClass="btn btn-primary" CommandName="Generar" OnClientClick="return confirm('¿Generar PDF?'); " CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>
            </asp:GridView>
        </div>

        <center>
            <div class="form-group"> <!-- Button -->
                <asp:Button ID="btnInsertar" runat="server" Text="Insertar" class="btn btn-primary" center-align="true" OnClick="btnInsertra_Click" />
            </div>     
        </center>

    </div>
</asp:Content>

