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
    public static string cadena_conexion = @"Data Source=DAVID-PC\SQLEXPRESS;Initial Catalog=4K1_62726;Integrated Security=True";
	public GestorDestino()
	{
		
	}

    public static DataTable ObtenerTodas()
    {              
       

             //string CadenaConexion = "Data Source=MAQUIS;Initial Catalog=4K1_62726;User ID=avisuales2;Password=avisuales2";
        SqlConnection cn = new SqlConnection(cadena_conexion);
             Hotel c2 = null;
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