using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de GestorInformeGastos
/// </summary>
public class GestorInformeGastos
{
	public GestorInformeGastos()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    //filtra por FECHA, MONTO O PASAJE (por pasaje debe ser combobox)
    public static void obtenerGastos (string usuario)
    {
        string sql = "";

        sql = "select * from CompraxUsuario";
    }


    public static  DataTable filtrar(string precio, string fecha, string usuario)
    {

        SqlConnection cn = new SqlConnection(GestorHotel.CadenaConexion);
        DataTable dt = new DataTable();
        string sql;

        try
        {


            cn.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cn;
            cmd.Parameters.Clear();
            cmd.Connection = cn;

            sql = "select id, montoTotal, fecha, cantPaquetes from Compra ;";
            cmd.CommandText = sql;


            if (precio != "" && fecha != ""  && usuario!="" )
            {

                sql = "select id, montoTotal, fecha, cantPaquetes from Compra co join CompraXUsuario cu on  cu.idCompra=co.id where cu.idUsuario=@usuario and montoTotal<=@montoTotal and fecha=@fecha ;";
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@montoTotal", precio));
                cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
                cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
                //cmd.Parameters.Add(new SqlParameter("@destino", destino));
            }

            if (precio == "" && fecha == "" && usuario != "")
            {

                sql = "select id, montoTotal, fecha, cantPaquetes from Compra co join CompraXUsuario cu on  cu.idCompra=co.id where cu.idUsuario=@usuario;";
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@usuario",usuario));
                //cmd.Parameters.Add(new SqlParameter("@destino", destino));
            }

            if (precio != "" && fecha == "" && usuario != "")
            {

                sql = "select id, montoTotal, fecha, cantPaquetes from Compra co join CompraXUsuario cu on  cu.idCompra=co.id where cu.idUsuario=@usuario and montoTotal<=@montoTotal;";
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@montoTotal", precio));
                cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
                
            }

            if (precio == "" && fecha != "" && usuario != "")
            {

                sql = "select id, montoTotal, fecha, cantPaquetes from Compra co join CompraXUsuario cu on  cu.idCompra=co.id where cu.idUsuario=@usuario and fecha=@fecha;";
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
                cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
            
            }

            //if (precio != "" && fecha != "" )
            //{
            //    sql = "select * from Compra where montoTotal<=@montoTotal and fecha=@fecha ;";
            //    cmd.CommandText = sql;
            //    cmd.Parameters.Clear();
            //    cmd.Parameters.Add(new SqlParameter("@montoTotal", precio));
            //    cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
            //    //cmd.Parameters.Add(new SqlParameter("@destino", destino));
            //}

            if (precio != "" && fecha == "" && usuario=="" )
            {
                sql = "select * from Compra where montoTotal<=@montoTotal;";
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@montoTotal", precio));
                //cmd.Parameters.Add(new SqlParameter("@destino", destino));
            }

            if (precio != "" && fecha != "" && usuario == "")
            {
                sql = "select * from Compra where montoTotal<=@montoTotal and fecha=@fecha;";
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@montoTotal", precio));
                //cmd.Parameters.Add(new SqlParameter("@destino", destino));
            }

            if (precio == "" && fecha != "" && usuario=="")
            {
                sql = "select * from Compra where fecha=@fecha ;";
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
                //cmd.Parameters.Add(new SqlParameter("@destino", destino));
            }

            dt.Load(cmd.ExecuteReader());


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

        return dt;

    }
}