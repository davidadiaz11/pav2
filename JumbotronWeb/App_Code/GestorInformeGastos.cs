using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de GestorInformeGastos
/// </summary>
public class GestorInformeGastos
{
	public GestorInformeGastos()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    //filtra por FECHA, MONTO O PASAJE (por pasaje debe ser combobox)
    public static void obtenerGastos (string usuario)
    {
        string sql = "";

        sql = "select * from CompraxUsuario";
    }
}