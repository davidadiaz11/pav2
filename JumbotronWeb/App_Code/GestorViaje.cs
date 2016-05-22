using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de GestorViaje
/// </summary>
public class GestorViaje
{
	public GestorViaje()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public List<Viaje> BuscarPorCategoria(int id)
    {
        return null;
    }

    public static Viaje BuscarPorId(int id)
    {
        return null;
    }

    public static List<Viaje> BuscarPorPais(int id)
    {
        SqlConnection cn = new SqlConnection(GestorHotel.CadenaConexion);
        Viaje v = null;
        List<Viaje> lista = new List<Viaje>();
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Parameters.Clear();
            cmd.Connection = cn;
            string sql="select * from Viaje";
            //TODO: //string sql = "select v.id, v.descripcion, v.imagen from Viaje v join Hotel h on v.hotel=h.id join Pais p h.pais=p.id where v.id=@id";
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.CommandText = sql;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                v = new Viaje();
                v.id= (int)dr["id"];
                v.descripcion = (string)dr["descripcion"];
                v.imagen= (string)dr["imagen"];
                v.precio = (int)dr["precio"];
                lista.Add(v);
            }
            dr.Close();

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

        return lista;

    }
}