using Adopcion_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adopcion
{
    public partial class Versolicitud : System.Web.UI.Page
    {
        AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idParam = Request.QueryString["id"];
                int idSolicitud;

                if (int.TryParse(idParam, out idSolicitud))
                {
               
                    string folio = servicio.ObtenerFolio(idSolicitud);

                    // Validamos que hayamos obtenido un folio real y no un mensaje de error
                    if (!string.IsNullOrEmpty(folio) && !folio.Contains("Error") && !folio.Contains("no encontrada"))
                    {
                        // PASO 3: Cargamos los detalles usando ese Folio
                        CargarDatosSolicitud(folio);
                    }
                    else
                    {
                        // Si falló al obtener el folio
                        MostrarAlerta("No se pudo obtener el folio para esta solicitud o no existe.");
                        btnAprobar.Enabled = false; // Deshabilitamos botones por seguridad
                    }
                }
                else
                {
                    MostrarAlerta("ID de solicitud no válido.");
                }
            }
        }

        private void MostrarAlerta(string mensaje)
        {
            string script = $"alert('{mensaje}');";
            ClientScript.RegisterStartupScript(this.GetType(), "Alerta", script, true);
        }

        private void CargarDatosSolicitud(string folio)
        {
            try
            {
                // OPCIÓN 1: Llamando Directo a tu clase DATABASEWS (Si está en el mismo proyecto)
                
                var solicitud = servicio.VerDetalleSolicitud(folio);

                // OPCIÓN 2: Si usas Web Service, sería algo como:
              

                if (solicitud != null)
                {
                    // --- ENCABEZADO ---
                    lblFolio.Text = solicitud.Id_SolicitudWS;
                    lblIdUsuario.Text = solicitud.Id_Usuario.ToString();
                    lblIdAnimal.Text = solicitud.Id_Animal.ToString();

                    // --- 1. DATOS PERSONALES ---
                    lblEdad.Text = solicitud.EdadSolicitante.ToString() + " años";
                    lblOcupacion.Text = solicitud.Ocupacion;
                    lblTelefono.Text = solicitud.Telefono;
                    lblDireccion.Text = solicitud.DireccionCompleta;
                    lblRedes.Text = solicitud.RedesSociales;

                    // --- 2. VIVIENDA ---
                    lblTipoVivienda.Text = solicitud.TipoVivienda;
                    lblTenencia.Text = solicitud.TenenciaInmueble;
                    lblPermisoDuenio.Text = solicitud.PermisoDuenio;
                    lblSeguridad.Text = solicitud.SeguridadEntorno;

                    // --- 3. FAMILIA ---
                    lblIntegrantes.Text = solicitud.IntegrantesHogar;
                    lblAcuerdo.Text = solicitud.AcuerdoFamiliar;
                    lblAlergias.Text = solicitud.HayAlergias;
                    lblOtrasMascotas.Text = solicitud.OtrasMascotas;
                    lblSociabilidad.Text = solicitud.SociabilidadMascotas;

                    // --- 4. RUTINA ---
                    lblHorasSolo.Text = solicitud.HorasSolo;
                    lblLugarDormir.Text = solicitud.LugarDormir;
                    lblMudanza.Text = solicitud.PlanMudanza;

                    // Motivo (Texto largo)
                    lblMotivo.Text = solicitud.MotivoAdopcion;

                    // --- 5. COMPROMISOS (CHECKBOXES / BOOLEANOS) ---
                    // Aquí cambiamos el color del ícono dependiendo si es true o false

                    if (solicitud.AceptaGastos == true)
                    {
                        lblIconoGastos.CssClass = "me-2 text-success"; // Verde
                        lblIconoGastos.Text = "<i class='fa fa-check-circle'></i> Sí acepta gastos";
                    }
                    else
                    {
                        lblIconoGastos.CssClass = "me-2 text-danger"; // Rojo
                        lblIconoGastos.Text = "<i class='fa fa-times-circle'></i> NO acepta gastos";
                    }

                    if (solicitud.AceptaCompromiso == true)
                    {
                        lblIconoCompromiso.CssClass = "me-2 text-success";
                        lblIconoCompromiso.Text = "<i class='fa fa-check-circle'></i> Sí acepta compromiso de vida";
                    }
                    else
                    {
                        lblIconoCompromiso.CssClass = "me-2 text-danger";
                        lblIconoCompromiso.Text = "<i class='fa fa-times-circle'></i> NO acepta compromiso";
                    }
                }
                else
                {
                    lblFolio.Text = "No encontrado";
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error al cargar datos: {ex.Message}');</script>");
            }
        }

        private void ActualizarEstado(string nuevoEstado)
        {
            try
            {
                // 1. Obtener el ID de la URL
                string idParam = Request.QueryString["id"];
                if (string.IsNullOrEmpty(idParam)) return;
                int idSolicitud = int.Parse(idParam);

                // 2. Obtener los datos actuales de los Labels para no perderlos
                
                int idAnimalActual = int.Parse(lblIdAnimal.Text);
                string folioActual = lblFolio.Text;

            

                // 3. Llamar a tu función EditarSolicitud
                string resultado = servicio.EditarSolicitud(idSolicitud, idAnimalActual, nuevoEstado, folioActual);

                // 4. Redirigir
                Response.Redirect("Admin_solicitudes.aspx");
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error al actualizar: " + ex.Message);
            }
        }

        // --- BOTONES DE ACCIÓN ---

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            ActualizarEstado("Aprobada");
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            ActualizarEstado("Rechazada");
        }

        protected void btnPendiente_Click(object sender, EventArgs e)
        {
            ActualizarEstado("Pendiente");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_solicitudes.aspx");
        }
    }
}