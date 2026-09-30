using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adopcion
{
    public partial class Perfil : System.Web.UI.Page
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
                CargarinfoDesdeWS();
            }
        }

        private void ControlarMenuSesion()
        {
            if (Session["usuario"] != null)
            {
                litNombreUsuario.Text = Session["usuario"].ToString();
            }
        }

        private void CargarinfoDesdeWS()
        {
            int idUsuario = 0;

            // Intentamos convertir la sesión a número
            if (int.TryParse(Session["IdUsuario"].ToString(), out idUsuario))
            {
                try
                {
                    // Instanciamos el servicio
                    AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();

                    // 2. Llamamos al método que busca UN solo usuario por ID
                    var datosUsuario = servicio.ObtenerInfoUsuario(idUsuario);

                    lblUsername.Text = datosUsuario.Username;

                    // 3. Llenamos los Labels del HTML
                    if (datosUsuario != null)
                    {
                        switch (datosUsuario.tipo)
                        {
                            case 1: lblTipoUsuario.Text = "Administrador"; break;
                            case 2: lblTipoUsuario.Text = "Refugio"; break;
                            case 3: lblTipoUsuario.Text = "Adoptante"; break;
                            default:
                                lblTipoUsuario.Text = "Tipo de usuario no reconocido.";
                                break;
                        }



                        // Nombre
                        lblNombre.Text = datosUsuario.Nombre;
                        
                        lblApellidoPat.Text = datosUsuario.Apellido_Pat;

                        lblApellidoMat.Text = datosUsuario.Apellido_Mat;

                        // RFC
                        lblRFC.Text = datosUsuario.RFC;

                        // Teléfono
                        lblTelefono.Text = datosUsuario.Telefono;

                        // Correo
                        lblCorreo.Text = datosUsuario.Correo;
                    }
                    else
                    {
                        // Si no se encuentra información
                        lblNombre.Text = "No se encontraron datos.";
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de error si falla el servicio
                    // Usamos ScriptManager o Response.Write con cuidado para no romper el HTML
                    string script = $"<script>alert('Error al cargar perfil: {ex.Message}');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", script);
                }
            }
        }



        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear(); // Limpia todos los datos de sesión
            Session.Abandon();                  // Finaliza la sesión
            Response.Redirect("Login.aspx");    // Redirige al login
        }
    }
}