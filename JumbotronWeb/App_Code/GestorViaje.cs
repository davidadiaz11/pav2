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

    public static int recuperarPais(int id) //toma por parámetro el id de un Viaje y devuelve el id de país al que corresponde
    {
        SqlConnection cn = new SqlConnection(GestorHotel.CadenaConexion);
        int pais=1;
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Parameters.Clear();
            cmd.Connection = cn;
            string sql = "select d.pais "
                        + "from Destino d "
                        + "join Hotel h on d.id=h.destino "
                        + "join Viaje v on h.id=v.hotel "
                        + "where v.id=@id";
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.CommandText = sql;
            SqlDataReader dr = cmd.ExecuteReader();
            //TODO 02 no funciona
            //pais = (int)dr["pais"];
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
        return pais;
    }

    public static List<Viaje> BuscarPorPais(int? id) //toma por parámetro un id de País, y devuelve una lista de Viajes de ese país
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
            string sql = "";
            if (id != null) //TODO 01 Refactorizar!
            {
                if (id == 0)
                    sql = "select id, descripcion, imagen, precio from Viaje";
                else
                { 
                    sql = "select v.id, v.descripcion, v.imagen, v.precio "
                          + "from Viaje v "
                          + "join Hotel h on v.hotel=h.id "
                          + "join Destino d on h.destino=d.id "
                          + "where d.pais=@id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                }
            }
            else
                sql = "select id, descripcion, imagen, precio from Viaje";
            
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