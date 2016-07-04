using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de GestorInformeViaje
/// </summary>
public class GestorInformeViaje
{
    //se debe filtrar por fecha, pais (mediante combobox) o pasajero 
	public GestorInformeViaje()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public static DataTable filtrar(string precio, string cupo, int destino)
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

            sql = "select id, descripcion, precio, fechaSalida, fechaLlegada, cupo, destino from Viaje ;";
            cmd.CommandText = sql;

            if (precio != "" && cupo != "" && destino != 0)
            {
                sql = "select * from Viaje where precio<=@precio and cupo<=@cupo and destino=@destino;";
                cmd.CommandText = sql;
                cmd.Parameters.Add(new SqlParameter("@precio", precio));
                cmd.Parameters.Add(new SqlParameter("@cupo", cupo));
                cmd.Parameters.Add(new SqlParameter("@destino", destino));
            }

            if (precio != "" && cupo != "" && destino == 0)
            {
                sql = "select * from Viaje where precio<=@precio and cupo<=@cupo;";
                cmd.CommandText = sql;
                cmd.Parameters.Add(new SqlParameter("@precio", precio));
                cmd.Parameters.Add(new SqlParameter("@cupo", cupo));
            }

            if (precio != "" && cupo == "" && destino == 0)
	        {
		        sql = "select * from Viaje where precio<=@precio;";
                cmd.CommandText = sql;
                cmd.Parameters.Add(new SqlParameter("@precio", precio));
	        }

            if (precio == "" && cupo != "" && destino == 0)
            {
                sql = "select * from Viaje where cupo<=@cupo;";
                cmd.CommandText = sql;        
                cmd.Parameters.Add(new SqlParameter("@cupo", cupo));
            }

            if (precio == "" && cupo != "" && destino != 0)
            {
                sql = "select * from Viaje where destino=@destino and cupo<=@cupo;";
                cmd.CommandText = sql;
                cmd.Parameters.Add(new SqlParameter("@destino", destino));
                cmd.Parameters.Add(new SqlParameter("@cupo", cupo));
            }

            if (precio == "" && cupo == "" && destino != 0)
            {
                sql = "select * from Viaje where destino=@destino;";
                cmd.CommandText = sql;
                cmd.Parameters.Add(new SqlParameter("@destino", destino));
            }

            if (precio != "" && cupo == "" && destino != 0)
            {
                sql = "select * from Viaje where destino=@destino and precio<=@precio;";
                cmd.CommandText = sql;
                cmd.Parameters.Add(new SqlParameter("@destino", destino));
                cmd.Parameters.Add(new SqlParameter("@precio", precio));
            }
           
           
              dt.Load(cmd.ExecuteReader());
           

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        finally
        {
            if (cn != null && cn.State == ConnectionState.Open)
                cn.Close();
        }

        return dt;
    }

  }
