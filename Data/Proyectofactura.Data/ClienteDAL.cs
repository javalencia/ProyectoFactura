using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SharedLayer;


namespace Proyectofactura.Data
{
    public class ClienteDAL
    {
        private string datosConexion = "Server=JHONATAN-PC;Database=casa;Trusted_Connection=True";
        


        public int  CrearCliente(Cliente cliente)
        {
            int numCliente = 0;
            try
            {
                using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = this.datosConexion;
                con.Open();

                string query = "INSERT INTO cliente (nombre_cliente, cedula_cliente, direccion_cliente, telefono_cliente , email_cliente) VALUES ('"+cliente.nombre+"', '"+cliente.cedula+"', '"+cliente.direccion+"','"+cliente.telefono+"','"+cliente.email+"')";

                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally 
                {
                    con.Close();
                }
            
            }
            }
            catch (Exception e)
            {
                
                throw e;
            }
            return numCliente;
        }

        public List<Cliente> ListarCliente() 
        {
            List<Cliente> lista = new List<Cliente>();

            try
            {
                using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = this.datosConexion;
                con.Open();

                string query = "SELECT * FROM cliente";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    Cliente cliente = new Cliente
                                            {
                                                id = Convert.ToInt32(lector["id_cliente"]),
                                                nombre = Convert.ToString(lector["nombre_cliente"]),
                                                cedula = Convert.ToString(lector["cedula_cliente"]),
                                                    direccion = Convert.ToString(lector["direccion_cliente"]),
                                                telefono = Convert.ToString(lector["telefono_cliente"]),
                                                email = Convert.ToString(lector["email_cliente"])
                                            };
                    lista.Add(cliente);
                }
            }
            }
            catch (Exception err)
            {
                
                throw err; 
            }

            return lista;
        }

        public int modificarCliente(Cliente cliente) 
        {
            int numCliente = 0;
            
            try
            {
                 using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = this.datosConexion;
                con.Open();

                String query = "UPDATE cliente SET nombre_cliente='"+cliente.nombre+"', cedula_cliente='"+cliente.cedula+"', direccion_cliente='"+cliente.direccion+"',telefono_cliente='"+cliente.telefono+"',email_cliente='"+cliente.email+"' WHERE id_cliente='"+cliente.id+"'";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.ExecuteNonQuery();
            }
            }
            catch (Exception err)
            {
                
                throw err;
            }
            return numCliente;
        }

        public int eliminarCliente(int identificador) 
        {
            int numCliente = 0;

            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = this.datosConexion;
                    con.Open();

                    String query = "DELETE FROM cliente WHERE id_cliente ='" + identificador + "'";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception err)
            {
                
                throw err;
            }
            return numCliente;
        }
	
   


    }

    
}
