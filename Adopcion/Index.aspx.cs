using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adopcion
{
    public partial class Index1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ControlarMenuSesion();
            CargarMascotasDestacadas();

        }

        private void ControlarMenuSesion()
        {
            if (Session["usuario"] != null)
            {
                // SI ESTÁ LOGUEADO:
                phAnonimo.Visible = false;   // Ocultar botón Acceder
                phLogueado.Visible = true;   // Mostrar botón Cerrar Sesión

                // Mostrar el nombre (si lo tienes guardado en sesión)
                litNombreUsuario.Text = Session["usuario"].ToString();

                if (Session["tipo"] != null)
                {
                    int tipoUsuario = 0;
                    // Convertimos a int de forma segura (funciona si guardaste un int o un string "2")
                    int.TryParse(Session["tipo"].ToString(), out tipoUsuario);

                    if (tipoUsuario == 2)
                    {
                        phRefugio.Visible = true; // Solo se muestra si es tipo 2
                    }
                }

            }
            else
            {
                // SI NO ESTÁ LOGUEADO:
                phAnonimo.Visible = true;    // Mostrar botón Acceder
                phLogueado.Visible = false;  // Ocultar botón Cerrar Sesión
            }
        }

        // --- EVENTO PARA CERRAR SESIÓN ---
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // 1. Limpiar variables de sesión
            Session.Remove("usuario");
            Session.Remove("tipo");
            Session.RemoveAll();

            // 2. Destruir la sesión
            Session.Abandon();

            // 3. Recargar la página para que se actualice el menú
            Response.Redirect("Index.aspx");
        }

        private void CargarMascotasDestacadas()
        {
            AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();
            var lista = servicio.ListarAnimales();

            if (lista != null && lista.Count > 0)
            {
                // AQUÍ ESTÁ EL TRUCO: .Take(4) toma solo los primeros 4
                // También puedes usar .OrderBy(x => Guid.NewGuid()) antes del Take
                // si quieres que salgan 4 aleatorios cada vez.

                RepMascotas.DataSource = lista.Take(5).ToList();
                RepMascotas.DataBind();
            }
        }

        protected void LinkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear(); // Limpia todos los datos de sesión
            Session.Abandon();                  // Finaliza la sesión
            Response.Redirect("Login.aspx");    // Redirige al login
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void Menu2_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtMensaje.Text))
            {
                MostrarAlerta("Por favor, llena todos los campos.");
                return;
            }

            try
            {
                // 2. Obtener los datos del formulario
                string nombre = txtNombre.Text;
                string correo = txtCorreo.Text;
                string descripcion = txtMensaje.Text;


                AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();

                string respuesta = servicio.RegistrarMensajeWS(nombre, correo, descripcion);


                // 4. Mostrar el mensaje que retorna el WebMethod (ej: "Mensaje guardado con éxito")
                MostrarAlerta(respuesta);

                // 5. Limpiar los campos si fue exitoso (opcional)
                if (respuesta.ToLower().Contains("exito") || respuesta.ToLower().Contains("guardado"))
                {
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores de conexión o del servicio
                MostrarAlerta("Ocurrió un error al enviar el mensaje: " + ex.Message);
            }
        }

        // Método auxiliar para limpiar los TextBox
        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtMensaje.Text = string.Empty;
        }

        // Método auxiliar para mostrar alertas de JavaScript desde el servidor
        private void MostrarAlerta(string mensaje)
        {
            // Limpia el mensaje para evitar errores de sintaxis en JS
            string mensajeLimpio = mensaje.Replace("'", "\\'").Replace("\r", "").Replace("\n", "");
            string script = $"<script type='text/javascript'>alert('{mensajeLimpio}');</script>";

            // Inyecta el script en la página
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);
        }

      


        protected void txtMensaje_TextChanged(object sender, EventArgs e)
                {

                }

        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
