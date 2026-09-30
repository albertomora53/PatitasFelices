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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlAdoptador.Visible = false;
                pnlRefugio.Visible = false;
                pnlAdmin.Visible = false;
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
     

            // Validación general
            if (string.IsNullOrWhiteSpace(Txt_nameuser.Text) ||
                string.IsNullOrWhiteSpace(Txt_password.Text) ||
                string.IsNullOrWhiteSpace(Txt_correo.Text) ||
                string.IsNullOrWhiteSpace(Txt_telefono.Text) ||
                rblTipoUsuario.SelectedIndex == -1)
            {
                Label1.Text = "Por favor, completa todos los campos generales.";
                return;
            }

            string tipoUsuario = rblTipoUsuario.SelectedValue;

            // Variables para el registro
            string nombreParaDB = "";
            string apePaParaDB = "";
            string apeMaParaDB = "";
            string rfcParaDB = "";
            string Ref = "";
    

            // Validación y asignación específica según tipo de usuario
            if (tipoUsuario == "1") // Admin
            {
                if (string.IsNullOrWhiteSpace(TextBox1.Text) ||
                    string.IsNullOrWhiteSpace(TextBox2.Text) ||
                    string.IsNullOrWhiteSpace(TextBox3.Text))
                {
                    Label1.Text = "Completa todos los campos del admin";
                    return;
                }
                // Asignar valores de Admin
                nombreParaDB = TextBox1.Text;
                apePaParaDB = TextBox2.Text;
                apeMaParaDB = TextBox3.Text;
            }

            else if (tipoUsuario == "2") // Refugio
            {
                if (string.IsNullOrWhiteSpace(txt_Institucion.Text) ||
                    string.IsNullOrWhiteSpace(Txt_rfc.Text))
                {
                    Label1.Text = "Completa todos los campos del refugio.";
                    return;
                }
                // Asignar valores de Refugio
                nombreParaDB = txt_Institucion.Text; // <-- ¡Usar el campo correcto!
                rfcParaDB = Txt_rfc.Text;
                Ref = Guid.NewGuid().ToString();
   
            }

            else if (tipoUsuario == "3") // Adoptador
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txt_ApePa.Text) ||
                    string.IsNullOrWhiteSpace(txt_ApeMa.Text))
                {
                    Label1.Text = "Completa todos los campos del adoptador.";
                    return;
                }
                // Asignar valores de Adoptador
                nombreParaDB = txtNombre.Text;
                apePaParaDB = txt_ApePa.Text;
                apeMaParaDB = txt_ApeMa.Text;
            }

            // Registro
            AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();
            string resultado = servicio.RegistroUsuarios(
                Txt_nameuser.Text,
                Txt_password.Text,
                Convert.ToInt32(tipoUsuario),
                nombreParaDB,    // <-- Usar variable
                apePaParaDB,     // <-- Usar variable
                apeMaParaDB,     // <-- Usar variable
                Txt_telefono.Text,
                Txt_correo.Text,
                rfcParaDB,        // <-- Usar variable
                Ref

            );

                


            Label1.Text = resultado;

            if (resultado.StartsWith("Registro exitoso"))
            {
                if (tipoUsuario == "2")
                {
                    string refugio = servicio.RegistroRefugio(nombreParaDB,
                                                          Txt_direc.Text,
                                                          "Pendiente",
                                                            Ref);
                }

                // Redirigir al login
                Response.Redirect("Login.aspx");
            }
            else
            {
                // Mostrar mensaje de error
                Label1.Text = resultado;
            }

        }



        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void rblTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = rblTipoUsuario.SelectedValue;

            pnlAdoptador.Visible = (tipo == "3");
            pnlRefugio.Visible = (tipo == "2");
            pnlAdmin.Visible = (tipo == "1");

        }

        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_ApePa_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_ApeMa_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_Institucion_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Txt_direc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}