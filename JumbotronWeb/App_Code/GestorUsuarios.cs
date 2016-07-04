using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de GestorUsuarios
/// </summary>
public class GestorUsuarios
{
    public GestorUsuarios()
    { }

    public static string[] ObtenerRoles(string usuario)
    {
        bool? EsAdministrador = false;
        //TODO 1001: como hacemos acá para obtener el rol??? averiguar esta parte
        //select EsAdministrador from usuarios u where u.nombre=@usuario

        if (EsAdministrador == null)
            return new string[] { "" };
        else if (EsAdministrador == true)
            return new string[] { "Administradores" };
        else
            return new string[] { "Pasajeros" };
    }

    public static bool VerificarUsuarioClave(string usuario, string clave)
    {
        // aqui iria codigo que verificaria si el usuario y clave existe en la base de datos;
        if (usuario.ToLower() == "admin" && clave == "asd") return true;
        if (usuario.ToLower() == "pasajero" && clave == "asd") return true;
        if (usuario.ToLower() == "nico" && clave == "asd") return true;
        if (usuario.ToLower() == "david" && clave == "asd") return true;
        return false;
    }

    public static List<Usuario> obtenerUsuarios()
    {
        
        List<Usuario> listaUsuario = new List<Usuario>();
        SqlConnection cn = new SqlConnection(GestorHotel.CadenaConexion);
        Usuario h2 = null;

        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cn;
            cmd.Parameters.Clear();
            cmd.Connection = cn;
            string sql = "select id from Usuario;";
            cmd.CommandText = sql;     

            SqlDataReader dr = cmd.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {


                h2 = new Usuario();
                h2.id = (string)dr["id"];
                h2.num = i++;

        

                listaUsuario.Add(h2);
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

        return listaUsuario;
    }

    


}
