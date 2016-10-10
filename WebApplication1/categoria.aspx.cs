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
    public partial class WebForm2 : System.Web.UI.Page
    {
        BusisnessVentas negocio = new BusisnessVentas();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
                this.ActualizarGrid();
           
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {   
            if (lblId.Text == "id")
            {
                Categoria categoria = new Categoria
                {
                    nombre = txtNombre.Text
                };
                negocio.igresarCategoria(categoria);
                this.limpiarCajas();
                this.ActualizarGrid();
            }
            else
            {
                Categoria categoria = new Categoria
                {
                    nombre = txtNombre.Text,
                    id = Convert.ToInt32(lblId.Text)
                };
                negocio.modificarCategoria(categoria);
                this.limpiarCajas();
                this.ActualizarGrid();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiarCajas();
        }

        public void ActualizarGrid() 
        {
            gvCategoria.DataSource = negocio.listarCategotia();
            gvCategoria.DataBind();
        }
        public void limpiarCajas() 
        {
            txtNombre.Text = "";
        }

        protected void gvCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvCategoria.SelectedRow;
            lblId.Text = row.Cells[1].Text;
            txtNombre.Text = row.Cells[2].Text;
        }

        protected void gvCategoria_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            int id = Convert.ToInt32(this.gvCategoria.DataKeys[e.RowIndex].Value.ToString());
            negocio.borrarCategoria(id);
            this.ActualizarGrid();
            
        }
    }
}