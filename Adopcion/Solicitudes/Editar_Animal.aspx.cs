using Adopcion.Utils;
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
    public partial class Editar_Animal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idStr = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(idStr))
                {
                    // --- MODO EDICIÓN (Hay ID en la URL) ---

                    // 1. Deshabilitar el campo Refugio (y el label si quieres)
                    Txtrefugio.Enabled = false;
                    Txtrefugio.CssClass += " bg-secondary"; // Opcional: para que se vea gris visualmente
                    Lblrefugio.Enabled = false; // Esto solo lo pone gris claro

                    // 2. CARGAR LOS DATOS EXISTENTES
                    // Es vital llenar los campos con la info de la base de datos
                    CargarDatosParaEditar(int.Parse(idStr));
                }
                else
                {
                    // --- MODO REGISTRO (No hay ID) ---

                    // Habilitar el campo
                    Txtrefugio.Enabled = true;
                    Lblrefugio.Enabled = true;

                    // Limpiar campos por si acaso (opcional)
                    Label2.Text = "Modo Registro: Ingresa los datos.";
                }
            }
        }


        private void CargarDatosParaEditar(int idAnimal)
        {
            try
            {
                AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();

                // Buscamos el animal en la lista completa (o usa un método ObtenerAnimalPorId si lo tienes)
                var lista = servicio.ListarAnimales();
                var animal = lista.FirstOrDefault(a => a.Id_Animal == idAnimal);

                if (animal != null)
                {
                    txtNombre.Text = animal.Nombre;
                    ddlespecie.SelectedValue = animal.Especie;
                    ddledad.SelectedValue = animal.Edad;
                    ddlgenero.SelectedValue = animal.Genero;
                    ddlTamano.SelectedValue = animal.Tamano;
                    ddlPersonalidad.SelectedValue = animal.Personalidad;
                    Txtdescrip.Text = animal.Descripcion;

                    // El refugio lo llenamos aunque esté deshabilitado para que se vea
                    Txtrefugio.Text = animal.Id_Refugio.ToString();

                    // Guardamos la imagen actual en el HiddenField para no perderla
                    hfImagenActual.Value = animal.Imagen;
                    imgPrevia.ImageUrl = "~/Imagenes/Animales/" + animal.Imagen; // Mostrar la foto actual
                }
                else
                {
                    Label2.Text = "Error: No se encontró el animal solicitado.";
                }
            }
            catch (Exception ex)
            {
                Label2.Text = "Error al cargar datos: " + ex.Message;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                // --- AQUÍ USAS LA NUEVA FUNCIÓN ---

                string rutaCarpeta = Server.MapPath("~/Imagenes/Animales/");
                if (!System.IO.Directory.Exists(rutaCarpeta)) System.IO.Directory.CreateDirectory(rutaCarpeta);

                // Esta sola línea hace todo:
                // 1. Checa si hay foto nueva.
                // 2. Si hay, la guarda y borra la vieja.
                // 3. Si no hay, te devuelve la vieja.
                string nombreImagenFinal = GestorImagen.ActualizarImagen(
                    fileImagen.PostedFile,      // La posible nueva foto
                    rutaCarpeta,                // Dónde guardar
                    hfImagenActual.Value        // El nombre de la foto vieja (para borrarla si es necesario)
                );


                // Validaciones básicas
                if (string.IsNullOrEmpty(txtNombre.Text) ||
                    string.IsNullOrEmpty(ddlespecie.SelectedValue) ||
                    string.IsNullOrEmpty(Txtdescrip.Text) ||
                    string.IsNullOrEmpty(ddledad.SelectedValue) ||
                    string.IsNullOrEmpty(ddlgenero.SelectedValue))
                {
                    Label2.Text = "Por favor completa los campos obligatorios.";
                    Label2.CssClass = "text-danger";
                    return;
                }

                // Recuperar el ID de la URL para saber a quién actualizar
                string idStr = Request.QueryString["id"];
                if (string.IsNullOrEmpty(idStr))
                {
                    Label2.Text = "Error: Se perdió el ID del Animal.";
                    return;
                }

                int idAnimal = int.Parse(idStr);
                AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();

                // Llamamos a la función de editar
                string resultado1 = servicio.EditarAnimal(idAnimal,
                                                  txtNombre.Text,
                                                  ddlespecie.SelectedValue,
                                                  int.Parse(Txtrefugio.Text),
                                                  Txtdescrip.Text,
                                                  ddlgenero.SelectedValue,
                                                  ddledad.SelectedValue,
                                                  nombreImagenFinal,
                                                  ddlTamano.SelectedValue,
                                                  ddlPersonalidad.SelectedValue);



                if (resultado1.Contains("correctamente"))
                {
                    Response.Redirect("Admin_Animales.aspx");
                }
                else
                {
                    Label2.Text = resultado1;
                    Label2.CssClass = "text-danger";
                }
            }
            catch (Exception ex)
            {
                Label2.Text = "Error: " + ex.Message;
                Label2.CssClass = "text-danger";
            }
        }

        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Txtespecie_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Txtdescrip_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Txtedad_TextChanged(object sender, EventArgs e)
        {

        }

        protected void T_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlgenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Txtrefugio_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlTamano_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlPersonalidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}