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
    public partial class ADD_Solicitudes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TxtAnimal_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtUser.Text) ||
                string.IsNullOrEmpty(TxtAnimal.Text) ||
                string.IsNullOrEmpty(ddlEstado.Text))
            {

                Label1.Text = "Por favor completa los campos obligatorios.";
                Label1.CssClass = "text-danger";
                return;
            }

            AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();
            string resultado = servicio.RegistroSolicitud (int.Parse(txtUser.Text),
                                          int.Parse(TxtAnimal.Text),
                                          ddlEstado.SelectedValue,
                                          txtfolio.Text);

            // Actualiza el texto del Label
            Label1.Text = resultado;

            // Asigna la clase CSS y redirige basándose en el resultado
            if (resultado.StartsWith("OK"))
            {
                Label1.CssClass = "text-success"; // Asigna clase de éxito
                                                  // Redirigir si el registro fue exitoso
                Response.Redirect("Admin_solicitudes.aspx");
            }
            else
            {
                // Mostrar mensaje de error si la base de datos devuelve un error.
                Label1.CssClass = "text-danger"; // Asigna clase de error
                                                 // Label2.Text ya tiene el resultado del error de la DB
            }
        }

        protected void TxtFolio_TextChanged(object sender, EventArgs e)
        {

        }
    }
}