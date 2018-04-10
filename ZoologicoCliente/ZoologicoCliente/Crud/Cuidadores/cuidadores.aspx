<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="cuidadores.aspx.cs" Inherits="Crud_Cuidadores_cuidadores" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <br />
    <div class="white">

        <h1>Tabla de Cuidadores</h1>
        <div class="form-group floatButton" > <!-- Button -->
            <asp:Button ID="btnAsigna" runat="server" Text="Asignar" class="btn btn-success" center-align="true" OnClick="btnCuida_Click" />
        </div>
        <br />

        <div class="table bs-table">
            <asp:GridView ID="GridView_Cuidadores" runat="server"
                AutoGenerateColumns="False" 
                CssClass="table table-bordered bs-table" 
                DataKeyNames="id" 
                allowpaging="true" OnRowCommand="GridView_Cuidadores_RowCommand" OnPageIndexChanging="GridView_Cuidadores_PageIndexChanging" >   
 
                <Columns>
            
                    <%--campos no editables...--%>
                    <asp:BoundField DataField="id" HeaderText="Numero" InsertVisible="False" ReadOnly="True" SortExpression="id" ControlStyle-Width="70px" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" InsertVisible="False" ReadOnly="True" SortExpression="nombre" ControlStyle-Width="70px" />
                    <asp:BoundField DataField="apellidos" HeaderText="Apellidos" ReadOnly="True" SortExpression="apellidos" ControlStyle-Width="300px" />
                    <asp:BoundField DataField="nacionalidad" HeaderText="Nacionalidad" ReadOnly="True" SortExpression="nacionalidad" />
                    <asp:BoundField DataField="telefono" HeaderText="Telefono" ReadOnly="True" SortExpression="telefono" />
                    <asp:BoundField DataField="estatus" HeaderText="Estatus" ReadOnly="True" SortExpression="estatus" />
                    <asp:BoundField DataField="fecha_ingreso" HeaderText="Fecha de ingreso" ReadOnly="True" SortExpression="fecha_ingreso" />
            
 
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
        </div>

        <center>
            <div class="form-group"> <!-- Button -->
                <asp:Button ID="btnInsertar" runat="server" Text="Insertar" class="btn btn-primary" center-align="true" OnClick="btnInsertar_Click" />
            </div>  
        </center>
    
    </div>

</asp:Content>

