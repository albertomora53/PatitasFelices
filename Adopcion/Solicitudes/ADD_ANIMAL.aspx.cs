using Adopcion.Utils;
using Adopcion_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adopcion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtNombreAnimal_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlEspecie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtIdRefugio_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
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
                string idRefugioStr = txtIdRefugio.Text.Trim();
                string descripcion = txtDescripcion.Text.Trim();
                string genero = ddlGenero.SelectedValue;
                string edad = ddledad.SelectedValue;
                string Tamano = ddlTamano.SelectedValue;
                string Personalidad = ddlPersonalidad.SelectedValue;
                int idRefugio;

                // 3. VALIDACIONES
                if (string.IsNullOrEmpty(nombre) ||
                    string.IsNullOrEmpty(especie) ||
                    string.IsNullOrEmpty(idRefugioStr) ||
                    string.IsNullOrEmpty(descripcion) ||
                    string.IsNullOrEmpty(genero) ||
                    string.IsNullOrEmpty(edad) ||
                    string.IsNullOrEmpty(Tamano))
                {
                    Label2.Text = "🚨 Error: Por favor completa todos los campos obligatorios.";
                    Label2.CssClass = "text-danger";
                    return;
                }

                if (!int.TryParse(idRefugioStr, out idRefugio))
                {
                    Label2.Text = "🚨 Error: El ID de Refugio debe ser un número entero válido.";
                    Label2.CssClass = "text-danger";
                    return;
                }

                // 4. GUARDAR EN BASE DE DATOS
                // Aquí enviamos 'nombreImagenFinal' (que es el nombre del archivo, ej: "asd-123.jpg")
                AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();
                string resultado = servicio.RegistroAnimal(
                    nombre,
                    especie,
                    idRefugio,
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
                    Response.Redirect("Admin_animales.aspx", false);
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

        protected void txtTamano_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlPersonalidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlTamano_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}