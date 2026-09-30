<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Solicitud-adopcion.aspx.cs" Inherits="Adopcion.solicitud_adopcion" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Solicitud de Adopción</title>
    <link href="../Content/CSS/bootstrap.css" rel="stylesheet" />
    <link href="../Content/CSS/bootstrap_icons.css" rel="stylesheet" />
    <link href="../Content/Login/Login1.css" rel="stylesheet" type="text/css" />
    <link href="../Content/Login/Login2.css" rel="stylesheet" type="text/css" />
    <script src="../Content/JS/Validar.js"></script>

    <style>
        .gradient-custom {
            background: linear-gradient(to right, #7fbce9, #1f4e79);            
            min-height: 100vh;
        }
        /* Ajuste para que los inputs se vean bien en fondo oscuro */
        .card.bg-dark input, 
        .card.bg-dark select, 
        .card.bg-dark textarea {
            background-color: #f8f9fa; 
            border: 1px solid #ced4da;
        }
        .form-section-title {
            border-bottom: 1px solid #4f5b66;
            padding-bottom: 10px;
            margin-bottom: 20px;
            margin-top: 20px;
            color: #6bbef9; /* Un azul claro para resaltar sobre negro */
        }
    </style>
</head>
<body class="gradient-custom">
    <form id="form1" runat="server">
        <asp:HiddenField ID="hfIdAnimal" runat="server" />
        <div class="container py-5">
            
            <div class="text-center mb-4 text-white">
                <h2 class="fw-bold">Formulario de Adopción Responsable</h2>
                <p>Estás a un paso de cambiar una vida. Por favor, responde con sinceridad.</p>
                <div class="alert alert-light d-inline-block text-dark shadow-sm">
                    Estás solicitando adoptar a: <asp:Label ID="lblNombreMascota" runat="server" Font-Bold="true" ForeColor="#0d6efd"></asp:Label>
                </div>
            </div>

            <div class="row justify-content-center">
                <div class="col-lg-8 col-md-10">
                    <div class="card shadow-lg border-0">
                        <div class="card-body bg-dark text-white p-5 rounded">

                            <h4 class="form-section-title"><i class="bi bi-person-lines-fill me-2"></i>1. Datos Personales</h4>
                            
                            <div class="row mb-3">
                                <div class="col-md-6">
                                    <label class="form-label">Edad <small class="text-muted">(Debe ser mayor de edad)</small></label>
                                    <asp:TextBox ID="txtEdad" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <label class="form-label">Ocupación</label>
                                    <asp:TextBox ID="txtOcupacion" runat="server" CssClass="form-control" placeholder="Ej. Estudiante, Empleado, etc."></asp:TextBox>
                                </div>
                            </div>

                            <div class="mb-3">
                                <label class="form-label">Dirección Completa</label>
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                            </div>

                            <div class="row mb-3">
                                <div class="col-md-6">
                                    <label class="form-label">Teléfono / Celular</label>
                                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <label class="form-label">Redes Sociales (Facebook/Instagram)</label>
                                    <asp:TextBox ID="txtRedes" runat="server" CssClass="form-control" placeholder="Para verificar identidad"></asp:TextBox>
                                </div>
                            </div>


                            <h4 class="form-section-title"><i class="bi bi-house-door me-2"></i>2. Vivienda y Entorno</h4>

                            <div class="row mb-3">
                                <div class="col-md-6">
                                    <label class="form-label">Tipo de Vivienda</label>
                                    <asp:DropDownList ID="ddlVivienda" runat="server" CssClass="form-select">
                                        <asp:ListItem Text="Selecciona..." Value="" />
                                        <asp:ListItem Text="Casa" Value="Casa" />
                                        <asp:ListItem Text="Departamento" Value="Departamento" />
                                        <asp:ListItem Text="Finca / Terreno" Value="Finca" />
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-6">
                                    <label class="form-label">Tenencia</label>
                                    <asp:RadioButtonList ID="rblPropiedad" runat="server" CssClass="form-check" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="&nbsp;Propia&nbsp;&nbsp;" Value="Propia" />
                                        <asp:ListItem Text="&nbsp;Rentada" Value="Rentada" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>

                            <div class="mb-3 p-3 border border-secondary rounded">
                                <label class="form-label text-info">Si rentas: ¿El dueño permite mascotas?</label>
                                <asp:RadioButtonList ID="rblPermiso" runat="server" CssClass="form-check">
                                    <asp:ListItem Text="Sí, está permitido" Value="Si" />
                                    <asp:ListItem Text="No / No estoy seguro" Value="No" />
                                    <asp:ListItem Text="No aplica (Casa propia)" Value="NA" Selected="True" />
                                </asp:RadioButtonList>
                            </div>

                            <div class="mb-3">
                                <label class="form-label">Seguridad: ¿Tienes patio cercado o protecciones en ventanas?</label>
                                <asp:TextBox ID="txtSeguridad" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" placeholder="Ej: Sí, tengo barda de 2 metros..."></asp:TextBox>
                            </div>


                            <h4 class="form-section-title"><i class="bi bi-people me-2"></i>3. Familia y Convivencia</h4>

                            <div class="row mb-3">
                                <div class="col-md-6">
                                    <label class="form-label">¿Quiénes viven en casa?</label>
                                    <asp:TextBox ID="txtIntegrantes" runat="server" CssClass="form-control" placeholder="Ej: 2 adultos, 1 niño"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <label class="form-label">¿Todos están de acuerdo?</label>
                                    <asp:DropDownList ID="ddlAcuerdo" runat="server" CssClass="form-select">
                                        <asp:ListItem Text="Sí, todos" Value="Si" />
                                        <asp:ListItem Text="Aún no lo consulto" Value="No" />
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="mb-3">
                                <label class="form-label">¿Hay personas alérgicas en casa?</label>
                                <asp:RadioButtonList ID="rblAlergias" runat="server" CssClass="form-check" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="&nbsp;Sí&nbsp;&nbsp;" Value="Si" />
                                    <asp:ListItem Text="&nbsp;No" Value="No" Selected="True" />
                                </asp:RadioButtonList>
                            </div>

                            <div class="mb-3 border-top border-secondary pt-3">
                                <label class="form-label">Otras mascotas actuales (Especies, y si están esterilizados)</label>
                                <asp:TextBox ID="txtOtrasMascotas" runat="server" CssClass="form-control" placeholder="Ej: Un perro pug de 3 años, castrado."></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label class="form-label">¿Cómo se llevan tus mascotas con otros animales?</label>
                                <asp:TextBox ID="txtSociabilidad" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>


                            <h4 class="form-section-title"><i class="bi bi-clock-history me-2"></i>4. Rutina y Compromiso</h4>

                            <div class="row mb-3">
                                <div class="col-md-6">
                                    <label class="form-label">Tiempo que pasará solo al día</label>
                                    <asp:DropDownList ID="ddlHorasSoledad" runat="server" CssClass="form-select">
                                        <asp:ListItem Text="0 - 4 horas" Value="0-4" />
                                        <asp:ListItem Text="4 - 8 horas" Value="4-8" />
                                        <asp:ListItem Text="Más de 8 horas" Value="8+" />
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-6">
                                    <label class="form-label">¿Dónde dormirá la mascota?</label>
                                    <asp:TextBox ID="txtDormir" runat="server" CssClass="form-control" placeholder="Ej: Dentro de casa, en su cama..."></asp:TextBox>
                                </div>
                            </div>

                            <div class="mb-3">
                                <label class="form-label">Si te mudas, ¿qué pasará con la mascota?</label>
                                <asp:TextBox ID="txtMudanza" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <label class="form-label">¿Por qué quieres adoptar a ESTA mascota específicamente?</label>
                                <asp:TextBox ID="txtMotivo" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </div>

                            <div class="form-check mb-4 p-3 bg-secondary bg-opacity-25 rounded border border-secondary">
                                <input type="checkbox" id="chkGasto" runat="server" class="form-check-input" />
                                <label class="form-check-label text-white" for="chkGastos">
                                    Estoy dispuesto a cubrir gastos de alimentación de calidad y atención veterinaria (vacunas, urgencias).
                                </label>
                            </div>

                            <div class="form-check mb-4 p-3 bg-secondary bg-opacity-25 rounded border border-secondary">
                                <input type="checkbox" id="chkCompromi" runat="server" class="form-check-input" />
                                <label class="form-check-label text-white small" for="chkCompromiso">
                                    Declaro que la información es verdadera y entiendo que adoptar es un compromiso de por vida (10-15 años).
                                </label>
                            </div>

                            <div class="d-grid gap-2 mt-5">
                                <asp:Button ID="btnEnviarSolicitud" runat="server" Text="Enviar Solicitud" 
                                    CssClass="btn btn-primary btn-lg fw-bold" 
                                    OnClientClick="return validarFormulario('<%= txtTelefono.ClientID %>', '<%= chkGasto.ClientID %>', '<%= chkCompromi.ClientID %>');" 
                                    OnClick="btnEnviarSolicitud_Click" />

                                <a href="Mascotas.aspx" class="btn btn-outline-light">Cancelar</a>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
