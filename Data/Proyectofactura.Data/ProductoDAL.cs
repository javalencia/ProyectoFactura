using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLayer;
using System.Data.SqlClient;


namespace Proyectofactura.Data
{
    public class ProductoDAL
    {
        private string datosConexion = "Server=JHONATAN-PC;Database=casa;Trusted_Connection=True";

      

        #region Crear
        public int crearProducto(Producto producto)
        {
            int numProducto = 0;

            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = this.datosConexion;    
                    con.Open();

                    String query = "INSERT INTO producto (nombre_producto,marca_producto,referencia_producto,precio_producto,cantidad_producto,id_categoria)" +
                                                    "VALUES ('" + producto.nombre + "','" + producto.marca + "','" + producto.referencia + "','" + producto.precio + "','" + producto.cantidad + "','" + producto.id_categoria+ "')";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception err)
            {

                throw err;
            }

            return numProducto;
        }
        #endregion



        #region traer categoria por ID

        public List<Categoria> buscaPorId(int id)
        {
            List<Categoria> lista = new List<Categoria>();

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = this.datosConexion;
                con.Open();

                String query = "SELECT * FROM producto WHERE id_producto='" + id + "' ";
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    Categoria categoria = new Categoria
                    {
                        id = Convert.ToInt32(lector["id_producto"]),
                        nombre = Convert.ToString(lector["nombre_producto"])
                    };
                    lista.Add(categoria);
                }
            }

            return lista;
        }

        #endregion




        #region listar producto

        public List<Producto> listarProducto() 
        {
            List<Producto> lista = new List<Producto>();

            try
            {
                 using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = this.datosConexion;
                    con.Open();

                    String query = "SELECT id_producto,id_categoria,nombre_producto,marca_producto,referencia_producto,precio_producto,cantidad_producto FROM producto";
                    

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader lector = cmd.ExecuteReader();

                    while (lector.Read())
                    {
                        Producto producto = new Producto
                                               {
                                                   id = Convert.ToInt32(lector["id_producto"]),
                                                   nombre = Convert.ToString(lector["nombre_producto"]),
                                                   marca = Convert.ToString(lector["marca_producto"]),
                                                   referencia = Convert.ToString(lector["referencia_producto"]),
                                                   precio = Convert.ToDecimal(lector["precio_producto"]),
                                                   cantidad = Convert.ToInt32(lector["cantidad_producto"]),
                                                   id_categoria = Convert.ToInt32(lector["id_categoria"])
                                               };
                        lista.Add(producto);
                    }
                }
            }
            catch (Exception err)
            {
                
                throw err;
            }

            return lista;
        }

        #endregion

    }
}
