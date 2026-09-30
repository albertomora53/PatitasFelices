using Adopcion.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adopcion
{
    public partial class RegistroMascota : System.Web.UI.Page
    {
        AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();
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

            }
        }

        protected void txtNombreAnimal_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlEspecie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlTamano_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlPersonalidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddledad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                

                // Intentamos convertir la sesión a número de forma segura
                int idUsuarioLogueado = Convert.ToInt32(Session["IdUsuario"]);


                // 1. GESTIÓN DE LA IMAGEN (Lo hacemos primero)
                string nombreImagenFinal = "";

                // Verificamos si el usuario seleccionó un archivo en el control 'fileImagen'
                if (fileImagen.HasFile)
                {
                    // Definir ruta física: Carpeta "Imagenes/Animales" en tu servidor
                    string rutaCarpeta = Server.MapPath("~/Imagenes/Animales/");

                    // Crear la carpeta si no existe (buena práctica)
                    if (!System.IO.Directory.Exists(rutaCarpeta))
                    {
                        System.IO.Directory.CreateDirectory(rutaCarpeta);
                    }

                    // Llamamos a tu clase GestorImagen que está en Utils
                    // Esto valida, comprime y guarda la foto en el disco duro
                    try
                    {
                        nombreImagenFinal = GestorImagen.GuardarImagen(fileImagen.PostedFile, rutaCarpeta);
                    }
                    catch (Exception exImagen)
                    {
                        // Si la imagen falla (muy pesada o formato incorrecto), mostramos error y detenemos todo
                        Label2.Text = "🚨 Error con la imagen: " + exImagen.Message;
                        Label2.CssClass = "text-danger";
                        return;
                    }
                }

                else
                {
                    // Si quieres obligar a que suban foto, descomenta estas líneas:
                    /*
                    Label2.Text = "🚨 Error: Debes seleccionar una imagen.";
                    Label2.CssClass = "text-danger";
                    return;
                    */

                    // Si es opcional, dejamos un valor por defecto o vacío
                    nombreImagenFinal = "default.jpg";
                }

                // 2. RECOLECCIÓN DE DATOS DEL FORMULARIO
                string nombre = txtNombreAnimal.Text.Trim();
                string especie = ddlEspecie.SelectedValue;
                int idRefugioStr = servicio.ObtenerIdRefugioPorUsuario(idUsuarioLogueado);
                string descripcion = txtDescripcion.Text.Trim();
                string genero = ddlGenero.SelectedValue;
                string edad = ddledad.SelectedValue;
                string Tamano = ddlTamano.SelectedValue;
                string Personalidad = ddlPersonalidad.SelectedValue;
                

                // 3. VALIDACIONES
                if (string.IsNullOrEmpty(nombre) ||
                    string.IsNullOrEmpty(especie) ||
                    string.IsNullOrEmpty(descripcion) ||
                    string.IsNullOrEmpty(genero) ||
                    string.IsNullOrEmpty(edad) ||
                    string.IsNullOrEmpty(Tamano))
                {
                    Label2.Text = "🚨 Error: Por favor completa todos los campos obligatorios.";
                    Label2.CssClass = "text-danger";
                    return;
                }


                if (idRefugioStr <= 0)
                {
                    Label2.Text = "🚨 Error: No se encontró un refugio asociado a tu cuenta. Asegúrate de estar registrado como tipo 'Refugio'.";
                    Label2.CssClass = "text-danger";
                    return; // Detenemos la ejecución aquí
                }


                // 4. GUARDAR EN BASE DE DATOS
                // Aquí enviamos 'nombreImagenFinal' (que es el nombre del archivo, ej: "asd-123.jpg")

                string resultado = servicio.RegistroAnimal(
                    nombre,
                    especie,
                    idRefugioStr,
                    descripcion,
                    genero,
                    edad,
                    nombreImagenFinal, // <--- Aquí pasamos el nombre de la foto guardada
                    Tamano,
                    Personalidad
                );

                // 5. RESPUESTA AL USUARIO
                Label2.Text = resultado;

                if (resultado.StartsWith("OK") || resultado.Contains("exitoso") || resultado.Contains("éxito"))
                {
                    Label2.CssClass = "text-success";
                    // Opcional: Esperar unos segundos antes de redirigir o limpiar campos
                    Response.Redirect("Mirefugio.aspx", false);
                }
                else
                {
                    Label2.CssClass = "text-danger";
                }

            }
            catch (Exception ex)
            {
                Label2.Text = $" Error crítico: {ex.Message}";
                Label2.CssClass = "text-danger";
            }

        }

    }
}