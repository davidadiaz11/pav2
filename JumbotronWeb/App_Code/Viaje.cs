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

    public string descripcion { get; set; }

    public string imagen { get; set; }

    public int precio { get; set; }

}