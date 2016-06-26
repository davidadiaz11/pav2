using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Viaje
/// </summary>
public class Viaje
{
	public Viaje()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public int id { get; set; }

    public string descripcion { get; set; } //la descripción estará compuesta por un tostring de todos los valores

    public string imagen { get; set; }

    public int hotel { get; set; }

    public int precio { get; set; }

    public DateTime fechaSalida { get; set; }

    public DateTime fechaLlegada { get; set; }

    public int destino { get; set; }

    public string destino_descripcion { get; set; } //será el "título" que se muestre de un viaje. como es int, hay q usar el método "GestorViaje.obtenerDescripcion("destino", viaje.destino);" 

    public int cupo { get; set; }

    public int transporte { get; set; }

    public bool disponible { get; set; }

    public bool eliminado { get; set; }

}