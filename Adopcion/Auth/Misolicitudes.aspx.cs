using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adopcion
{
    public partial class Misolicitudes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificamos sesión antes de cargar nada
            if (Session["usuario"] == null || Session["IdUsuario"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                ControlarMenuSesion();
                CargarSolicitudesDesdeWS();
            }
        }

        private void ControlarMenuSesion()
        {
            if (Session["usuario"] != null)
            {
                litNombreUsuario.Text = Session["usuario"].ToString();
            }
        }

        private void CargarSolicitudesDesdeWS()
        {
            int idUsuario = 0;

            // Intentamos convertir la sesión a número
            if (int.TryParse(Session["IdUsuario"].ToString(), out idUsuario))
            {
                try
                {
                    AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();

                    // Obtenemos la lista del servicio
                    var listaSolicitud = servicio.ListarSolicitudesPorUsuario(idUsuario);

                    // VERIFICAMOS SI HAY DATOS
                    if (listaSolicitud != null && listaSolicitud.Count > 0) // Si usas Array
                    // O si devuelve List<> usa: if (listaSolicitud != null && listaSolicitud.Count > 0)
                    {
                        rptSolicitudes.DataSource = listaSolicitud;
                        rptSolicitudes.DataBind();
                        pnlNoDatos.Visible = false;
                    }
                    else
                    {
                        // No hay solicitudes
                        rptSolicitudes.Visible = false;
                        pnlNoDatos.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de error si falla el servicio
                    Response.Write("<script>alert('Error al conectar con el servicio: " + ex.Message + "');</script>");
                }
            }
        }

        // Función auxiliar para el HTML (Cambia el color según el estado)
        public string ObtenerColorEstado(string situacion)
        {
            switch (situacion.ToLower())
            {
                case "aprobada":
                    return "#198754"; // Verde (Success)
                case "rechazada":
                    return "#dc3545"; // Rojo (Danger)
                case "pendiente":
                default:
                    return "#e67e22"; // Naranja (Tu color original)
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // 1. Limpiar variables de sesión
            Session.Remove("usuario");
            Session.Remove("tipo");
            Session.RemoveAll();

            // 2. Destruir la sesión
            Session.Abandon();
        }

        protected void btnrefugios_Click(object sender, EventArgs e)
        {

        }

        // Función para cambiar el texto según el estado
        public string ObtenerMensajeDescripcion(string situacion)
        {
            // Aseguramos que comparamos sin importar mayúsculas/minúsculas
            switch (situacion.ToLower())
            {
                case "aprobada":
                    return "¡Felicidades! Tu solicitud ha sido aprobada. Nos pondremos en contacto contigo a la brevedad para coordinar la entrega.";
                case "rechazada":
                    return "Lo sentimos, tu solicitud no ha sido aprobada en esta ocasión.";
                case "pendiente":
                default:
                    return "Tu solicitud está siendo revisada por nuestro equipo.";
            }
        }

        public string ObtenerEstiloBarra(string situacion)
        {
            // Definimos el ancho y el color según el estado
            switch (situacion.ToLower())
            {
                case "aprobada":
                    // Llena (100%) y Verde
                    return "width: 100%; background-color: #198754;";

                case "rechazada":
                    // Llena (100% para indicar fin del proceso) y Roja
                    return "width: 100%; background-color: #dc3545;";

                case "pendiente":
                default:
                    // A la mitad (50%) y Naranja
                    return "width: 50%; background-color: #e67e22;";
            }
        }

    }
}