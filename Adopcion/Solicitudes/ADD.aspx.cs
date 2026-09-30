using Adopcion_Data;
using System;
using System.Web.UI;

namespace Adopcion
{
    public partial class ADD : System.Web.UI.Page
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
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {  

            // Validación  
            if (string.IsNullOrEmpty(txtUser.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                ddlTipo.SelectedIndex == -1 )
            {
                Label1.Text = "Por favor completa los campos obligatorios.";
                Label1.CssClass = "text-danger";
                return;
            }

            string Ref;

            string tipoUsuario = ddlTipo.SelectedValue;

            if (Convert.ToInt32(tipoUsuario) == 2)
            {
                Ref = Guid.NewGuid().ToString();
            }
            else
            { Ref = null; }


            // Registrar usuario
            AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();
            string resultado = servicio.RegistroUsuarios(txtUser.Text,
                                            txtPassword.Text,
                                            Convert.ToInt32(tipoUsuario),
                                            txtNombre.Text,
                                            txtApellidoPat.Text,
                                            txtApellidoMat.Text,
                                            txtTelefono.Text,
                                            txtCorreo.Text,
                                            txtRFC.Text,
                                            Ref);


            // Mostrar mensaje

            Label1.Text = resultado;

            if (resultado.StartsWith("Registro exitoso"))
            {
                // Redirigir al login
                Response.Redirect("Admin_users.aspx");
            }
            else
            {
                // Mostrar mensaje de error
                Label1.Text = resultado;
            }
        }
    }
}

