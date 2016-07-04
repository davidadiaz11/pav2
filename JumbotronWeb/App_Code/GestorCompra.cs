using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

/// <summary>
/// Descripción breve de GestrorCompra
/// </summary>
public class GestorCompra
{
	public GestorCompra()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public static string BuscarDestinosPaquete(int idPaquete)
    {
        List<ItemPaquete> lista = new List<ItemPaquete>();
        SqlConnection cn = new SqlConnection(GestorHotel.CadenaConexion);
        string sql = "";
        string destinos = "Destinos del paquete: ";
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cn;
            cmd.Parameters.Clear();
            cmd.Connection = cn;

            sql = " select v.destino from ViajeXPaquete vxp on p.id=idPaquete join Viaje v on vxp.idViaje=v.id where vxp.idPaquete=@id ";
           
            cmd.CommandText = sql;
            cmd.Parameters.Add(new SqlParameter("@id",idPaquete));
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                destinos += dr["destino"].ToString() + ", ";
               
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

        return destinos;
    
    }



    //List<ItemPaquete> lista,
    public static string comprar( int montoTotal, int cantPaquetes)
    {
         string sql = "";
         int idCompra=-1;   
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
            sql = "insert into Compra(fecha, montoTotal, cantPaquetes) values(@fecha, @montoTotal, @cantPaquetes)";
            cmd.CommandText = sql;
            cmd.Parameters.Add(new SqlParameter("@fecha", DateTime.Today));
            cmd.Parameters.Add(new SqlParameter("@montoTotal", montoTotal));
            cmd.Parameters.Add(new SqlParameter("@cantPaquetes", cantPaquetes));
            cmd.ExecuteNonQuery();

            sql = "select max(id) 'id' from Compra;";
            cmd.CommandText = sql;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                 idCompra = (int)dr["id"];
            }
            dr.Close();


            cmd.Parameters.Clear();
            sql = "insert into CompraXUsuario(idCompra,idUsuario) values (@idCompra, @idUsuario);";
            cmd.CommandText = sql;
            cmd.Parameters.Add(new SqlParameter("@idCompra", idCompra));
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
            if (ex.Message.StartsWith("Error"))
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
        return "La compra se realizo con exito";
        
    }
       
    }



    //foreach (ItemPaquete item in lista)
    //{
    //    sql = "update Viaje set cupo=cupo-" + item.cantidad + " where id=@id";
    //    cmd.Parameters.Add(new SqlParameter("@id", item.id));
    //    cmd.CommandText = sql;
    //    int i = cmd.ExecuteNonQuery();
    //    if (i == 0)
    //    {
    //        throw new Exception();
    //    }
    //}

