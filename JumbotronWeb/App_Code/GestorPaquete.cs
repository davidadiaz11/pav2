using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de GestorPaquete
/// </summary>
public class GestorPaquete
{
	public GestorPaquete()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public static void grabar(Paquete p)
    {
        string sql = "";
        SqlConnection cn = new SqlConnection(GestorHotel.CadenaConexion);
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Parameters.Clear();
            cmd.Connection = cn;
            sql = "insert into Paquete(id,descripcion,items) values(@id,@descripcion,@items)";
            cmd.Parameters.Add(new SqlParameter("@id",p.id));
            cmd.Parameters.Add(new SqlParameter("@descripcion", p.descripcion));
            cmd.Parameters.Add(new SqlParameter("@items", p.items));
            cmd.CommandText = sql;
            int filasAfetadas = cmd.ExecuteNonQuery();
            if (filasAfetadas==0)
            {
                 throw new Exception("El registro ya existe en la base");
            }

            sql = "insert into ViajeXPaquete";
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
    }
}