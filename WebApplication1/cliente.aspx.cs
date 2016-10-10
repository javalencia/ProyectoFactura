using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessVentas;
using SharedLayer; 

namespace WebApplication1
{    
    public partial class WebForm1 : System.Web.UI.Page
    {
        BusisnessVentas negocio = new BusisnessVentas();
        Boolean editar;

        protected void Page_Load(object sender, EventArgs e)
        {
            editar = false;
            this.ActualizarGrid();
            
        }

        public void ActualizarGrid() 
        {
            GvClientes.DataSource = negocio.listarClientes();
            GvClientes.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiarCajas();
        }

        public void limpiarCajas()
        {
            lblId.Text = "id";
            txtNombre.Text = "";
            txtCedula.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtemail.Text = "";
        
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            if (lblId.Text=="id")
            {
                Cliente cliente = new Cliente
                {
                    nombre = txtNombre.Text,
                    telefono = txtTelefono.Text,
                    cedula = txtCedula.Text,
                    direccion = txtDireccion.Text,
                    email = txtemail.Text
                };

                negocio.CrearCliente(cliente);
                this.limpiarCajas();   
               
            }
            else
            {
                
                Cliente cliente = new Cliente
                {
                    id = Convert.ToInt16(lblId.Text),
                    nombre = txtNombre.Text,
                    telefono = txtTelefono.Text,
                    cedula = txtCedula.Text,
                    direccion = txtDireccion.Text,
                    email = txtemail.Text
                };
               
                negocio.modificarCliente(cliente);
                
                this.ActualizarGrid();
            }
        }

        protected void GvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow row = GvClientes.SelectedRow;
            editar = true;

            lblId.Text = row.Cells[1].Text;
            txtNombre.Text = row.Cells[2].Text;
            txtCedula.Text = row.Cells[3].Text;
            txtDireccion.Text = row.Cells[4].Text;
            txtTelefono.Text = row.Cells[5].Text;
            txtemail.Text = row.Cells[6].Text;
            

        }

        protected void GvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvClientes.PageIndex = e.NewPageIndex;
            this.ActualizarGrid();
        }

        protected void GvClientes_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            
            //int id = Convert.ToInt16(lblId.Text);
            //negocio.eliminarCliente(id);
        }

        protected void GvClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(this.GvClientes.DataKeys[e.RowIndex].Value.ToString());
            negocio.eliminarCliente(id);
            this.ActualizarGrid();
        } 
    }
}