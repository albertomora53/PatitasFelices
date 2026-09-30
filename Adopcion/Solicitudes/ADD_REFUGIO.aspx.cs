using Adopcion_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adopcion
{
    public partial class ADD_REFUGIO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void txtNombre_Load(object sender, EventArgs e)
        {
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // ... (Tu validación de campos obligatorios está bien)

            if (string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtDireccion1.Text) ||
                string.IsNullOrEmpty(ddlEstado.SelectedValue))
            {
                
                Label2.Text = "Por favor completa los campos obligatorios.";
                Label2.CssClass = "text-danger";
                return;
            }

            AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();
            string resultado = servicio.RegistroRefugio(txtNombre.Text,
                                          txtDireccion1.Text,
                                          ddlEstado.SelectedValue,
                                          TxtRef.Text);

            // Actualiza el texto del Label
           Label2.Text = resultado;

            // Asigna la clase CSS y redirige basándose en el resultado
            if (resultado.StartsWith("OK"))
            {
                Label2.CssClass = "text-success"; // Asigna clase de éxito
                                                  // Redirigir si el registro fue exitoso
                Response.Redirect("Admin_refugios.aspx");
            }
            else
            {
                // Mostrar mensaje de error si la base de datos devuelve un error.
                Label2.CssClass = "text-danger"; // Asigna clase de error
                                                 // Label2.Text ya tiene el resultado del error de la DB
            }
        }

        protected void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TxtRef_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

