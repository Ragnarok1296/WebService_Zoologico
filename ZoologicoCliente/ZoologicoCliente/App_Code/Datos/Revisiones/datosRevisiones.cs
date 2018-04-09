using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de datosRevisiones
/// </summary>
public class datosRevisiones
{
    private int id;
    private string descripcion;
    private string fecha_ingreso;
    private string fecha_salida;
    private string tratamiento;
    private string observaciones;
    private string estatus;
    private int id_animal;
    private int id_veterinario;
    private int concentrado;

    public datosRevisiones() { }

    public int Id {
        get => id;
        set => id = value;
    }

    public string Descripcion {
        get => descripcion;
        set => descripcion = value;
    }

    public string Fecha_ingreso {
        get => fecha_ingreso;
        set => fecha_ingreso = value;
    }

    public string Fecha_salida {
        get => fecha_salida;
        set => fecha_salida = value;
    }

    public string Tratamiento {
        get => tratamiento;
        set => tratamiento = value;
    }

    public string Observaciones {
        get => observaciones;
        set => observaciones = value;
    }

    public string Estatus {
        get => estatus;
        set => estatus = value;
    }

    public int Id_animal {
        get => id_animal;
        set => id_animal = value;
    }

    public int Id_veterinario {
        get => id_veterinario;
        set => id_veterinario = value;
    }

    public int Concentrado {
        get => concentrado;
        set => concentrado = value;
    }

}