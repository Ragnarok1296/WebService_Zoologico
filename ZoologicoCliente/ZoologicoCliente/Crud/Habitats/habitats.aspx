<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="habitats.aspx.cs" Inherits="Crud_Habitats_habitats"  EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <br />
    <div class="white">

        <h1>Tabla de Habitats</h1>
        <br />

        <div class="table bs-table">
            <asp:GridView ID="GridView_Habitats" runat="server"
                AutoGenerateColumns="False" 
                CssClass="table table-bordered bs-table" 
                DataKeyNames="id" 
                allowpaging="true" OnRowCommand="GridView_Habitads_RowCommand" OnPageIndexChanging="GridView_Habitats_PageIndexChanging" >               
 
                <Columns>
            
                    <%--campos no editables...--%>
                    <asp:BoundField DataField="id" HeaderText="Numero" InsertVisible="False" ReadOnly="True" SortExpression="id" ControlStyle-Width="70px" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" InsertVisible="False" ReadOnly="True" SortExpression="descripcion" ControlStyle-Width="70px" />
                    <asp:BoundField DataField="clima" HeaderText="Clima" ReadOnly="True" SortExpression="clima" ControlStyle-Width="300px" />
                    <asp:BoundField DataField="dimension" HeaderText="Dimension" ReadOnly="True" SortExpression="dimension" />
 
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

