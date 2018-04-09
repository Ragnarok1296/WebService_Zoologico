using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de datosCuidadores
/// </summary>
public class datosCuidadores
{

    private string id;
    private string nombre;
    private string apellidos;
    private string nacionalidad;
    private string telefono;
    private string estatus;
    private string fecha_ingreso;

    public datosCuidadores() {}

    public string Id {
        get => id;
        set => id = value;
    }

    public string Nombre {
        get => nombre;
        set => nombre = value;
    }

    public string Apellidos {
        get => apellidos;
        set => apellidos = value;
    }

    public string Nacionalidad {
        get => nacionalidad;
        set => nacionalidad = value;
    }

    public string Telefono {
        get => telefono;
        set => telefono = value;
    }

    public string Estatus {
        get => estatus;
        set => estatus = value;
    }
    public string Fecha_ingreso {
        get => fecha_ingreso;
        set => fecha_ingreso = value;
    }

}