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
            sql = "insert into Paquete(descripcion, promocion, precio, fechaSalida, fechaLlegada) values(@descripcion, @promocion, @precio, @fechaSalida, @fechaLlegada)";
            cmd.Parameters.Add(new SqlParameter("@descripcion", p.descripcion));
            cmd.Parameters.Add(new SqlParameter("@promocion", p.promocion));
            cmd.Parameters.Add(new SqlParameter("@precio", p.precio));
            cmd.Parameters.Add(new SqlParameter("@fechaSalida", p.fechaSalida));
            cmd.Parameters.Add(new SqlParameter("@fechaLlegada", p.fechaLlegada));


            //sql = "insert into PaqueteXUsuario(idPaquete,idUsuario) values (@idPaquete, @idUsuario);";
            //cmd.Parameters.Add(new SqlParameter("@idPaquete", p.id));
            //cmd.Parameters.Add(new SqlParameter("@idUsuario", HttpContext.Current.User.Identity.Name.ToString()));



            //TODO 10.0 esto debería hacerse para grabar en los viajes
            //esta mal pasado el parametro cantidad... arreglar esto
            //foreach (ItemPaquete itempaq in p.items)
            //{
            //    sql = "update Viaje set cupo=cupo-" + itempaq.cantidad + "  where id=@id";
            //    cmd.Parameters.Add(new SqlParameter("@paquete", p.id));
            //    cmd.Parameters.Add(new SqlParameter("@id", itempaq.id));

            //    sql = "insert into ViajeXPaquete(idViaje,idPaquete) values(@idViaje, @idPaquete);";
            //    cmd.Parameters.Add(new SqlParameter("@idViaje", itempaq.id));
            //    cmd.Parameters.Add(new SqlParameter("@idPaquete", p.id));
            //}


            ////esto se debe hacer al comprar efectivamente
            //foreach (ItemPaquete itempaq in p.items)
            //{
            //    sql = @"update Viaje set disponible=@disponible where fechaSalida <= GETDATE() OR cupo=@cupo";
            //    cmd.Parameters.Add(new SqlParameter("@disponible", 0));
            //    cmd.Parameters.Add(new SqlParameter("@cupo", 0));
            //}



            cmd.CommandText = sql;
            int filasAfetadas = cmd.ExecuteNonQuery();
            if (filasAfetadas==0)
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