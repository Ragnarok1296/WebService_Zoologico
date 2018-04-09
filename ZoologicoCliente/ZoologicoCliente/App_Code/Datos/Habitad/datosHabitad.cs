using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de datosHabitad
/// </summary>
public class datosHabitad
{

    private string id;
    private string descripcion;
    private string clima;
    private decimal dimension;

    public datosHabitad() {}

    public string Id {
        get => id;
        set => id = value;
    }

    public string Descripcion {
        get => descripcion;
        set => descripcion = value;
    }

    public string Clima {
        get => clima;
        set => clima = value;
    }

    public decimal Dimension {
        get => dimension;
        set => dimension = value;
    }

}