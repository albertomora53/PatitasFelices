using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adopcion
{
    public partial class solicitud_adopcion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 1. Validar si el usuario está logueado
                if (Session["IdUsuario"] == null) // O como hayas llamado a tu variable de sesión
                {
                    // Si no hay sesión, mandar al login
                    Response.Redirect("Login.aspx");
                    return;
                }

                // 2. Obtener datos de la mascota (Opcional visual)
                // Aquí podrías cargar el nombre de la mascota en el Label si tienes una función para buscar por ID
                if (Request.QueryString["idAnimal"] != null)
                {
                    string idRecibido = Request.QueryString["idAnimal"];

                    // <--- AQUÍ GUARDAMOS EL ID EN LA CAJA FUERTE
                    hfIdAnimal.Value = idRecibido;

                    // Opcional: Mostrar el ID o nombre en el label
                    lblNombreMascota.Text = "Mascota ID: " + idRecibido;
                }
                else
                {
                        // Si entraron sin ID, los regresamos
                        Response.Redirect("Mascotas.aspx");
                    
                }
            }

        }

        protected void ddlVivienda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rblPropiedad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtSeguridad_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtIntegrantes_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlHorasSoledad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtMotivo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void chkCompromiso_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnEnviarSolicitud_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validaciones
                if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                int idUsuario = 0;

                // Intentamos convertir la sesión a número de forma segura
                bool usuarioEsNumero = int.TryParse(Session["IdUsuario"].ToString(), out idUsuario);

                // 1. Validar Teléfono (Solo números y longitud exacta)
                string telefono = txtTelefono.Text.Trim();
                if (telefono.Length != 10 || !long.TryParse(telefono, out _))
                {
                    Response.Write("<script>alert('Error: El teléfono debe tener exactamente 10 dígitos numéricos.');</script>");
                    return;
                }

                // 2. Validar Checkboxes (Obligatorios)
                if (!chkGasto.Checked)
                {
                    Response.Write("<script>alert('Error: Debes aceptar el compromiso de gastos.');</script>");
                    return;
                }

                if (!chkCompromi.Checked)
                {
                    Response.Write("<script>alert('Error: Debes aceptar el compromiso de adopción de por vida.');</script>");
                    return;
                }

                // CORRECCIÓN: Validamos usando el HiddenField, NO el QueryString
                if (string.IsNullOrEmpty(hfIdAnimal.Value))
                {
                    Response.Write("<script>alert('Error: No se ha seleccionado una mascota (ID perdido).'); window.location='Mascotas.aspx';</script>");
                    return;
                }

               /* // 2. Recolectar IDs de forma segura
                int idUsuario = Convert.ToInt32(Session["usuario"]); */

                // Leemos el ID desde el control oculto
                int idAnimal = Convert.ToInt32(hfIdAnimal.Value); 

                // Validar edad
                int edad = 0;
                if (!int.TryParse(txtEdad.Text, out edad))
                {
                    Response.Write("<script>alert('Por favor ingresa una edad válida.');</script>");
                    return;
                }

                string folio = Guid.NewGuid().ToString();

                // 3. Instanciar el Web Service
                AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();

                // 4. Llamar a la función pequeña (como solicitaste)
                servicio.RegistroSolicitud(idUsuario, idAnimal, "Pendiente", folio);

                // 5. Llamar a la función completa
                string resultado = servicio.RegistrarSolicitudCompleta(
                    folio,
                    idUsuario,
                    idAnimal,
                    edad,
                    txtOcupacion.Text,
                    txtDireccion.Text,
                    txtTelefono.Text,
                    txtRedes.Text,
                    ddlVivienda.SelectedValue,
                    rblPropiedad.SelectedValue,
                    rblPermiso.SelectedValue,
                    txtSeguridad.Text,
                    txtIntegrantes.Text,
                    ddlAcuerdo.SelectedValue,
                    rblAlergias.SelectedValue,
                    txtOtrasMascotas.Text,
                    txtSociabilidad.Text,
                    ddlHorasSoledad.SelectedValue,
                    txtDormir.Text,
                    txtMudanza.Text,
                    txtMotivo.Text,
                    chkGasto.Checked,
                    chkCompromi.Checked
                );

                // 6. Evaluar respuesta
                if (resultado.ToLower().Contains("éxito") || resultado.ToLower().Contains("exito"))
                {
                    Response.Write($"<script>alert('{resultado}'); window.location='Mascotas.aspx';</script>");
                }
                else
                {
                    Response.Write($"<script>alert('{resultado}');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Ocurrió un error inesperado: {ex.Message}');</script>");
            }
        }
    }
}  