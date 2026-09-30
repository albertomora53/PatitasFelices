using Adopcion_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adopcion
{
    public partial class Admin_solicitudes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || Session["tipo"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            int tipo = (int)Session["tipo"];

            if (tipo != 1) // Solo admins
            {
                Response.Redirect("SinPermiso.aspx");
            }

            if (!IsPostBack)
            {
                // Cargar la lista completa al inicio de la página (si no hay búsqueda previa)
                BuscadorSolicitudes();
            }
        }
        private void BuscadorSolicitudes(string filtro = "")
        {
            AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();
            // 1. Llama a la nueva función ListaAnimales()
            var lista = servicio.ListarSolicitudes();

            if (!string.IsNullOrEmpty(filtro))
            {
                //ToLower búsqueda insensible a mayúsculas/minúsculas.
                lista = lista.Where(s => (s.Situacion ?? "").ToLower().Contains(filtro.ToLower())).ToList();
            }

            // 3. Enlaza los resultados al GridView
            gvSolicitudes.DataSource = lista;
            gvSolicitudes.DataBind();
        }

        protected void btnusuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Admin_users.aspx");
        }

        protected void btnanimales_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Admin_animales.aspx");
        }

        protected void btnsolicitud_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Admin_solicitudes.aspx");
        }

        protected void btnrefugios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Admin_refugios.aspx");
        }

        protected void LinkCerrarSesion_Click(object sender, EventArgs e)
        {

            Session.Clear(); // Limpia todos los datos de sesión
            Session.Abandon();                  // Finaliza la sesión
            Response.Redirect("../Login.aspx");    // Redirige al login

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(texto))
            {
                BuscadorSolicitudes(); // Recarga toda la lista sin filtro
            }
            else
            {
                BuscadorSolicitudes(texto); // Aplica el filtro
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ADD_Solicitudes.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Obtener el ID del botón
                LinkButton btn = (LinkButton)sender;
                string idString = btn.CommandArgument;

                // 2. Convertir el ID a entero (porque tu base de datos espera un int)
                int idSolicitudes = int.Parse(idString);

                AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();


                string resultado = servicio.EliminarSolicitud(idSolicitudes);

                // 4. (Opcional) Mostrar el mensaje en tu Label
                lblMensaje.Text = resultado;

                // Cambiar el color del mensaje según el resultado
                if (resultado.Contains("correctamente"))
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                else
                    lblMensaje.ForeColor = System.Drawing.Color.Red;

                // 5. Recargar la tabla para ver que desapareció
                BuscadorSolicitudes();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvSolicitudes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}