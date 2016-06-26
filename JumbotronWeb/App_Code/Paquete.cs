using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Paquete
/// </summary>
public class Paquete
{
	public Paquete()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public int id { get; set; }

    public string descripcion { get; set; }

    public int precio { get; set; }

    public int promocion { get; set; }

    public DateTime fechaSalida { get; set; }

    public DateTime fechaLlegada { get; set; }

    public List<ItemPaquete> items { get; set; }
}