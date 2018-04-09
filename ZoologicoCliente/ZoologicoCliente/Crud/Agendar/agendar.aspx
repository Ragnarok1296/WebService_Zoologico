<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="agendar.aspx.cs" Inherits="Crud_Agendar_agendar" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1>Tabla de Revisiones</h1>
    <br />

    <asp:GridView ID="GridView_Revisiones" runat="server"
        AutoGenerateColumns="False" 
        CssClass="table table-bordered bs-table" 
        DataKeyNames="id" 
        allowpaging="true" OnRowCommand="GridView_Revisiones_RowCommand" OnPageIndexChanging="GridView_Revisiones_PageIndexChanging" >             
 
        <Columns>
            
            <%--campos no editables...--%>
            <asp:BoundField DataField="id" HeaderText="Numero" InsertVisible="False" ReadOnly="True" SortExpression="id" ControlStyle-Width="70px" />
            <asp:BoundField DataField="descripcion" HeaderText="Descripcion" InsertVisible="False" ReadOnly="True" SortExpression="descripcion" ControlStyle-Width="70px" />
            <asp:BoundField DataField="fecha_ingreso" HeaderText="Fecha de Ingreso" ReadOnly="True" SortExpression="fecha_ingreso" ControlStyle-Width="300px" />
            <asp:BoundField DataField="fecha_salida" HeaderText="Fecha de Salida" ReadOnly="True" SortExpression="fecha_salida" />
            <asp:BoundField DataField="tratamiento" HeaderText="Tratamiento" ReadOnly="True" SortExpression="tratamiento" />
            <asp:BoundField DataField="observaciones" HeaderText="Obseervaciones" ReadOnly="True" SortExpression="observaciones" />
            <asp:BoundField DataField="estatus" HeaderText="Estatus" ReadOnly="True" SortExpression="estatus" />
            <asp:BoundField DataField="id_animal" HeaderText="Animal" ReadOnly="True" SortExpression="id_animal" />
            <asp:BoundField DataField="id_veterinario" HeaderText="Veterinario" ReadOnly="True" SortExpression="veterinario" />
            <asp:BoundField DataField="concentrado" HeaderText="Concentrado" ReadOnly="True" SortExpression="concentrado" />
 
            <%--botones de acción sobre los registros...
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px">
                <ItemTemplate>--%>
                    <%--Botones de eliminar y editar cliente...
                    <asp:Button ID="btnDelete" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Eliminar" OnClientClick="return confirm('¿Eliminar registro?'); "  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
                    <asp:Button ID="btnEdit" runat="server" Text="Editar" CssClass="btn btn-info" CommandName="Editar" OnClientClick="return confirm('¿Editar registro?'); "  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                </ItemTemplate>
            </asp:TemplateField>
            --%>

           
        </Columns>
    </asp:GridView>

    <center>
        <div class="form-group"> <!-- Button -->
            <asp:Button ID="btnInsertar" runat="server" Text="Insertar" class="btn btn-primary" center-align="true" OnClick="btnInsertar_Click" />
        </div>     
    </center>

</asp:Content>

