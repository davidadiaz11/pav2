using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GestorTransporte
/// </summary>
public class GestorTransporte
{
	public GestorTransporte()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static DataTable ObtenerTodas()
    {
        SqlConnection cn = new SqlConnection(GestorHotel.CadenaConexion);
        DataTable dt = new DataTable();

        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cn;
            cmd.Parameters.Clear();
            cmd.Connection = cn;
            cmd.CommandText = "select * from Transporte order by descripcion;";
            dt.Load(cmd.ExecuteReader());

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