using System;
using System.Collections.Generic;
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
        //select EsAdministrador from usuarios u where u.nombre=@usuario

        if (EsAdministrador == null)
            return new string[] { "" };
        else if (EsAdministrador == true)
            return new string[] {"Administradores"};
        else
            return new string[] {"Pasajeros"}; 
    }
    
    public static bool VerificarUsuarioClave(string usuario, string clave)
    {
        // aqui iria codigo que verificaria si el usuario y clave existe en la base de datos;
        if (usuario.ToLower() == "admin" && clave == "asd") return true;
        if (usuario.ToLower() == "pasajero" && clave == "asd") return true;
        return false;
    }


}
