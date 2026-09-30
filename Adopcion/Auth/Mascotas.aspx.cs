using AdopcionWS;
using System;
using System.Collections.Generic;
using System.Linq; // Necesario para .AsEnumerable(), .Where(), etc.
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Asegúrate de que Adopcion_Data esté referenciado si el compilador no reconoce 'Animales'
using Adopcion_Data;

namespace Adopcion
{
    public partial class Mascotas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlarMenuSesion();

            if (!IsPostBack)
            {
                CargarMascotasDesdeWS();
            }
        }

        private void ControlarMenuSesion()
        {
            if (Session["usuario"] != null)
            {
                // SI ESTÁ LOGUEADO:
                phAnonimo.Visible = false;   // Ocultar botón Acceder
                phLogueado.Visible = true;   // Mostrar botón Cerrar Sesión

                // Mostrar el nombre (si lo tienes guardado en sesión)
                litNombreUsuario.Text = Session["usuario"].ToString();


                if (Session["tipo"] != null)
                {
                    int tipoUsuario = 0;
                    // Convertimos a int de forma segura (funciona si guardaste un int o un string "2")
                    int.TryParse(Session["tipo"].ToString(), out tipoUsuario);

                    if (tipoUsuario == 2)
                    {
                        phRefugio.Visible = true; // Solo se muestra si es tipo 2
                    }
                }

            }
            else
            {
                // SI NO ESTÁ LOGUEADO:
                phAnonimo.Visible = true;    // Mostrar botón Acceder
                phLogueado.Visible = false;  // Ocultar botón Cerrar Sesión
            }
        }

        // --- EVENTO PARA CERRAR SESIÓN ---
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // 1. Limpiar variables de sesión
            Session.Remove("usuario");
            Session.Remove("tipo");
            Session.RemoveAll();

            // 2. Destruir la sesión
            Session.Abandon();

            // 3. Recargar la página para que se actualice el menú
            Response.Redirect("Mascotas.aspx");
        }

        public string EspecieSeleccionada
        {
            get { return ViewState["EspecieSeleccionada"] as string ?? "Todos"; }
            set { ViewState["EspecieSeleccionada"] = value; }
        }

        private void CargarMascotasDesdeWS()
        {
            // 1. INSTANCIAR EL SERVICIO WEB
            // Asumo que agregaste la referencia web con el nombre "Data_AdopcionWs"
            // y que tu servicio se llama "WebService1".
            AdopcionWS.WebService1 servicio = new AdopcionWS.WebService1();

            // 2. LLAMAR AL MÉTODO CORRECTO
            // En tu código de servicio el método se llama "ListarAnimales"
            var listaBruta = servicio.ListarAnimales();

            // Verificamos si trajo datos (Los servicios web a veces devuelven arrays null)
            if (listaBruta == null || listaBruta.Count == 0)
            {
                RepMascotasPage.DataSource = null;
                RepMascotasPage.DataBind();
                return;
            }

            // 3. FILTRAR CON LINQ
            // Convertimos el Array que devuelve el WS a una lista enumerable para filtrar
            var consulta = listaBruta.AsEnumerable();

            // --- A: Filtro Especie ---
            if (EspecieSeleccionada != "Todos")
            {
                consulta = consulta.Where(a => a.Especie.Equals(EspecieSeleccionada, StringComparison.OrdinalIgnoreCase));
            }

            // --- B: Filtro Edad ---
            if (ddlEdad.SelectedValue != "Todos")
            {
                consulta = consulta.Where(a => a.Edad == ddlEdad.SelectedValue);
            }

            // --- C: Filtro Tamaño ---
            if (ddlTamano.SelectedValue != "Todos")
            {
                consulta = consulta.Where(a => a.Tamano == ddlTamano.SelectedValue);
            }

            // Asegúrate de que en tu Base de Datos esté guardado como "Macho" y "Hembra"
            if (ddlGenero.SelectedValue != "Todos")
            {
                consulta = consulta.Where(a => a.Genero == ddlGenero.SelectedValue);
            }

            // 4. MOSTRAR RESULTADOS
            var resultados = consulta.ToList();

            if (resultados.Count > 0)
            {
                RepMascotasPage.DataSource = resultados;
            }
            else
            {
                RepMascotasPage.DataSource = null;
            }

            RepMascotasPage.DataBind();
        }

        protected void btnAdoptar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Adoptar")
            {
                // 1. VALIDAR SESIÓN (¿Está logueado?)
                if (Session["usuario"] == null)
                {
                    // No está logueado -> Alerta y redirigir a Login
                    MostrarAlerta("⚠️ Debes iniciar sesión para adoptar una mascota.");

                    // Pequeño truco JS para redirigir después de que el usuario lea la alerta (o al instante)
                    // Como el Response.Redirect corta la ejecución, usamos un script:
                    string script = "<script>alert('⚠️ Debes iniciar sesión para adoptar una mascota.'); window.location.href='Login.aspx';</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "AlertaLogin", script);
                    return;
                }

                // 2. VALIDAR TIPO DE USUARIO (¿Es Adoptador?)
                // Asumiendo que guardas el tipo como int o string en la sesión
                int tipoUsuario = Convert.ToInt32(Session["tipo"]);

                if (tipoUsuario != 3) // Si NO es tipo 3 (Adoptador)
                {
                    MostrarAlerta("🚫 Lo sentimos, solo los usuarios registrados como 'Adoptadores' pueden enviar solicitudes.");
                    return;
                }

                // 3. SI PASA TODO -> REDIRIGIR A SOLICITUD
                string idAnimal = e.CommandArgument.ToString();
                Response.Redirect("Solicitud-adopcion.aspx?idAnimal=" + idAnimal);
            }
        }

        // Función auxiliar para mostrar alertas limpias
        private void MostrarAlerta(string mensaje)
        {
            // Escapamos el mensaje para evitar errores de JS
            string script = $"<script>alert('{mensaje}');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Alerta", script);
        }

        private void ActualizarEstilosBotones()
        {
            // 1. Reseteamos todos los botones a su estilo base (sin 'active')
            // Asegúrate de que los IDs (btnFiltroTodos, etc.) coincidan con tu HTML (.aspx)
            btnFiltroTodos.CssClass = "filter-pill";
            btnFiltroPerros.CssClass = "filter-pill";
            btnFiltroGatos.CssClass = "filter-pill";

            // 2. Agregamos la clase 'active' solo al botón seleccionado actualmente
            switch (EspecieSeleccionada)
            {
                case "Perro":
                    btnFiltroPerros.CssClass += " active";
                    break;
                case "Gato":
                    btnFiltroGatos.CssClass += " active";
                    break;
                default: // Caso "Todos"
                    btnFiltroTodos.CssClass += " active";
                    break;
            }
        }

        protected void BtnFiltroEspecie_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            EspecieSeleccionada = btn.CommandArgument; // "Todos", "Perro", "Gato"

            // Actualizar visualmente los botones (para que se ponga en negrita/color el seleccionado)
            ActualizarEstilosBotones();

            // Recargar la lista
            CargarMascotasDesdeWS();

        }

        protected void FiltrosCombinados_Event(object sender, EventArgs e)
        {
            CargarMascotasDesdeWS();
        }
    }
}