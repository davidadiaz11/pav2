using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de GestorDestino
/// </summary>
public class GestorDestino
{
	public GestorDestino()
	{
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
                cmd.CommandText = "select * from Destino order by descripcion;";
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