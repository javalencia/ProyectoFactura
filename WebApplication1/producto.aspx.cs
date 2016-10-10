using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessVentas;
using SharedLayer;

namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        BusisnessVentas negocio = new BusisnessVentas();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.cargarDropdownlist();
            this.actualizarGridView();
        }


        public void actualizarGridView() 
        {
            gvproducto.DataSource = negocio.listarProducto();
            gvproducto.DataBind();
        }

        public void cargarDropdownlist()  
        {
            if (!IsPostBack)
            {
                ddlCategory.DataSource = negocio.listarCategotia();
                ddlCategory.DataTextField = "nombre";
                ddlCategory.DataValueField = "id";
                ddlCategory.DataBind();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiarCajas();

        }

        public void limpiarCajas() 
        {
            txtNombre.Text = "";
            txtMarca.Text = "";
            txtReferencia.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            this.cargarDropdownlist();
            
           
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
          
            int  idCategoria = Convert.ToInt32(ddlCategory.SelectedValue);
            Producto producto = new Producto
                                {   
                                    nombre = txtNombre.Text,
                                    marca = txtMarca.Text,
                                    referencia = txtReferencia.Text,
                                    precio = Convert.ToDecimal(txtPrecio.Text),
                                    cantidad = Convert.ToInt32(txtCantidad.Text),
                                    id_categoria = idCategoria
                                };
            this.negocio.crearProducto(producto);
            this.limpiarCajas();
            this.actualizarGridView();

        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


    }
}