using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLayer;
using System.Data.SqlClient;

namespace Proyectofactura.Data
{
    public class CategoriaDAL
    {
        private string datosConexion = "Server=JHONATAN-PC;Database=casa;Trusted_Connection=True";

        public int igresarCategoria(Categoria categoria) 
        {
            int numCategoria = 0;

            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = this.datosConexion;
                    con.Open();

                    String query = "INSERT INTO categoria (nombre_categoria) VALUES ('" + categoria.nombre + "')";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception err)
            {
                
                throw err;
            }

            return numCategoria;
        }

        public List<Categoria> listarCategotia() 
        {
            List<Categoria> lista = new List<Categoria>();

            try
            {
                using (SqlConnection con = new SqlConnection())
                {

                    con.ConnectionString = this.datosConexion;
                    con.Open();

                    String query = "SELECT * FROM categoria";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader lector = cmd.ExecuteReader();

                    while (lector.Read())
                    {
                        Categoria categoria = new Categoria
                        {
                            id = Convert.ToInt32(lector["id_categoria"]),
                            nombre = Convert.ToString(lector["nombre_categoria"])
                        };
                        lista.Add(categoria);
                    }
                }
            }
            catch (Exception err)
            {
                
                throw err;
            }

            return lista;
        }

       
        public int modificarCategoria(Categoria categoria)
        {
            int numcategoria = 0;

            try
            {
                    using (SqlConnection con = new SqlConnection())
                    {
                          con.ConnectionString = this.datosConexion;
                          con.Open();

                          String query = "UPDATE categoria SET nombre_categoria='"+categoria.nombre+"' WHERE id_categoria='"+categoria.id+"'";
                          SqlCommand cmd = new SqlCommand(query, con);
                          cmd.ExecuteNonQuery();
                   }
            }
            catch (Exception err)
            {
                
                throw err;
            }
            return numcategoria;
        }


        public int borrarCategoria(int id)
        {
            int numCategoria = 0;

            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = this.datosConexion;
                    con.Open();

                    String query = " DELETE FROM categoria WHERE id_categoria='" + id + "'";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception err)
            {
                
                throw err;
            }

            return numCategoria;
        }
    }
}
