using Adopcion.ServiceReference1;
using Adopcion_Data; 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adopcion
{
    public partial class Log : System.Web.UI.Page
    {


        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Txt_user_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Btn_INICIO_Click(object sender, EventArgs e)
        {
            string username = Txt_user.Text.Trim();
            string password = Txt_password.Text.Trim();

            // 1. Creamos el cliente del Web Service en lugar de la DATABASE
            // Nota: El nombre suele terminar en 'SoapClient'
            WebService1SoapClient cliente = new WebService1SoapClient();

            try
            {
                // 2. Llamamos a la función Login del Web Service
                var resultado = cliente.Login(username, password);
                //var resultado2 = cliente.EliminarUsuario(username);


                if (resultado.Exito)
                {
                    Session["IdUsuario"] = resultado.IdUsuario;
                    Session["usuario"] = username;
                    Session["tipo"] = resultado.TipoUsuario;

                    // Redirigir según el tipo (Tu lógica de switch se mantiene igual)
                    switch (resultado.TipoUsuario)
                    {
                        case 1: Response.Redirect("~/Admin/Admin_users.aspx"); break;
                        case 2: Response.Redirect("Index.aspx"); break;
                        case 3: Response.Redirect("Index.aspx"); break;
                        default:
                            Label2.Text = "Tipo de usuario no reconocido.";
                            break;
                    }
                }
                else
                {
                    // Mostramos el mensaje de error que viene desde DATABASE -> WebService
                    Label2.Text = resultado.Mensaje;
                }
            }
            catch (Exception ex)
            {
                Label2.Text = "Error al conectar con el servicio: " + ex.Message;
            }
        }
    


         



        protected void link_registro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}