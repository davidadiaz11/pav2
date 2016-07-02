using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

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

    public static void comprar(List<ItemPaquete> lista)
    {
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
    }

}