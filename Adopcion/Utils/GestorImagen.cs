using System;
using System.IO;
using System.Web; 
using System.Drawing; 
using System.Drawing.Imaging;
using System.Linq;

namespace Adopcion.Utils
{
	public class GestorImagen
	{
        public static string GuardarImagen(HttpPostedFile file, string rutaServidor)
        {
            try
            {
                // 1. Validaciones básicas
                if (file == null || file.ContentLength == 0) return null; // O devuelve string vacío

                // Validar peso (2MB)
                if (file.ContentLength > 2 * 1024 * 1024)
                    throw new Exception("La imagen excede los 2MB.");

                // Validar extensión
                string extension = Path.GetExtension(file.FileName).ToLower();
                string[] permitidas = { ".jpg", ".jpeg", ".png", ".webp" };
                if (!permitidas.Contains(extension))
                    throw new Exception("Formato no permitido.");

                // 2. Generar nombre único
                string nombreArchivo = Guid.NewGuid().ToString() + ".jpg"; // Lo convertiremos a JPG
                string rutaCompleta = Path.Combine(rutaServidor, nombreArchivo);

                // 3. Comprimir y Guardar
                using (var imagenOriginal = Image.FromStream(file.InputStream))
                {
                    // Configurar codec JPG
                    var jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                    var encoderParameters = new EncoderParameters(1);
                    encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 70L); // Calidad 70%

                    // Guardar comprimido
                    imagenOriginal.Save(rutaCompleta, jpgEncoder, encoderParameters);
                }

                return nombreArchivo; // Retornamos solo el nombre
            }
            catch (Exception ex)
            {
                throw new Exception("Error imagen: " + ex.Message);
            }
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().FirstOrDefault(codec => codec.FormatID == format.Guid);
        }

        public static string ActualizarImagen(HttpPostedFile nuevaImagen, string rutaServidor, string nombreImagenAnterior)
        {
            try
            {
                // CASO 1: El usuario NO subió nueva foto.
                // Simplemente devolvemos el nombre de la anterior para que no cambie nada en la BD.
                if (nuevaImagen == null || nuevaImagen.ContentLength == 0)
                {
                    return nombreImagenAnterior;
                }

                // CASO 2: El usuario SÍ subió foto nueva.

                // A. Guardamos la nueva foto usando tu función existente
                string nuevoNombre = GuardarImagen(nuevaImagen, rutaServidor);

                // B. Borramos la foto vieja para no llenar el servidor de basura
                if (!string.IsNullOrEmpty(nombreImagenAnterior) && nombreImagenAnterior != "default.jpg") // Opcional: proteger imagen default
                {
                    string rutaVieja = Path.Combine(rutaServidor, nombreImagenAnterior);
                    if (File.Exists(rutaVieja))
                    {
                        try
                        {
                            File.Delete(rutaVieja);
                        }
                        catch
                        {
                            // Si no se puede borrar (está en uso, permisos, etc), no detenemos el proceso.
                            // Solo lo ignoramos.
                        }
                    }
                }

                return nuevoNombre;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar imagen: " + ex.Message);
            }
        }
    
    }

}