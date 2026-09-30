using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adopcion
{
    public partial class Mirefugio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlarMenuSesion();

            if (!IsPostBack)
            {
                CargarMascotasDesdeWS();
            }
        }

        private void ControlarMenuSesion()
        {
            if (Session["usuario"] != null)
            {

                // Mostrar el nombre (si lo tienes guardado en sesión)
                litNombreUsuario.Text = Session["usuario"].ToString();
            }
            else
            {

            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear(); // Limpia todos los datos de sesión
            Session.Abandon();                  // Finaliza la sesión
            Response.Redirect("Login.aspx");    // Redirige al login
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Obtener el ID del botón
                LinkButton btn = (LinkButton)sender;
                string idString = btn.CommandArgument;

                // 2. Convertir el ID a entero (porque tu base de datos espera un int)
                int idAnimal = int.Parse(idString);

                AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();


                string resultado = servicio.EliminarAnimal(idAnimal);


                // 5. Recargar la tabla para ver que desapareció
                CargarMascotasDesdeWS();
            }
            catch (Exception ex)
            {
                string errorSafe = "Error inesperado: " + ex.Message.Replace("'", "\\'");
                string script = $"alert('{errorSafe}');";

                ClientScript.RegisterStartupScript(this.GetType(), "AlertaError", script, true);
            }
        }


        private void CargarMascotasDesdeWS()
        {
            // 1. INSTANCIAR EL SERVICIO WEB
            
            AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();

            // 1. Obtener el ID del Usuario de la sesión
            if (Session["IdUsuario"] == null) return; // Validación de seguridad
            int idUsuario = Convert.ToInt32(Session["IdUsuario"]);

            // 2. AVERIGUAR CUÁL ES SU REFUGIO (Aquí estaba el error)
            // Usamos la función que busca el refugio basándose en el usuario
            int idRefugio = servicio.ObtenerIdRefugioPorUsuario(idUsuario);

            // Si devuelve 0, significa que el usuario no tiene refugio asignado o hubo error
            if (idRefugio == 0)
            {
                // Puedes mostrar un mensaje de error o simplemente no cargar nada
                pnlNoDatos.Visible = true;
                return;
            }

            // 3. AHORA SÍ, LLAMAR CON EL ID CORRECTO
            // Pasamos 'idRefugio', NO 'idUsuario'
            var listaBruta = servicio.ListarAnimalesPorRefugio(idRefugio);

            // 4. Lógica de visualización (Esto ya lo tenías bien)
            if (listaBruta != null && listaBruta.Count > 0)
            {
                RepMascotasPage.DataSource = listaBruta;
                RepMascotasPage.DataBind();
                pnlNoDatos.Visible = false;
            }
            else
            {
                RepMascotasPage.DataSource = null;
                RepMascotasPage.DataBind();
                pnlNoDatos.Visible = true;
            }
        }
    }
}