using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_AdopcionWS
{
    public class DATABASEWS
    {
        /* public int restanumeros (int numero1, int numero2)
        { return numero1 - numero2; }
        public string reportes(string nombre, string situacion, string ubicacion)
        {
            return reportes(nombre, situacion, ubicacion);
        }
            //return $"{nombre}-{situacion}-{ubicacion}"; */



        public string RegistrarSolicitudWS(string Id_SolicitudWS,
                                         int idUsuario,
                                         int idAnimal,
                                         int edad,
                                         string ocupacion,
                                         string direccion,
                                         string telefono,
                                         string redes,
                                         string tipoVivienda,
                                         string tenencia,
                                         string permisoDuenio,
                                         string seguridad,
                                         string integrantes,
                                         string acuerdo,
                                         string alergias,
                                         string otrasMascotas,
                                         string sociabilidad,
                                         string horasSolo,
                                         string lugarDormir,
                                         string mudanza,
                                         string motivo,
                                         bool aceptaGastos,
                                         bool aceptaCompromiso)

        {
            try
            {
                using (var context = new DataClassesWSDataContext())
                {
                    // Creamos el objeto basado en la tabla SolicitudesAdopcion
                    var nuevaSolicitud = new SolicitudesAdopcionWS
                    {
                        // Relaciones
                        Id_SolicitudWS = Id_SolicitudWS,
                        Id_Usuario = idUsuario,
                        Id_Animal = idAnimal,
                        FechaSolicitud = DateTime.Now,

                        // 1. Datos Personales
                        EdadSolicitante = edad,
                        Ocupacion = ocupacion,
                        DireccionCompleta = direccion,
                        Telefono = telefono,
                        RedesSociales = redes,

                        // 2. Vivienda
                        TipoVivienda = tipoVivienda,
                        TenenciaInmueble = tenencia,
                        PermisoDuenio = permisoDuenio,
                        SeguridadEntorno = seguridad,

                        // 3. Familia
                        IntegrantesHogar = integrantes,
                        AcuerdoFamiliar = acuerdo,
                        HayAlergias = alergias,
                        OtrasMascotas = otrasMascotas,
                        SociabilidadMascotas = sociabilidad,

                        // 4. Rutina
                        HorasSolo = horasSolo,
                        LugarDormir = lugarDormir,
                        PlanMudanza = mudanza,
                        MotivoAdopcion = motivo,

                        // Checkboxes (bool)
                        AceptaGastos = aceptaGastos,
                        AceptaCompromiso = aceptaCompromiso
                    };

                    // Guardamos en la base de datos
                    context.SolicitudesAdopcionWS.InsertOnSubmit(nuevaSolicitud);
                    context.SubmitChanges();

                    return "Solicitud enviada con éxito";
                }
            }
            catch (Exception ex)
            {
                // Retorna el mensaje de error para mostrarlo en la alerta
                return $"Error al registrar solicitud: {ex.Message}";
            }
        }
    

    public string EliminarSolicitudWS(string Id_SolicitudWS)
        {
            try
            {
                using (var context = new DataClassesWSDataContext())
                {
                    // 1. Buscamos la solicitud específica por su ID (Primary Key)
                    var solicitud = context.SolicitudesAdopcionWS
                                           .SingleOrDefault(x => x.Id_SolicitudWS == Id_SolicitudWS);

                    // 2. Verificamos si realmente se encontró algo
                    if (solicitud != null)
                    {
                        // 3. Marcamos el objeto para ser eliminado
                        context.SolicitudesAdopcionWS.DeleteOnSubmit(solicitud);

                        // 4. Confirmamos los cambios en la base de datos
                        context.SubmitChanges();

                        return "Solicitud eliminada correctamente";
                    }
                    else
                    {
                        return "Error: No se encontró ninguna solicitud con ese ID.";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error al eliminar la solicitud: {ex.Message}";
            }
        }

        // Esta función devuelve TODOS los datos de una sola solicitud
        public SolicitudesAdopcionWS ObtenerSolicitudPorId(string Id_SolicitudWS)
        {
            SolicitudesAdopcionWS solicitudEncontrada = null;

            try
            {
                using (var context = new DataClassesWSDataContext())
                {
                    // Busca en la base de datos el registro que tenga ese ID exacto
                    solicitudEncontrada = context.SolicitudesAdopcionWS
                                                 .SingleOrDefault(x => x.Id_SolicitudWS == Id_SolicitudWS);
                }
            }
            catch (Exception)
            {
                // En caso de error, retornamos null
                return null;
            }

            // Retorna el objeto completo con toda la info (Edad, Dirección, Ocupación, etc.)
            return solicitudEncontrada;
        }

        // Función para guardar Nombre, Correo, Descripción y Fecha
        public string RegistrarMensajeWS(string nombre, string correo, string descripcion)
        {
            try
            {
                using (var context = new DataClassesWSDataContext())
                {
                    

                    var nuevoMensaje = new WScontacto
                    {
                        nombre = nombre,
                        correo = correo,
                        descripcion = descripcion,           
                        fecha = DateTime.Now
                    };

                    // Preparamos la inserción (cambia también aquí 'TuTablaDeMensajes')
                    context.WScontacto.InsertOnSubmit(nuevoMensaje);

                    // Guardamos los cambios en la BD
                    context.SubmitChanges();

                    return "Información guardada con éxito";
                }
            }
            catch (Exception ex)
            {
                return $"Error al guardar la información: {ex.Message}";
            }
        }
    } 
}  
