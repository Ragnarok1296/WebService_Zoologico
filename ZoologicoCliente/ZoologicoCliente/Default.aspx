<%@ Page Title="Examen Practico" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron imagenAnimales bordes">
        <div class="white">
            <h2>Animales</h2>
            <p><h3>En este apartado tendras un control sobre los animales que tiene el zoologico, para ser mas especificos podras:</h3></p>
            <ul>
                <li type="circle">Ingresar nuevos animales.</li>
                <li type="circle">Modificar su informnacion.</li>
                <li type="circle">Eliminar su informacion.</li>
                <li type="circle">Generar registro medico.</li>
            </ul>
            <p><a href="/Crud/Animales/animales" class="btn btn-primary btn-lg">Ir a &raquo;</a></p>
        </div>
        
    </div>
    
    <div class="jumbotron imagenHabitats bordes">
        <div class="white">
            <h2>Habitats</h2>
            <p><h3>En este apartado tendras un control sobre las habitats que tiene el zoologico, para ser mas especificos podras:</h3></p>
            <ul>
                <li type="circle">Ingresar nuevos habitats.</li>
                <li type="circle">Modificar la informacion.</li>
                <li type="circle">Eliminar la informacion.</li>
            </ul>
            <p><a href="/Crud/Habitats/habitats" class="btn btn-primary btn-lg">Ir a &raquo;</a></p>
        </div>
    </div>

    <div class="jumbotron imagenCuidadores">
        <div class="white">
            <h2>Cuidadores</h2>
            <p><h3>En este apartado tendras un control sobre los cuidadores que tiene el zoologico, para ser mas especificos podras:</h3></p>
            <ul>
                <li type="circle">Ingresar nuevos cuidadores.</li>
                <li type="circle">Modificar su informacion.</li>
                <li type="circle">Eliminar su informacion.</li>
            </ul>
            <p><a href="/Crud/Cuidadores/cuidadores" class="btn btn-primary btn-lg">Ir a &raquo;</a></p>
        </div>
    </div>

    <div class="jumbotron imagenVeterinarios">
        <div class="white">
            <h2>Veterinarios</h2>
            <p><h3>En este apartado tendras un control sobre los veterinarios que tiene el zoologico, para ser mas especificos podras:</h3></p>
            <ul>
                <li type="circle">Ingresar nuevos veterinarios.</li>
                <li type="circle">Modificar su informacion.</li>
                <li type="circle">Eliminar su informacion.</li>
            </ul>
            <p><a href="/Crud/Veterinarios/veterinarios" class="btn btn-primary btn-lg">Ir a &raquo;</a></p>
        </div>
    </div>

</asp:Content>
