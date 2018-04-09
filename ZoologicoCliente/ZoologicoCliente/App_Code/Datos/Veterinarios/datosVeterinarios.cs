using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de datosVeterinarios
/// </summary>
public class datosVeterinarios
{
    private int id;
    private string nombre;
    private string apellidos;
    private string especialidad;
    private string fecha_ingreso;
    private decimal salario;

    public datosVeterinarios() {}

    public int Id {
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

    public string Especialidad {
        get => especialidad;
        set => especialidad = value;
    }

    public string Fecha_ingreso {
        get => fecha_ingreso;
        set => fecha_ingreso = value;
    }

    public decimal Salario {
        get => salario;
        set => salario = value;
    }

}