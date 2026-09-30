using Adopcion_Data;
using Data_AdopcionWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AdopcionWS
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://adopcionws.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        DATABASE db = new DATABASE();
        DATABASEWS dbWS = new DATABASEWS();

        [WebMethod]
        public string RegistroUsuarios(string Username, 
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
            return db.Registrar(Username, 
                                password, 
                                tipo, 
                                nombre, 
                                apellidoPat, 
                                apellidoMat, 
                                telefono, 
                                correo, 
                                rfc,
                                Ref);
        }

        [WebMethod]
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
            return db.EditarUsuario(Username, 
                                    nuevaPassword, 
                                    nuevoTipo, 
                                    nuevoNombre, 
                                    nuevoApellidoPat, 
                                    nuevoApellidoMat, 
                                    nuevoTelefono, 
                                    nuevoCorreo, 
                                    nuevoRFC, 
                                    nuevoRef);
        }

        [WebMethod]
        public string EliminarUsuario(string username)
        {
            return db.EliminarUsuario(username);
        }

        [WebMethod]
        public DATABASE.ResultadoLogin Login(string Username, string password)
        {
            
            return db.Iniciar(Username, password);
        }

        [WebMethod]
        public List<User> ListarUsuarios()
        {
            return db.ListarUsuarios();
        }

        // --- MÉTODOS DE REFUGIOS ---

        [WebMethod]
        public string RegistroRefugio(string Nombre, string Direccion, string Estado, string Ref)
        {
            return db.Refugio(Nombre, Direccion, Estado, Ref);
        }

        [WebMethod]
        public string EditarRefugio(int idRefugio, string nuevoNombre, string nuevaDireccion, string nuevoEstado, string Ref)
        {
            return db.EditarRefugio(idRefugio, nuevoNombre, nuevaDireccion, nuevoEstado, Ref);
        }

        [WebMethod]
        public string EliminarRefugio(int idRefugio)
        {
            return db.EliminarRefugio(idRefugio);
        }

        [WebMethod]
        public List<Refugio> ListarRefugios()
        {
            return db.ListaRefugio();
        }

        // --- MÉTODOS DE ANIMALES ---

        [WebMethod]
        public string RegistroAnimal(string Nombre, string Especie, int Id_Refugio, string Descripcion, string Genero, string Edad, string Imagen, string Tamano, string Personalidad)
        {
            return db.Animales(Nombre, Especie, Id_Refugio, Descripcion, Genero, Edad, Imagen, Tamano, Personalidad);
        }

        [WebMethod]
        public string EditarAnimal(int idAnimal, string nuevoNombre, string nuevaEspecie, int nuevoIdRefugio, string nuevaDescripcion, string nuevoGenero, string nuevaEdad, string nuevaImagen, string nuevaTamano, string nuevaPersonalidad)
        {
            return db.EditarAnimal(idAnimal, nuevoNombre, nuevaEspecie, nuevoIdRefugio, nuevaDescripcion, nuevoGenero, nuevaEdad, nuevaImagen, nuevaTamano, nuevaPersonalidad);
        }

        [WebMethod]
        public string ObtenerFolio(int idSolicitud)
        {
            // Llama a la función que creamos en la clase DATABASE
            return db.ObtenerFolio(idSolicitud);
        }


        [WebMethod]
        public string EliminarAnimal(int idAnimal)
        {
            return db.EliminarAnimal(idAnimal);
        }

        [WebMethod]
        public List<Animales> ListarAnimales()
        {
            return db.ListaAnimales();
        }

        

        [WebMethod]
        public string RegistroSolicitud(int Id_Usuario, int Id_Animal, string Situacion, string Folio)
        {
            return db.Solicitud(Id_Usuario, Id_Animal, Situacion, Folio);
        }

        [WebMethod]
        public string EditarSolicitud(int idSolicitud, int nuevoIdAnimal, string nuevaSituacion, string nuevoFolio)
        {
            return db.EditarSolicitud(idSolicitud, nuevoIdAnimal, nuevaSituacion, nuevoFolio);
        }

        [WebMethod]
        public string EliminarSolicitud(int idSolicitud)
        {
            return db.EliminarSolicitud(idSolicitud);
        }

        [WebMethod]
        public List<Solicitud_Adopcion> ListarSolicitudes()
        {
            return db.ListarSolicitudes();
        }

        [WebMethod]
        public string RegistrarMensajeWS(string nombre, string correo, string descripcion)
        {
            return dbWS.RegistrarMensajeWS(nombre, correo, descripcion);
        }

        [WebMethod]
        public string RegistrarSolicitudCompleta(string Id_SolicitudWS,
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
            // Llamamos a la función de tu clase DATABASEWS (dbWS)
            return dbWS.RegistrarSolicitudWS(
                Id_SolicitudWS, idUsuario, idAnimal, edad, ocupacion, direccion, telefono, redes,
                tipoVivienda, tenencia, permisoDuenio, seguridad,
                integrantes, acuerdo, alergias, otrasMascotas, sociabilidad,
                horasSolo, lugarDormir, mudanza, motivo,
                aceptaGastos, aceptaCompromiso
            );
        }

        [WebMethod]
        public string EliminarSolicitudCompleta(string Id_SolicitudWS)
        {
            // Llamamos a la función que acabamos de crear en la clase lógica
            return dbWS.EliminarSolicitudWS(Id_SolicitudWS);
        }

        [WebMethod]
        public SolicitudesAdopcionWS VerDetalleSolicitud(string Id_SolicitudWS)
        {
            // Llamamos a la función de lectura que creamos en DATABASEWS
            return dbWS.ObtenerSolicitudPorId(Id_SolicitudWS);
        }

        [WebMethod]
        public List<Solicitud_Adopcion> ListarSolicitudesPorUsuario(int idUsuario)
        {
            // Llama a la función específica que creamos en DATABASE
            return db.ListarSolicitudesPorUsuario(idUsuario);
        }

        [WebMethod]
        public List<Animales> ListarAnimalesPorRefugio(int idRefugio)
        {
            // Llama a la función específica que creamos en DATABASE
            return db.ListarAnimalesPorRefugio(idRefugio);
        }

        [WebMethod]
        public Adopcion_Data.User ObtenerInfoUsuario(int idUsuario)
        {
            Adopcion_Data.DATABASE db = new Adopcion_Data.DATABASE();

            // Ahora sí coinciden: La función devuelve un User y el WebMethod espera un User
            return db.ObtenerUsuarioPorId(idUsuario);
        }

        [WebMethod]
        public int ObtenerIdRefugioPorUsuario(int idUsuario)
        {
            // Llamamos a la nueva función que agregamos a la clase DATABASE
            return db.ObtenerIdRefugioPorUsuario(idUsuario);
        }

    }
}
