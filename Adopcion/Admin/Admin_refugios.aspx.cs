using Adopcion_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adopcion
{
    public partial class Admin_refugios : System.Web.UI.Page
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
                BuscadorRefugios();
            }
        }


        private void BuscadorRefugios(string filtro = "")
        {
            AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();
            var lista = servicio.ListarRefugios();

            if (!string.IsNullOrEmpty(filtro))
            {
                lista = lista.Where(r => (r.Nombre ?? "").ToLower().Contains(filtro.ToLower())).ToList();
            }

            gvRefugios.DataSource = lista;
            gvRefugios.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(texto))
            {
                BuscadorRefugios(); // recarga toda la lista
            }
            else
            {
                BuscadorRefugios(texto); // aplica el filtro
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Obtener el ID del botón
                LinkButton btn = (LinkButton)sender;
                string idString = btn.CommandArgument;

                // 2. Convertir el ID a entero (porque tu base de datos espera un int)
                int idRefugio = int.Parse(idString);

                AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();


                string resultado = servicio.EliminarRefugio(idRefugio);

                // 4. (Opcional) Mostrar el mensaje en tu Label
                lblMensaje.Text = resultado;

                // Cambiar el color del mensaje según el resultado
                if (resultado.Contains("correctamente"))
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                else
                    lblMensaje.ForeColor = System.Drawing.Color.Red;

                // 5. Recargar la tabla para ver que desapareció
                BuscadorRefugios();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }



        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ADD_REFUGIO.aspx");
        }

        protected void LinkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear(); // Limpia todos los datos de sesión
            Session.Abandon();                  // Finaliza la sesión
            Response.Redirect("../Login.aspx");    // Redirige al login
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
    }
}