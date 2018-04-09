using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de datosAnimales
/// </summary>
public class datosAnimales
{
    private int id;
    private string nombre;
    private string especie;
    private string pais_origen;
    private string estatus;
    private decimal peso;
    private decimal altura;
    private string dieta;
    private string sexo;
    private string nivel_riesgo;
    private string id_habitad;
    private string pres_prop;
    private string imagen; 
    
    public datosAnimales() {}

    public int Id {
        get => id;
        set => id = value;
    }

    public string Nombre {
        get => nombre;
        set => nombre = value;
    }

    public string Especie {
        get => especie;
        set => especie = value;
    }

    public string Pais_origen {
        get => pais_origen;
        set => pais_origen = value;
    }

    public string Estatus {
        get => estatus;
        set => estatus = value;
    }

    public decimal Peso {
        get => peso;
        set => peso = value;
    }

    public decimal Altura {
        get => altura;
        set => altura = value;
    }

    public string Dieta {
        get => dieta;
        set => dieta = value;
    }

    public string Sexo {
        get => sexo;
        set => sexo = value;
    }

    public string Nivel_riesgo {
        get => nivel_riesgo;
        set => nivel_riesgo = value;
    }

    public string Id_habitad {
        get => id_habitad;
        set => id_habitad = value;
    }

    public string Pres_prop {
        get => pres_prop;
        set => pres_prop = value;
    }

    public string Imagen {
        get => imagen;
        set => imagen = value;
    }

}