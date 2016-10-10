using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLayer;
using Proyectofactura.Data;



namespace BusinessVentas
{
    public class BusisnessVentas
    {
        ClienteDAL clie = new ClienteDAL();
        CategoriaDAL cat = new CategoriaDAL();
        ProductoDAL prod = new ProductoDAL();

        #region Cliente
        public int CrearCliente(Cliente cliente)
        {
            try
            {
                return clie.CrearCliente(cliente);
            }
            catch (Exception err)
            {

                throw err;
            }
        }

        public List<Cliente> listarClientes()
        {
            return clie.ListarCliente();
        }

        public int modificarCliente(Cliente cliente)
        {
            return clie.modificarCliente(cliente);
        }

        public int eliminarCliente(int identificador)
        {
            return clie.eliminarCliente(identificador);
        }
        #endregion


        #region Categoria
        public int igresarCategoria(Categoria categoria)
        {
            return cat.igresarCategoria(categoria);
        }

        public List<Categoria> listarCategotia()
        {
            return cat.listarCategotia();
        }

        public int modificarCategoria(Categoria categoria)
        {
            return cat.modificarCategoria(categoria);
        }

        public int borrarCategoria(int id)
        {
            return cat.borrarCategoria(id);
        }
        #endregion        
        
        #region producto 

        public int crearProducto(Producto producto)
        {
            return prod.crearProducto(producto);
        }


        public List<Producto> listarProducto()
        {
            return prod.listarProducto();
        }
       
        #endregion
    }
}
