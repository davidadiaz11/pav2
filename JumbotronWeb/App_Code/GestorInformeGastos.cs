using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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


    public static  DataTable filtrar(string precio, string fecha)
    {

        SqlConnection cn = new SqlConnection(GestorHotel.CadenaConexion);
        DataTable dt = new DataTable();
        string sql;

        try
        {


            cn.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cn;
            cmd.Parameters.Clear();
            cmd.Connection = cn;

            sql = "select id, montoTotal, fecha, cantPaquetes from Compra ;";
            cmd.CommandText = sql;


            if (precio != "" && fecha != "")
            {
                sql = "select * from Compra where montoTotal<=@montoTotal and fecha=@fecha ;";
                cmd.CommandText = sql;
                cmd.Parameters.Add(new SqlParameter("@montoTotal", precio));
                cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
                //cmd.Parameters.Add(new SqlParameter("@destino", destino));
            }

            if (precio != "" && fecha == "")
            {
                sql = "select * from Compra where montoTotal<=@montoTotal;";
                cmd.CommandText = sql;
                cmd.Parameters.Add(new SqlParameter("@montoTotal", precio));
                //cmd.Parameters.Add(new SqlParameter("@destino", destino));
            }

            if (precio == "" && fecha != "")
            {
                sql = "select * from Compra where fecha=@fecha ;";
                cmd.CommandText = sql;
                cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
                //cmd.Parameters.Add(new SqlParameter("@destino", destino));
            }


        }
        catch (Exception)
        {
            
            throw;
        }

        finally
        {
            if (cn != null && cn.State == ConnectionState.Open)
                cn.Close();
        }

        return dt;

    }
}