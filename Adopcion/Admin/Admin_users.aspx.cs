using Adopcion_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adopcion
{
    public partial class Admin_users : System.Web.UI.Page
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
                        BuscadorUsuarios();
                    }


        }

        public string GetTipoUsuario(int tipoId)
        {
            switch (tipoId)
            {
                case 1:
                    return "Administrador";
                case 2:
                    return "Refugio";
                case 3:
                    return "Adoptante";
                default:
                    return "Desconocido";
            }
        }

        private void BuscadorUsuarios(string filtro = "")
        {
            AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();
            var lista = servicio.ListarUsuarios();

            if (!string.IsNullOrEmpty(filtro))
            {
                lista = lista.Where(u => (u.Username ?? "").ToLower().Contains(filtro.ToLower())).ToList();
            }

            gvUsuarios.DataSource = lista;
            gvUsuarios.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(texto))
            {
                BuscadorUsuarios(); // recarga toda la lista
            }
            else
            {
                BuscadorUsuarios(texto); // aplica el filtro
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string username = btn.CommandArgument;

            AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();
            string resultado = servicio.EliminarUsuario(username);

            // Opcional: mostrar mensaje en pantalla
            // lblMensaje.Text = resultado;

            // Recargar la lista de usuarios
            BuscadorUsuarios();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ADD.aspx");
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