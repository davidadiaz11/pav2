using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de GestorHotel
/// </summary>
public class GestorHotel
{
    public static string cadena_conexion = @"Data Source=DAVID-PC\SQLEXPRESS;Initial Catalog=4K1_62726;Integrated Security=True";
        
		 public static List<Hotel> BuscarPorNombre(string nombre , string orden)
        {
                List<Hotel> listaHotel = new List<Hotel>();

                //string CadenaConexion = "Data Source=MAQUIS;Initial Catalog=4K1_62726;User ID=avisuales2;Password=avisuales2";

                SqlConnection cn = new SqlConnection(cadena_conexion);
              Hotel h2 = null;

             try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                
                cmd.Connection = cn;
                cmd.Parameters.Clear();
                cmd.Connection = cn;
                
                //select h.codigo,h.nombre,h.capacidad,d.descripcion destino, from Hotel h left join Destino d  
                //on h.codigo = d.codigo where h.nombre like @nombre order by "+orden;
                // "select * from Hotel where nombre like @nombre order by "+orden;
                cmd.CommandText = " select h.codigo,h.nombre,h.capacidad,d.descripcion destino_descripcion from Hotel h left join Destino d on h.destino = d.codigo where h.nombre like @nombre order by " + orden;
                cmd.Parameters.Add(new SqlParameter("@nombre", "%"+nombre+"%"));
                //cmd.CommandType = CommandType.Text; // es necesario setear esta propiedad el valor por defecto es  CommandType.Text
                SqlDataReader dr = cmd.ExecuteReader();
                
                // con el resultado cargar una entidad
                while (dr.Read())
                {

                    h2 = new Hotel();
                    h2.nombre = (string)dr["nombre"];
                    h2.nombre = dr["nombre"].ToString();
                    h2.codigo = (int)dr["codigo"];
                   // esto para cada atributo que hacepte valores nulos
                   
                    if (dr["capacidad"]!=DBNull.Value)
                    {
                        h2.capacidad = (int)(dr["capacidad"]);
                    }
                    
                    if (dr["destino_descripcion"] != DBNull.Value)
                    {
                        h2.destino_descripcion = (string)(dr["destino_descripcion"]);
                    }
                    //falta cargar capacidad y demas 
                    listaHotel.Add(h2);
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

               return listaHotel;
	}


         public static Hotel buscarPorId(int codigo)
         {
             // procedimiento almacenado
             //string CadenaConexion = "Data Source=MAQUIS;Initial Catalog=4K1_62726;User ID=avisuales2;Password=avisuales2";

             SqlConnection cn = new SqlConnection(cadena_conexion);
             Hotel h1 = null;
             try
             {
                 cn.Open();
                 SqlCommand cmd = new SqlCommand();
                 
                 cmd.Connection = cn;
                 cmd.Parameters.Clear();
                 cmd.Connection = cn;
                 cmd.CommandText = "select * from Hotel where codigo = @codigo"; //nombre del procedimiento q debe ir a buscar
                 cmd.Parameters.Add(new SqlParameter("@codigo", codigo));
                 //cmd.CommandType = CommandType.Text; // es necesario setear esta propiedad el valor por defecto es  CommandType.Text
                 SqlDataReader dr = cmd.ExecuteReader();
                 // con el resultado cargar una entidad

                 if (dr.Read())
                 {
                     h1 = new Hotel();
                     h1.codigo = (int)dr["codigo"];
                     h1.nombre = dr["nombre"].ToString();
                     h1.cuit = (int)dr["cuit"];
                     h1.capacidad = (int)dr["capacidad"];
                     h1.destino = (int)dr["destino"];
                     //------- da error de convercion cuando se hace la consula
                     //h1.aceptaMascota = (bool)dr["aceptamascota"];  
                    
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

                 return h1;
         }

    

         public static void Eliminar(int codigo)
         {
             //string CadenaConexion = "Data Source=MAQUIS;Initial Catalog=4K1_62726;User ID=avisuales2;Password=avisuales2";

             SqlConnection cn = new SqlConnection(cadena_conexion);
             Hotel h1 = null;
             try
             {
                 cn.Open();
                 SqlCommand cmd = new SqlCommand();
                 
                 cmd.Connection = cn;
                 cmd.Parameters.Clear();
                 cmd.Connection = cn;
                 cmd.CommandText = "delete from Hotel where codigo = @codigo"; //nombre del procedimiento q debe ir a buscar
                 cmd.Parameters.Add(new SqlParameter("@codigo", codigo));
                 //cmd.CommandType = CommandType.Text; // es necesario setear esta propiedad el valor por defecto es  CommandType.Text
                 int filasAfetadas = cmd.ExecuteNonQuery();
                 if (filasAfetadas==0)
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
 
            public static void Grabar(Hotel h)
            {
                  //string CadenaConexion = "Data Source=MAQUIS;Initial Catalog=4K1_62726;User ID=avisuales2;Password=avisuales2";
                  string sql;
                  SqlConnection cn = new SqlConnection(cadena_conexion);
                  Hotel h1 = null;

                 
                if (h.codigo==0)
	            {
                    sql = @"insert  into Hotel (nombre,capacidad,destino,cuit) values(@nombre,@capacidad,@destino,@cuit);";
	            }
                 else
	            {

                    sql = @"update Hotel set nombre=@nombre, capacidad=@capacidad, destino=@destino, cuit=@cuit  where codigo=@codigo;";
	            }

             try
             {
                 cn.Open();
                 SqlCommand cmd = new SqlCommand();
                 
                 cmd.Connection = cn;
                 cmd.Parameters.Clear();
                 cmd.Connection = cn;
                 cmd.CommandText = sql; //nombre del procedimiento q debe ir a buscar
                 cmd.Parameters.Add(new SqlParameter("@nombre", h.nombre));
                 cmd.Parameters.Add(new SqlParameter("@codigo", h.codigo));
                 cmd.Parameters.Add(new SqlParameter("@capacidad", h.capacidad));
                 cmd.Parameters.Add(new SqlParameter("@destino", h.destino));
                 cmd.Parameters.Add(new SqlParameter("@cuit", h.cuit));
                 //cmd.CommandType = CommandType.Text; // es necesario setear esta propiedad el valor por defecto es  CommandType.Text
                 int filasAfetadas = cmd.ExecuteNonQuery();
                  if (filasAfetadas==0)
                 {
                     throw new Exception("El registro ya existe en la base");
                 }      
                 
                }

            catch (Exception ex)
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
        
	
