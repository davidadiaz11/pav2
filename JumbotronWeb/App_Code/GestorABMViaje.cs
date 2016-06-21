using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GestorABMViaje
/// </summary>
public class GestorABMViaje
{
    public GestorABMViaje()
    {

    }


    public static DataTable buscarPorDescripcion(string descripcion, string orden, bool eliminados, out int cantEncontrados)
    {
        DataTable dt = new DataTable();
        SqlConnection cn = new SqlConnection(GestorHotel.CadenaConexion);
        string sql;
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Parameters.Clear();
            if (!eliminados)
            {
                sql = "select v.id, v.descripcion, v.precio, v.fechaSalida, v.fechallegada, v.cupo, v.disponible, h.descripcion hotelNombre, d.descripcion destinoNombre,t.descripcion transporteNombre";
                sql += " from Viaje v join Hotel h";
                sql += " on v.hotel=h.id ";
                sql += " join Destino d on v.destino=d.id";
                sql += " join Transporte t on v.transporte=t.id";
                sql += " where (v.eliminado is NULL OR v.eliminado=0) AND v.descripcion like @descripcion order by " + orden;
                cmd.Parameters.Add(new SqlParameter("@descripcion", "%" + descripcion + "%"));
            }
            else
            {
                sql = "select v.id, v.descripcion, v.precio, v.fechaSalida, v.fechallegada, v.cupo, v.disponible, h.descripcion hotelNombre, d.descripcion destinoNombre,t.descripcion transporteNombre";
                sql += " from Viaje v join Hotel h";
                sql += " on v.hotel=h.id ";
                sql += " join Destino d on v.destino=d.id";
                sql += " join Transporte t on v.transporte=t.id";
                sql += " where ( v.eliminado=1) AND v.descripcion like @descripcion order by " + orden;
                cmd.Parameters.Add(new SqlParameter("@descripcion", "%" + descripcion + "%"));
            }
            cmd.CommandText = sql;

            dt.Load(cmd.ExecuteReader());
            cantEncontrados = dt.Rows.Count;


        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            if (cn != null && cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        return dt;
    }
    public static Viaje buscarPorId(int id, bool eliminados)
    {
        // procedimiento almacenado

        SqlConnection cn = new SqlConnection(GestorHotel.CadenaConexion);
        Viaje h = null;
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
                h = new Viaje();
                h.id = (int)dr["id"];
                h.descripcion = dr["descripcion"].ToString();
                h.destino = (int)dr["destino"];
                h.cupo = (int)dr["cupo"];
                h.disponible = (Boolean)dr["disponible"];
                h.fechaSalida = (DateTime)dr["fechaSalida"];
                h.fechaLlegada = (DateTime)dr["fechaLlegada"];
                h.transporte = (int)dr["transporte"];
                h.hotel = (int)dr["hotel"];
                h.precio = (int)dr["precio"];
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

        return h;
    }

    public static void Grabar(Viaje h, Boolean accion)
    {
        string sql = "";
        SqlConnection cn = new SqlConnection(GestorHotel.CadenaConexion);
        if (accion)
            sql = @"insert  into Viaje (descripcion, cupo, destino, hotel, eliminado, fechaLlegada, fechaSalida, transporte, disponible, imagen, precio) values(@descripcion, @cupo, @destino, @hotel, @eliminado, @fechaLlegada, @fechaSalida, @transporte, @disponible, @imagen, @precio);";
        else
            sql = @"update Viaje set descripcion=@descripcion , hotel=@hotel, precio=@precio, fechaSalida=@fechaSalida, fechaLlegada=@fechaLlegada, destino=@destino, cupo=@cupo, transporte=@transporte, disponible=@disponible, eliminado=@eliminado where imagen=@imagen;";

        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cn;
            cmd.Parameters.Clear();
            cmd.Connection = cn;
            cmd.CommandText = sql; //descripcion del procedimiento q debe ir a buscar
            cmd.Parameters.Add(new SqlParameter("@descripcion", h.descripcion));
            cmd.Parameters.Add(new SqlParameter("@destino", h.destino.ToString()));
            cmd.Parameters.Add(new SqlParameter("@hotel", h.hotel.ToString()));
            cmd.Parameters.Add(new SqlParameter("@transporte", h.transporte.ToString()));
            cmd.Parameters.Add(new SqlParameter("@id", h.id));
            cmd.Parameters.Add(new SqlParameter("@imagen", h.imagen));
            cmd.Parameters.Add(new SqlParameter("@cupo", h.cupo));
            cmd.Parameters.Add(new SqlParameter("@precio", h.precio));
            cmd.Parameters.Add(new SqlParameter("@eliminado", DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@disponible", h.disponible));
            cmd.Parameters.Add(new SqlParameter("@fechaLlegada", h.fechaLlegada));
            cmd.Parameters.Add(new SqlParameter("@fechaSalida", h.fechaSalida));
            //cmd.CommandType = CommandType.Text; // es necesario setear esta propiedad el valor por defecto es  CommandType.Text
            int filasAfetadas = cmd.ExecuteNonQuery();
            if (filasAfetadas == 0)
            {
                throw new Exception("El registro ya existe en la base");
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


    }



    public static bool existeImagen(string imagen, out int idExistente, out string destinoExistente)
    {
        string sql = "";
        SqlConnection cn = new SqlConnection(GestorHotel.CadenaConexion);
        sql = @"SELECT  id, destino  FROM  Viaje WHERE  imagen like @imagen;";
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cn;
            cmd.Parameters.Clear();
            cmd.Connection = cn;
            cmd.CommandText = sql;

            cmd.Parameters.Add(new SqlParameter("@imagen", imagen));

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                idExistente = (int)dr["id"];
                destinoExistente = GestorViaje.obtenerDescripcion("Destino", (int)dr["destino"]);
                return true;
            }
            idExistente = 0;
            destinoExistente = "";
            return false;
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
    public static void Eliminar(int id)
    {
        SqlConnection cn = new SqlConnection(GestorHotel.CadenaConexion);
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cn;
            cmd.Parameters.Clear();
            cmd.Connection = cn;
            cmd.CommandText = @"update Viaje set eliminado=@eliminado where id=@id";
            cmd.Parameters.Add(new SqlParameter("@eliminado", 1));
            cmd.Parameters.Add(new SqlParameter("@id", id));
            //cmd.CommandType = CommandType.Text; // es necesario setear esta propiedad el valor por defecto es  CommandType.Text
            int filasAfetadas = cmd.ExecuteNonQuery();
            if (filasAfetadas == 0)
            {
                throw new Exception("El registro ya no existe en la base");
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
    }
}