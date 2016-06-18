using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ItemPaquete
/// </summary>
public class ItemPaquete
{
	public ItemPaquete()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public int id { get; set; }

    public int hotel { get; set; }

    public string hotel_descripcion { get; set; }

    public int precioUnitario { get; set; }

    public DateTime fechaSalida { get; set; }

    public int destino { get; set; }

    public string destino_descripcion { get; set; } //será el "título" que se muestre de un viaje. como es int, hay q usar el método "GestorViaje.obtenerDescripcion("destino", viaje.destino);" 

    public int cantidad { get; set; }

    public int subTotal
    {
        get { return cantidad * precioUnitario; }
    }

    public int cupo { get; set; }
}