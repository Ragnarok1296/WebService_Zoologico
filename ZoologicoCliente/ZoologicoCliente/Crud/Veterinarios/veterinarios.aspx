<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="veterinarios.aspx.cs" Inherits="Crud_Cuidadores_veterinarios" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1>Tabla de Veterinarios</h1>
    <div class="form-group floatButton" > <!-- Button -->
        <asp:Button ID="btnRevision" runat="server" Text="Revision" class="btn btn-warning" center-align="true" OnClick="btnRevision_Click" />
    </div>
    <br />

    <asp:GridView ID="GridView_Veterinarios" runat="server"
        AutoGenerateColumns="False" 
        CssClass="table table-bordered bs-table" 
        DataKeyNames="id" 
        allowpaging="true" OnRowCommand="GridView_Veterinarios_RowCommand" OnPageIndexChanging="GridView_Veterinarios_PageIndexChanging" >             
 
        <Columns>
            
            <%--campos no editables...--%>
            <asp:BoundField DataField="id" HeaderText="Numero" InsertVisible="False" ReadOnly="True" SortExpression="id" ControlStyle-Width="70px" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" InsertVisible="False" ReadOnly="True" SortExpression="nombre" ControlStyle-Width="70px" />
            <asp:BoundField DataField="apellidos" HeaderText="Apellidos" ReadOnly="True" SortExpression="apellidos" ControlStyle-Width="300px" />
            <asp:BoundField DataField="especialidad" HeaderText="Especialidad" ReadOnly="True" SortExpression="especialidad" />
            <asp:BoundField DataField="fecha_ingreso" HeaderText="Fecha de ingreso" ReadOnly="True" SortExpression="fecha_ingreso" />
            <asp:BoundField DataField="salario" HeaderText="Salario" ReadOnly="True" SortExpression="salario" />
 
            <%--botones de acción sobre los registros...--%>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px">
                <ItemTemplate>
                    <%--Botones de eliminar y editar cliente...--%>
                    <asp:Button ID="btnDelete" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Eliminar" OnClientClick="return confirm('¿Eliminar registro?'); "  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
                    <asp:Button ID="btnEdit" runat="server" Text="Editar" CssClass="btn btn-info" CommandName="Editar" OnClientClick="return confirm('¿Editar registro?'); "  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                </ItemTemplate>
            </asp:TemplateField>

           
        </Columns>
    </asp:GridView>

    <center>
        <div class="form-group"> <!-- Button -->
            <asp:Button ID="btnInsertar" runat="server" Text="Insertar" class="btn btn-primary" center-align="true" OnClick="btnInsertar_Click" />
        </div>     
    </center>

</asp:Content>

