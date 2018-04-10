<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="reportes.aspx.cs" Inherits="Crud_Reportes_reportes" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <br />
    <div class="white">

        <h1>Tabla de Reportes</h1>
        <br />

        <div class="form-group"> <!-- Anio -->
                <label for="year" class="control-label">Año</label>
                <asp:DropDownList CssClass="form-control" ID="ddlYear" runat="server">
                    <asp:ListItem>2010</asp:ListItem>
                    <asp:ListItem>2011</asp:ListItem>
                    <asp:ListItem>2012</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                </asp:DropDownList>
         </div>

        <div class="form-group"> <!-- Mes -->
                <label for="month" class="control-label">Prestado o Propiedad</label>
                <asp:DropDownList CssClass="form-control" ID="ddlMonth" runat="server">
                    <asp:ListItem>Enero</asp:ListItem>
                    <asp:ListItem>Febrero</asp:ListItem>
                    <asp:ListItem>Marzo</asp:ListItem>
                    <asp:ListItem>Abril</asp:ListItem>
                    <asp:ListItem>Mayo</asp:ListItem>
                    <asp:ListItem>Junio</asp:ListItem>
                    <asp:ListItem>Julio</asp:ListItem>
                    <asp:ListItem>Agosto</asp:ListItem>
                    <asp:ListItem>Septiembre</asp:ListItem>
                    <asp:ListItem>Octubre</asp:ListItem>
                    <asp:ListItem>Noviembre</asp:ListItem>
                    <asp:ListItem>Diciembre</asp:ListItem>
                </asp:DropDownList>
         </div>

        <center>
            <div class="form-group"> <!-- Button -->
                <asp:Button ID="btnGenerar" runat="server" Text="Generar" class="btn btn-primary" center-align="true" OnClick="btnGenerar_Click" />
            </div>     
        </center>

        <br />

        <asp:Label ID="lblTablaCuidadores" runat="server" Font-Size="XX-Large" ForeColor="White" Visible="false">Tabla de Cuidadores</asp:Label>
        <br />
        <div Class="table bs-table">
            <asp:GridView ID="GridView_Reportes_Cuidadores" runat="server"
                AutoGenerateColumns="False"
                CssClass="table table-bordered bs-table"
                DataKeyNames="id"
                AllowPaging="true" OnPageIndexChanging="GridView_Reporte_Cuidadores_PageIndexChanging">

                <Columns>

                    <%--campos no editables...--%>
                    <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" InsertVisible="False" ReadOnly="True" SortExpression="nombre" />
                    <asp:BoundField DataField="apellidos" HeaderText="Apellidos" ReadOnly="True" SortExpression="apellidos" />
                    <asp:BoundField DataField="nacionalidad" HeaderText="Nacionalidad" ReadOnly="True" SortExpression="nacionalidad" />
                    <asp:BoundField DataField="telefono" HeaderText="Telefono" ReadOnly="True" SortExpression="telefono" />
                    <asp:BoundField DataField="estatus" HeaderText="Estatus" ReadOnly="True" SortExpression="estatus" />
                    <asp:BoundField DataField="fecha_ingreso" HeaderText="Fecha Ingreso" ReadOnly="True" SortExpression="fecha_ingreso" />

                </Columns>
            </asp:GridView>
        </div>

        <br />
        <br />

        <asp:Label ID="lblTablaAnimales" runat="server" Font-Size="XX-Large" ForeColor="White" Visible="false">Tabla de Animales</asp:Label>
        <br />
        <div Class="table bs-table">
            <asp:GridView ID="GridView_Reportes_Animales" runat="server"
                AutoGenerateColumns="False"
                CssClass="table table-bordered bs-table"
                DataKeyNames="nombre"
                AllowPaging="true" OnPageIndexChanging="GridView_Reportes_Animales_PageIndexChanging">

                <Columns>

                    <%--campos no editables...--%>
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" InsertVisible="False" ReadOnly="True" SortExpression="nombre" />
                    <asp:BoundField DataField="especie" HeaderText="Especie" InsertVisible="False" ReadOnly="True" SortExpression="especie" />
                    <asp:BoundField DataField="pais_origen" HeaderText="Pais Origen" ReadOnly="True" SortExpression="pais_origen" />
                    <asp:BoundField DataField="sexo" HeaderText="Sexo" ReadOnly="True" SortExpression="sexo" />
                    <asp:BoundField DataField="fecha_ad" HeaderText="Fecha de ingreso" ReadOnly="True" SortExpression="fecha_ad" />
                    <asp:BoundField DataField="estado" HeaderText="Estado" ReadOnly="True" SortExpression="estado" />

                </Columns>
            </asp:GridView>
        </div>

        <br />

    </div>

</asp:Content>

