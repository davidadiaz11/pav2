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

    public static int grabar(Paquete p)
    {
        string sql = "";
        int idPaquete = -1;
        SqlConnection cn = new SqlConnection(GestorHotel.CadenaConexion);
        SqlTransaction trans = null;
        try
        {
            cn.Open();
            trans = cn.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Transaction = trans;
            cmd.Parameters.Clear();
            cmd.Connection = cn;
            sql = "insert into Paquete(descripcion, promocion, precio, fechaSalida, fechaLlegada) values(@descripcion, @promocion, @precio, @fechaSalida, @fechaLlegada)";
            cmd.CommandText = sql;
            cmd.Parameters.Add(new SqlParameter("@descripcion", "asd"));
            cmd.Parameters.Add(new SqlParameter("@promocion", p.promocion));
            cmd.Parameters.Add(new SqlParameter("@precio", p.precio));
            cmd.Parameters.Add(new SqlParameter("@fechaSalida", p.fechaSalida));
            cmd.Parameters.Add(new SqlParameter("@fechaLlegada", p.fechaLlegada));
            idPaquete = Convert.ToInt32(cmd.ExecuteScalar()) +1;
           

            cmd.Parameters.Clear();
            sql = "insert into PaqueteXUsuario(idPaquete,idUsuario) values (@idPaquete, @idUsuario);";
            cmd.CommandText = sql;
            cmd.Parameters.Add(new SqlParameter("@idPaquete", idPaquete));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", HttpContext.Current.User.Identity.Name.ToString()));
            cmd.ExecuteNonQuery();

            trans.Commit();
            
        }
        catch (Exception ex)
        {
            if (trans != null)
            {
                trans.Rollback();
            }
            if (ex.Message.StartsWith("No hay cupo disponible"))
                throw;  //vuelve a desencadenar la misma excepcion
            else
            {
                throw new Exception(); 
            }
            throw;
        }
        finally
        {
            if (cn != null && cn.State == ConnectionState.Open)
                cn.Close();
        }
        return idPaquete;
    }

    public static int obtenerUltimoId()
    {
        SqlConnection cn = new SqlConnection(GestorHotel.CadenaConexion);
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Parameters.Clear();
            cmd.Connection = cn;
            cmd.CommandText = " select max(id) from Paquete;";
            return (int)cmd.ExecuteScalar();
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}