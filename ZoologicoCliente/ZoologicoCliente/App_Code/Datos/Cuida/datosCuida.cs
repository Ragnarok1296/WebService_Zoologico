using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de datosCuida
/// </summary>
public class datosCuida
{
    private int id;
    private string id_cuidador;
    private int id_animal;
    private string turno;
    private string fecha;

    public datosCuida() { }

    public int Id {
        get => id;
        set => id = value;
    }

    public string Id_cuidador {
        get => id_cuidador;
        set => id_cuidador = value;
    }

    public int Id_animal {
        get => id_animal;
        set => id_animal = value;
    }

    public string Turno {
        get => turno;
        set => turno = value;
    }

    public string Fecha {
        get => fecha;
        set => fecha = value;
    }
}