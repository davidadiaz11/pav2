using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de GestorPais
/// </summary>
public class GestorPais
{
	public GestorPais()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public static List<Pais> BuscarTodos()
    {
        SqlConnection cn = new SqlConnection(GestorHotel.CadenaConexion);
        Pais p = null;
        Pais pTodos = null;
        List<Pais> listaPaises = new List<Pais>();
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            
            cmd.Connection = cn;
            cmd.Parameters.Clear();
            cmd.Connection = cn;
            string sql="select id, descripcion from Pais order by descripcion";
            cmd.CommandText = sql;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                p = new Pais();
                p.id = (int)dr["id"];
                p.descripcion = (string)dr["descripcion"];
                listaPaises.Add(p);
            }
            //AGREGAMOS UN BOTÓN TODOS
            pTodos = new Pais();
            pTodos.id = 0;
            pTodos.descripcion = "Todos";
            listaPaises.Insert(0,pTodos);
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

        return listaPaises;
    }

}