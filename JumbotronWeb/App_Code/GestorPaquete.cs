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
            cmd.ExecuteNonQuery();



            cmd.Parameters.Clear();
            cmd.CommandText = " select max(id) 'id' from Paquete;";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                idPaquete = (int)dr["id"];
            }
            dr.Close();
           
                                                                                                                                                          
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

    //public static int obtenerUltimoId()
    //{
    //   int  idPaquete =-1;
    //    SqlConnection cn = new SqlConnection(GestorHotel.CadenaConexion);
    //    try
    //    {
    //        cn.Open();
    //        SqlCommand cmd = new SqlCommand();
    //        cmd.Connection = cn;
    //        cmd.Parameters.Clear();
    //        cmd.Connection = cn;
    //        cmd.CommandText = " select max(id) 'id' from Paquete;";
    //        SqlDataReader dr = cmd.ExecuteReader();
    //        while (dr.Read())
    //        {
    //            idPaquete = (int)dr["id"];
    //        }
    //        dr.Close();
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //    return idPaquete;
    //}
}