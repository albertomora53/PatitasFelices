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
    public partial class EditarUsuario : System.Web.UI.Page
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
                        string username = Request.QueryString["user"];
                        lblUsername.Text = username;

                        using (var context = new DataClasses1DataContext())
                        {
                            var usuario = context.User.SingleOrDefault(u => u.Username == username);
                            //var detalle = context.Userdetalle.SingleOrDefault(d => d.Username == username);

                            if (usuario != null)
                            {
                                ddlTipo.SelectedValue = usuario.tipo.ToString();
                                txtNombre.Text = usuario.Nombre;
                                txtApellidoPat.Text = usuario.Apellido_Pat;
                                txtApellidoMat.Text = usuario.Apellido_Mat;
                                txtTelefono.Text = usuario.Telefono;
                                txtCorreo.Text = usuario.Correo;
                                txtRFC.Text = usuario.RFC;
                                txtRef.Text =usuario.Ref;
                            }
                        }
                    }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string username = lblUsername.Text;
            string nuevaPassword = txtPassword.Text.Trim();
            int nuevoTipo = int.Parse(ddlTipo.SelectedValue);
            string nuevoNombre = txtNombre.Text.Trim();
            string nuevoApellidoPat = txtApellidoPat.Text.Trim();
            string nuevoApellidoMat = txtApellidoMat.Text.Trim();
            string nuevoTelefono = txtTelefono.Text.Trim();
            string nuevoCorreo = txtCorreo.Text.Trim();
            string nuevoRFC = txtRFC.Text.Trim();
            string nuevoRef = txtRef.Text.Trim();

            AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();
            string resultado = servicio.EditarUsuario(username, nuevaPassword, nuevoTipo, nuevoNombre, nuevoApellidoPat, nuevoApellidoMat, nuevoTelefono, nuevoCorreo, nuevoRFC, nuevoRef);

            lblMensaje.Text = resultado;


            if (resultado.StartsWith("Se actualizado correctamente"))
            {
                // Redirigir al login
                Response.Redirect("Admin_users.aspx");
            }
            else
            {
                // Mostrar mensaje de error
                lblMensaje.Text = resultado;
            }
        }

        protected void txtRef_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

