using Adopcion_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adopcion
{
    public partial class EditarRefugio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtDireccion2.Text) ||
                string.IsNullOrEmpty(ddlEstado.SelectedValue))
            {
                Label1.Text = "Por favor completa los campos obligatorios.";
                Label1.CssClass = "text-danger";
                return;
            }

            // Recuperar el ID de la URL para saber a quién actualizar
            string idStr = Request.QueryString["id"];
            if (string.IsNullOrEmpty(idStr))
            {
                Label1.Text = "Error: Se perdió el ID del refugio.";
                return;
            }

            int idRefugio = int.Parse(idStr);

            AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();

            // Llamamos a la función de editar
            string resultado1 = servicio.EditarRefugio(idRefugio,
                                              txtNombre.Text,
                                              txtDireccion2.Text,
                                              ddlEstado.SelectedValue,
                                              txtRefe.Text);

   

            if (resultado1.Contains("correctamente"))
            {
                Response.Redirect("Admin_refugios.aspx");
            }
            else
            {
                Label1.Text = resultado1;
                Label1.CssClass = "text-danger";
            }
        }


        protected void txtNombre_Load(object sender, EventArgs e)
        {
        }
    }
}