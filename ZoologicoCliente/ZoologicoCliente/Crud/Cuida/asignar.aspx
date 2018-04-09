<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="asignar.aspx.cs" Inherits="Crud_Cuida_asignar" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
    <div>
        <h1>Tabla de Asignacion</h1>
        <br />

        <asp:GridView ID="GridView_Cuida" runat="server"
            AutoGenerateColumns="False"
            CssClass="table table-bordered bs-table"
            DataKeyNames="id"
            AllowPaging="true" OnRowCommand="GridView_Cuida_RowCommand" OnPageIndexChanging="GridView_Cuida_PageIndexChanging">

            <Columns>

                <%--campos no editables...--%>
                <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="id_cuidador" HeaderText="Cuidador" InsertVisible="False" ReadOnly="True" SortExpression="id_cuidador" />
                <asp:BoundField DataField="id_animal" HeaderText="Animal" ReadOnly="True" SortExpression="id_animal" />
                <asp:BoundField DataField="turno" HeaderText="Turno" ReadOnly="True" SortExpression="turno" />
                <asp:BoundField DataField="fecha" HeaderText="Fecha" ReadOnly="True" SortExpression="fecha" />


                <%--botones de acción sobre los registros...
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="300px">
                    <ItemTemplate> --%>
                        <%--Botones de eliminar y editar cliente...
                        <asp:Button ID="btnDelete" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Eliminar" OnClientClick="return confirm('¿Eliminar registro?'); " CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                        <asp:Button ID="btnEdit" runat="server" Text="Editar" CssClass="btn btn-info" CommandName="Editar" OnClientClick="return confirm('¿Editar registro?'); " CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField> --%>

            </Columns>
        </asp:GridView>

        <center>
            <div class="form-group"> <!-- Button -->
                <asp:Button ID="btnInsertar" runat="server" Text="Insertar" class="btn btn-primary" center-align="true" OnClick="btnInsertar_Click" />
            </div>     
        </center>
    </div>
</asp:Content>

