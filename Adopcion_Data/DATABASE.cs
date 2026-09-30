using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Adopcion_Data
{
    public class DATABASE
    {
        public class ResultadoLogin
        {
            public bool Exito { get; set; }
            public string Mensaje { get; set; }
            public int TipoUsuario { get; set; }
            public int IdUsuario { get; set; }
        }


        public string Registrar(string Username,
                                string password,
                                int tipo,
                                string nombre,
                                string apellidoPat,
                                string apellidoMat,
                                string telefono,
                                string correo,
                                string rfc,
                                string Ref)
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {

                    // Validar RFC antes de guardar

                    var validador = new ADD();




                    // Validar telefono antes de guardar

                    if (!validador.ValidarTelefono(telefono))
                        return "El teléfono debe contener solo números.";



                    // Verificar si el Username ya existe
                    bool existe = context.User.Any(u => u.Username == Username);
                    if (existe)
                        return "El nombre de usuario ya está registrado.";

                    string clave = "mi_clave_secreta";
                    string passwordEncriptado = Encriptacion.Encriptar(password, clave);

                    var nuevoUsuario = new User
                    {
                        Username = Username,
                        Nombre = nombre,
                        Apellido_Pat = apellidoPat,
                        Apellido_Mat = apellidoMat,
                        Telefono = telefono,
                        Correo = correo,
                        RFC = rfc,
                        password = passwordEncriptado,
                        tipo = tipo,
                        Fecha = DateTime.Now,
                        Ref = Ref
                    };

                    context.User.InsertOnSubmit(nuevoUsuario);
                    context.SubmitChanges();


                    return $"Registro exitoso: {nuevoUsuario.Username}";
                }
            }
            catch (Exception ex)
            {
                return $"Error al registrar usuario: {ex.Message}";
            }
        }


        public string EditarUsuario(string Username,
                            string nuevaPassword,
                            int nuevoTipo,
                            string nuevoNombre,
                            string nuevoApellidoPat,
                            string nuevoApellidoMat,
                            string nuevoTelefono,
                            string nuevoCorreo,
                            string nuevoRFC,
                            string nuevoRef)
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {

                    var usuario = context.User.SingleOrDefault(u => u.Username == Username);

                    if (usuario == null)
                        return "Usuario no encontrado.";

                    // Validar RFC antes de guardar

                    var validador = new ADD();


                    //valida el rfc excepto par el admin
                    if (nuevoTipo != 1 && !validador.ValidarRFC(nuevoRFC))
                        return "El RFC ingresado no es válido.";

                    // Validar telefono antes de guardar

                    if (!validador.ValidarTelefono(nuevoTelefono))
                        return "El teléfono debe contener solo números.";




                    // Actualizar contraseña solo si se proporciona
                    if (!string.IsNullOrEmpty(nuevaPassword))
                    {
                        string clave = "mi_clave_secreta";
                        usuario.password = Encriptacion.Encriptar(nuevaPassword, clave);
                    }


                    // Si no existe el detalle, lo creamos
                    if (usuario == null)
                    {
                        usuario = new User
                        {
                            Username = Username
                        };
                        context.User.InsertOnSubmit(usuario);
                    }

                    // Actualizar datos del detalle
                    usuario.Nombre = nuevoNombre;
                    usuario.Apellido_Pat = nuevoApellidoPat;
                    usuario.Apellido_Mat = nuevoApellidoMat;
                    usuario.Telefono = nuevoTelefono;
                    usuario.Correo = nuevoCorreo;
                    usuario.RFC = nuevoRFC;
                    usuario.tipo = nuevoTipo;
                    usuario.Ref = nuevoRef;

                    context.SubmitChanges();
                    return $"Se actualizado correctamente";
                }
            }
            catch (Exception ex)
            {
                return $"Error al actualizar usuario: {ex.Message}";
            }
        }


        public string EliminarUsuario(string username)
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {
                    var usuario = context.User.SingleOrDefault(u => u.Username == username);

                    if (usuario == null)
                        return "Usuario no encontrado.";


                    bool tieneSolicitudes = context.Solicitud_Adopcion.Any(s => s.Id_Usuario == usuario.Id_Usuario);
                    if (tieneSolicitudes)
                    {
                        // Aquí retornamos el mensaje de advertencia y NO borramos nada
                        return $"No se puede eliminar: El usuario '{username}' tiene solicitudes de adopción activas. Debes eliminarlas primero.";
                    }

                    // Luego eliminar el usuario
                    context.User.DeleteOnSubmit(usuario);

                    context.SubmitChanges();
                    return $"Usuario '{username}' eliminado correctamente.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al eliminar usuario: {ex.Message}";
            }
        }



        public ResultadoLogin Iniciar(string Username, string password)
        {
            using (var context = new DataClasses1DataContext())
            {
                string clave = "mi_clave_secreta";
                string passwordEncriptado = Encriptacion.Encriptar(password, clave);

                var usuario = context.User.SingleOrDefault(u => u.Username == Username && u.password == passwordEncriptado);

                if (usuario != null)
                {
                    return new ResultadoLogin
                    {
                        Exito = true,
                        Mensaje = "Inicio de sesión exitoso.",
                        TipoUsuario = usuario.tipo,
                        IdUsuario = usuario.Id_Usuario
                    };
                }
                else
                {
                    return new ResultadoLogin
                    {
                        Exito = false,
                        Mensaje = "Usuario o contraseña incorrectos.",
                        TipoUsuario = 0,
                        IdUsuario = 0
                    };
                }

            }
        }

        public string Refugio(string Nombre,
                            string Direccion,
                            string Estado,
                            string Ref)
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {
                    var Refugioinf = new Refugio
                    {
                        Nombre = Nombre,
                        Direccion = Direccion,
                        Estado = Estado,
                        Fecha = DateTime.Now,
                        Ref = Ref
                    };
                    context.Refugio.InsertOnSubmit(Refugioinf);
                    context.SubmitChanges();
                    return $"Registro exitoso";
                }
            }
            catch (Exception ex)
            {
                return $"Error al registrar usuario: {ex.Message}";
            }
        }

        public string EditarRefugio(int idRefugio, string nuevoNombre, string nuevaDireccion, string nuevoEstado, string Ref)
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {
                    var refugio = context.Refugio.SingleOrDefault(r => r.Id_Refugio == idRefugio);

                    if (refugio == null)
                        return "Refugio no encontrado.";

                    refugio.Id_Refugio = idRefugio;
                    refugio.Nombre = nuevoNombre;
                    refugio.Direccion = nuevaDireccion;
                    refugio.Estado = nuevoEstado;
                    refugio.Ref = Ref;

                    context.SubmitChanges();
                    return $"Refugio actualizado correctamente.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al actualizar refugio: {ex.Message}";
            }
        }


        public string EliminarRefugio(int idRefugio) // Quitamos "int IdAnimal", no se necesita
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {
                    // 1. Buscar el refugio
                    var refugio = context.Refugio.SingleOrDefault(r => r.Id_Refugio == idRefugio);

                    if (refugio == null)
                        return "Refugio no encontrado.";


                    var animalesDelRefugio = context.Animales.Where(a => a.Id_Refugio == idRefugio).ToList();

                    // Si hay animales, verificamos si alguno tiene solicitud
                    if (animalesDelRefugio.Any())
                    {
                        // Buscamos si existe alguna solicitud asociada a la lista de IDs de estos animales
                        var idsAnimales = animalesDelRefugio.Select(a => a.Id_Animal).ToList();

                        bool tieneSolicitudesActivas = context.Solicitud_Adopcion
                            .Any(s => idsAnimales.Contains(s.Id_Animal) && s.Situacion != "Rechazada");


                        if (tieneSolicitudesActivas)
                        {
                            return "No se puede eliminar: Hay animales en este refugio con solicitudes de adopción activas/pendientes.";
                        }

                        //  Si no hay solicitudes, eliminamos los animales primero (Cascada manual)
                        context.Animales.DeleteAllOnSubmit(animalesDelRefugio);
                    }

                    // 4. Eliminar el refugio
                    context.Refugio.DeleteOnSubmit(refugio);

                    // 5. Guardar cambios
                    context.SubmitChanges();

                    return $"El refugio y sus animales fueron eliminados correctamente.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al eliminar refugio y animales: {ex.Message}";
            }
        }

        public string Animales(string Nombre,
                       string Especie,
                       int Id_Refugio,
                       string Descripcion,
                       string Genero,
                       string Edad,
                       string Imagen,
                       string Tamano,
                       string Personalidad)
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {

                    var refugioExiste = context.Refugio.Any(r => r.Id_Refugio == Id_Refugio);
                    if (!refugioExiste)
                    {
                        return "Error: El Id_Refugio proporcionado no existe.";
                    }

                    var nuevoAnimal = new Animales
                    {
                        Nombre = Nombre,
                        Especie = Especie,
                        Id_Refugio = Id_Refugio,
                        Descripcion = Descripcion,
                        Fecha = DateTime.Now,
                        Genero = Genero,
                        Edad = Edad,
                        Imagen = Imagen,
                        Tamano = Tamano,
                        Personalidad = Personalidad
                    };
                    context.Animales.InsertOnSubmit(nuevoAnimal);
                    context.SubmitChanges();
                    return $"OK: Animal '{Nombre}' registrado con éxito en el refugio {Id_Refugio}.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al registrar animal: {ex.Message}";
            }
        }

        public string EditarAnimal(int idAnimal,
                           string nuevoNombre,
                           string nuevaEspecie,
                           int nuevoIdRefugio, // Nuevo Id_Refugio
                           string nuevaDescripcion,
                           string nuevoGenero,
                           string nuevaEdad,
                           string nuevaImagen,
                           string nuevaTamano,
                           string nuevaPersonalidad)
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {
                    var animal = context.Animales.SingleOrDefault(a => a.Id_Animal == idAnimal);

                    if (animal == null)
                        return "Error: Animal no encontrado.";

                    //Validar que el nuevo Id_Refugio exista
                    bool refugioExiste = context.Refugio.Any(r => r.Id_Refugio == nuevoIdRefugio);
                    if (!refugioExiste)
                    {
                        return "Error: El Id_Refugio de destino no existe.";
                    }

                    // Actualizar propiedades
                    animal.Nombre = nuevoNombre;
                    animal.Especie = nuevaEspecie;
                    animal.Id_Refugio = nuevoIdRefugio;
                    animal.Descripcion = nuevaDescripcion;
                    animal.Genero = nuevoGenero;
                    animal.Edad = nuevaEdad;
                    animal.Imagen = nuevaImagen;
                    animal.Tamano = nuevaTamano;
                    animal.Personalidad = nuevaPersonalidad;


                    context.SubmitChanges();
                    return $"Animal '{nuevoNombre}' actualizado correctamente.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al actualizar animal: {ex.Message}";
            }
        }

        public string EliminarAnimal(int idAnimal)
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {
                    var animal = context.Animales.SingleOrDefault(a => a.Id_Animal == idAnimal);

                    if (animal == null)
                        return "Error: Animal no encontrado.";

                    bool tieneSolicitudes = context.Solicitud_Adopcion.Any(s => s.Id_Animal == idAnimal);
                    if (tieneSolicitudes)
                    {
                        // Si existe en una solicitud, IMPEDIMOS borrar y avisamos
                        return $"No se puede eliminar: El animal '{animal.Nombre}' está vinculado a una o más solicitudes de adopción. Debes eliminar o rechazar esas solicitudes primero.";
                    }

                    // Eliminar el animal
                    context.Animales.DeleteOnSubmit(animal);

                    // Guardar cambios
                    context.SubmitChanges();

                    return $"Animal con ID {idAnimal} eliminado correctamente.";
                }
            }
            catch (Exception ex)
            {

                return $"Error al eliminar animal: {ex.Message}";
            }
        }

        public string Solicitud(int Id_Usuario, int Id_Animal, string Situacion, string Folio)
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {
                    // Validaciones de existencia
                    var usuarioExiste = context.User.Any(u => u.Id_Usuario == Id_Usuario);
                    if (!usuarioExiste)
                        return "Error: El Usuario proporcionado no existe.";

                    var animalExiste = context.Animales.Any(a => a.Id_Animal == Id_Animal);
                    if (!animalExiste)
                        return "Error: El Animal proporcionado no existe.";


                    bool yaSolicitado = context.Solicitud_Adopcion.Any(s => s.Id_Usuario == Id_Usuario
                                            && s.Id_Animal == Id_Animal && s.Situacion != "Rechazada");
                    if (yaSolicitado)
                        return "Este usuario ya tiene una solicitud activa para este animal.";

                    var nuevaSolicitud = new Solicitud_Adopcion
                    {
                        Id_Usuario = Id_Usuario,
                        Id_Animal = Id_Animal,
                        Situacion = Situacion, // Ej: "Pendiente", "Aprobada", "Rechazada"
                        Fecha = DateTime.Now,
                        Folio = Folio

                    };

                    context.Solicitud_Adopcion.InsertOnSubmit(nuevaSolicitud);
                    context.SubmitChanges();

                    return $"OK: Solicitud registrada con éxito.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al registrar solicitud: {ex.Message}";
            }
        }


        public string EditarSolicitud(int idSolicitud, int nuevoIdAnimal, string nuevaSituacion, string nuevoFolio)
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {
                    // Buscar la solicitud
                    var solicitud = context.Solicitud_Adopcion.SingleOrDefault(s => s.Id_Solicitud == idSolicitud);

                    if (solicitud == null)
                        return "Error: Solicitud no encontrada.";


                    if (solicitud.Id_Animal != nuevoIdAnimal)
                    {
                        bool animalExiste = context.Animales.Any(a => a.Id_Animal == nuevoIdAnimal);
                        if (!animalExiste) return "Error: El nuevo Id_Animal no existe.";
                    }

                    // Actualizar datos
                    solicitud.Id_Animal = nuevoIdAnimal;
                    solicitud.Situacion = nuevaSituacion;
                    solicitud.Folio = nuevoFolio;


                    context.SubmitChanges();
                    return $"Solicitud #{idSolicitud} actualizada a estado: {nuevaSituacion}.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al editar solicitud: {ex.Message}";
            }
        }

        public string EliminarSolicitud(int idSolicitud)
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {
                    var solicitud = context.Solicitud_Adopcion.SingleOrDefault(s => s.Id_Solicitud == idSolicitud);

                    if (solicitud == null)
                        return "Error: Solicitud no encontrada.";

                    context.Solicitud_Adopcion.DeleteOnSubmit(solicitud);
                    context.SubmitChanges();

                    return $"Solicitud #{idSolicitud} eliminada correctamente.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al eliminar solicitud: {ex.Message}";
            }
        }

        // 
        public List<Solicitud_Adopcion> ListarSolicitudes()
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {

                    return context.Solicitud_Adopcion
                                  .OrderByDescending(s => s.Fecha)
                                  .ToList();
                }
            }
            catch (Exception)
            {
                return new List<Solicitud_Adopcion>();
            }
        }


        public List<User> ListarUsuarios()
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {
                    return context.User
                                  .OrderByDescending(u => u.Fecha)
                                  .ToList();
                }
            }
            catch (Exception)
            {

                return new List<User>(); // Devuelve lista vacía si hay error
            }
        }

        public List<Refugio> ListaRefugio()
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {
                    return context.Refugio
                                  .OrderByDescending(r => r.Fecha)
                                  .ToList();
                }
            }
            catch (Exception)
            {

                return new List<Refugio>(); // Devuelve lista vacía si hay error
            }
        }

        public List<Animales> ListaAnimales()
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {
                    // Retorna todos los animales, ordenados por fecha de forma descendente (los más nuevos primero).
                    return context.Animales
                                  .OrderByDescending(a => a.Fecha)
                                  .ToList();
                }
            }
            catch (Exception)
            {
                return new List<Animales>();
            }
        }

        public string ObtenerFolio(int idSolicitud)
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {
                    // Buscamos la solicitud específica por su ID
                    var solicitud = context.Solicitud_Adopcion.SingleOrDefault(s => s.Id_Solicitud == idSolicitud);

                    if (solicitud != null)
                    {
                        // Si existe, retornamos el dato del Folio
                        return solicitud.Folio;
                    }
                    else
                    {
                        return "Solicitud no encontrada.";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error al obtener el folio: {ex.Message}";
            }
        }

        // Esta función recibe el ID del usuario y devuelve solo SUS solicitudes
        public List<Solicitud_Adopcion> ListarSolicitudesPorUsuario(int idUsuario)
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {
                    // Usamos .Where() para filtrar donde el Id_Usuario coincida
                    return context.Solicitud_Adopcion
                                  .Where(s => s.Id_Usuario == idUsuario)
                                  .OrderByDescending(s => s.Fecha) // Las más recientes primero
                                  .ToList();
                }
            }
            catch (Exception)
            {
                return new List<Solicitud_Adopcion>();
            }
        }
        // Esta función recibe el ID del refugio y devuelve los animales que pertenecen a él
        public List<Animales> ListarAnimalesPorRefugio(int idRefugio)
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {
                    // Filtramos por Id_Refugio
                    return context.Animales
                                  .Where(a => a.Id_Refugio == idRefugio)
                                  .OrderByDescending(a => a.Fecha) // Ordenamos por los más recientes
                                  .ToList();
                }
            }
            catch (Exception)
            {
                // En caso de error, devolvemos una lista vacía para que no truene el programa
                return new List<Animales>();
            }
        }

        // Esta función busca un usuario por su ID y devuelve todos sus datos
        public User ObtenerUsuarioPorId(int idUsuario)
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {
                    // Buscamos el usuario en la base de datos que coincida con el ID
                    var usuarioEncontrado = context.User.SingleOrDefault(u => u.Id_Usuario == idUsuario);

                    return usuarioEncontrado; // Retorna el usuario o null si no existe
                }
            }
            catch (Exception)
            {
                // En caso de error, retornamos null
                return null;
            }
        }

        public int ObtenerIdRefugioPorUsuario(int idUsuario)
        {
            try
            {
                using (var context = new DataClasses1DataContext())
                {
                    // 1. Buscamos al usuario
                    var usuario = context.User.SingleOrDefault(u => u.Id_Usuario == idUsuario);

                    // Verificamos que el usuario exista y tenga un Ref
                    if (usuario != null && !string.IsNullOrEmpty(usuario.Ref))
                    {
                        // LIMPIEZA DE DATOS: Quitamos espacios en blanco al inicio y final
                        string refUsuarioClean = usuario.Ref.Trim();

                        // 2. Buscamos el refugio comparando sin espacios
                        // Nota: Usamos Trim() también en la base de datos si LINQ to SQL lo permite, 
                        // o traemos el primero que coincida.
                        var refugio = context.Refugio.AsEnumerable() // Traemos a memoria para asegurar que el Trim funcione bien en C#
                                             .FirstOrDefault(r => r.Ref != null && r.Ref.Trim() == refUsuarioClean);

                        if (refugio != null)
                        {
                            return refugio.Id_Refugio;
                        }
                    }

                    // Si llegamos aquí, es que no se encontró coincidencia
                    return 0;
                }
            }
            catch (Exception ex)
            {
                // IMPORTANTE: Para depurar, no retornes 0 ciegamente. 
                // Lanza la excepción o guárdala en un log para saber qué pasó.
                // Cuando ya funcione todo, puedes volver a poner "return 0;"
                throw new Exception("Error interno buscando Refugio: " + ex.Message);
            }
        }
    }
}
