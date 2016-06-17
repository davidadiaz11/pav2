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
    public static int recuperarPais(int id) //toma por parámetro el id de un Viaje y devuelve el id de país al que corresponde
    {
        SqlConnection cn = new SqlConnection(GestorHotel.CadenaConexion);
        int pais=0;
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Parameters.Clear();
            cmd.Connection = cn;
            string sql = "select d.pais "
                        + "from Destino d "
                        + "join Viaje v on d.id=v.destino "
                        + "where v.id=@id";
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.CommandText = sql;
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            { 
                pais = (int)dr["pais"];
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
        return pais;
    }

    public static string ToString(Viaje v)
    {
        return "Viajá a " + obtenerDescripcion("Destino",v.destino) + " el " + v.fechaSalida.ToString() + " en " + obtenerDescripcion("Transporte",v.transporte) + " a sólo " + v.precio.ToString();
    }

    public static string obtenerDescripcion(string tabla, int id)
    {
        string descripcion="";
        SqlConnection cn = new SqlConnection(GestorHotel.CadenaConexion);
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Parameters.Clear();
            cmd.Connection = cn;
            string sql = "select descripcion from "+ tabla +" where id=@id";
            //cmd.Parameters.Add(new SqlParameter("@tabla", tabla));
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.CommandText = sql;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                descripcion = (string)dr["descripcion"];
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
        return descripcion;
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
                    sql = "select id, descripcion, imagen, precio, destino, transporte from Viaje";
                else
                { 
                    sql = "select v.id, v.descripcion, v.imagen, v.precio, v.destino, v.transporte " 
                    +"from Viaje v " 
                    +"join Destino d on v.destino=d.id "
                    +"where d.pais=@id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                }
            }
            else
                sql = "select id, descripcion, imagen, precio, destino, transporte from Viaje";
            
            cmd.CommandText = sql;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                v = new Viaje();
                v.id= (int)dr["id"];
                v.destino = (int)dr["destino"];
                v.destino_descripcion = obtenerDescripcion("Destino", v.id);
                v.transporte = (int)dr["transporte"];
                v.imagen= (string)dr["imagen"];
                v.precio = (int)dr["precio"];
                
                v.descripcion = ToString(v);
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


    public static Viaje buscarPorId(int id, bool eliminados)
    {
        // procedimiento almacenado

        SqlConnection cn = new SqlConnection(GestorHotel.CadenaConexion);
        Viaje v = null;
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cn;
            cmd.Parameters.Clear();
            cmd.Connection = cn;
            string sql = "";
            if (eliminados)
                sql = "select * from Viaje where id = @id AND eliminado=1";
            else
                sql = "select * from Viaje where id = @id AND (eliminado is NULL OR eliminado=0)";
            cmd.CommandText = sql;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            //cmd.Parameters.Add(new SqlParameter("@eliminado", 0));

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                v = new Viaje();
                v.id = (int)dr["id"];
                //h.descripcion = dr["descripcion"].ToString();
                v.imagen = dr["imagen"].ToString();
                v.hotel = (int)dr["hotel"];
                v.precio = (int)dr["precio"];
                v.fechaSalida = (DateTime)dr["fechaSalida"];
                v.fechaLlegada = (DateTime)dr["fechaLlegada"];
                v.destino = (int)dr["destino"];
                v.destino_descripcion = obtenerDescripcion("Destino", v.id);
                v.cupo = (int)dr["cupo"];
                v.transporte = (int)dr["transporte"];
                v.disponible = (Boolean)dr["disponible"];
                v.descripcion = ToString(v);
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

        return v;
    }

    public static void descontarCupo (List<Viaje> lista)
    {
        //para cada id de viaje, hacer un método update q actualice el cupo del viaje, restando la cantidad indicada en "cantidad" ya q puede comprar muchos viajes

        //acá se debe llamar a un método que ponga en "no disponible" a aquellos viajes con cupo=0
    }



}