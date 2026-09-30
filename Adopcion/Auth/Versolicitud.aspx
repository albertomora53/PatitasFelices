<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Versolicitud.aspx.cs" Inherits="Adopcion.Versolicitud" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Detalle de Solicitud</title>
    <link href="../Content/CSS/bootstrap.css" rel="stylesheet" />
    <link href="../Content/CSS/bootstrap_icons.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />
    
    <style>
        .gradient-custom {
            background: linear-gradient(to right, #7fbce9, #1f4e79);            
            min-height: 100vh;
        }
        .card-custom {
            background-color: rgba(33, 37, 41, 0.95); /* Un poco más sólido que antes para lectura */
            border-radius: 1rem;
        }
        .form-section-title {
            border-bottom: 1px solid #4f5b66;
            padding-bottom: 10px;
            margin-bottom: 20px;
            margin-top: 30px;
            color: #6bbef9; 
            font-weight: bold;
        }
        /* Estilo para los datos en modo lectura */
        .dato-label {
            color: #adb5bd; /* Gris claro para el título del campo */
            font-size: 0.9rem;
            margin-bottom: 2px;
            display: block;
        }
        .dato-valor {
            color: #fff; /* Blanco brillante para el valor */
            font-size: 1.1rem;
            font-weight: 500;
            border-bottom: 1px solid #495057;
            padding-bottom: 5px;
            margin-bottom: 15px;
            display: block;
            min-height: 30px; /* Para que se vea la línea aunque esté vacío */
        }
        .check-display {
            color: #28a745; /* Verde para indicar positivo */
            font-size: 1.1rem;
        }
    </style>
</head>
<body class="gradient-custom">
    <form id="form1" runat="server">
        <div class="container py-5">
            
            <div class="text-center mb-4 text-white">
                <h2 class="fw-bold">Detalle de Solicitud</h2>
                <div class="d-flex justify-content-center gap-3 mt-3">
                    <span class="badge bg-light text-dark fs-6">Folio: <asp:Label ID="lblFolio" runat="server" Text="---"></asp:Label></span>
                    <span class="badge bg-info text-dark fs-6">ID Usuario: <asp:Label ID="lblIdUsuario" runat="server" Text="---"></asp:Label></span>
                    <span class="badge bg-warning text-dark fs-6">ID Animal: <asp:Label ID="lblIdAnimal" runat="server" Text="---"></asp:Label></span>
                </div>
            </div>

            <div class="row justify-content-center">
                <div class="col-lg-9 col-md-11">
                    <div class="card card-custom shadow-lg border-0">
                        <div class="card-body text-white p-5 rounded">

                            <h4 class="form-section-title"><i class="fa fa-user me-2"></i>1. Datos Personales</h4>
                            
                            <div class="row">
                                <div class="col-md-4">
                                    <span class="dato-label">Edad</span>
                                    <asp:Label ID="lblEdad" runat="server" CssClass="dato-valor"></asp:Label>
                                </div>
                                <div class="col-md-4">
                                    <span class="dato-label">Ocupación</span>
                                    <asp:Label ID="lblOcupacion" runat="server" CssClass="dato-valor"></asp:Label>
                                </div>
                                <div class="col-md-4">
                                    <span class="dato-label">Teléfono</span>
                                    <asp:Label ID="lblTelefono" runat="server" CssClass="dato-valor"></asp:Label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <span class="dato-label">Dirección Completa</span>
                                    <asp:Label ID="lblDireccion" runat="server" CssClass="dato-valor"></asp:Label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <span class="dato-label">Redes Sociales</span>
                                    <asp:Label ID="lblRedes" runat="server" CssClass="dato-valor"></asp:Label>
                                </div>
                            </div>


                            <h4 class="form-section-title"><i class="fa fa-home me-2"></i>2. Vivienda y Entorno</h4>

                            <div class="row">
                                <div class="col-md-4">
                                    <span class="dato-label">Tipo de Vivienda</span>
                                    <asp:Label ID="lblTipoVivienda" runat="server" CssClass="dato-valor"></asp:Label>
                                </div>
                                <div class="col-md-4">
                                    <span class="dato-label">Tenencia</span>
                                    <asp:Label ID="lblTenencia" runat="server" CssClass="dato-valor"></asp:Label>
                                </div>
                                <div class="col-md-4">
                                    <span class="dato-label">¿Permiten mascotas?</span>
                                    <asp:Label ID="lblPermisoDuenio" runat="server" CssClass="dato-valor"></asp:Label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <span class="dato-label">Seguridad (Patio/Ventanas)</span>
                                    <asp:Label ID="lblSeguridad" runat="server" CssClass="dato-valor"></asp:Label>
                                </div>
                            </div>


                            <h4 class="form-section-title"><i class="fa fa-users me-2"></i>3. Familia y Convivencia</h4>

                            <div class="row">
                                <div class="col-md-6">
                                    <span class="dato-label">Integrantes del hogar</span>
                                    <asp:Label ID="lblIntegrantes" runat="server" CssClass="dato-valor"></asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <span class="dato-label">¿Están de acuerdo?</span>
                                    <asp:Label ID="lblAcuerdo" runat="server" CssClass="dato-valor"></asp:Label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <span class="dato-label">¿Alergias?</span>
                                    <asp:Label ID="lblAlergias" runat="server" CssClass="dato-valor"></asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <span class="dato-label">Otras mascotas</span>
                                    <asp:Label ID="lblOtrasMascotas" runat="server" CssClass="dato-valor"></asp:Label>
                                </div>
                            </div>
                            
                            <div class="row">
                                <div class="col-md-12">
                                    <span class="dato-label">Sociabilidad con otros animales</span>
                                    <asp:Label ID="lblSociabilidad" runat="server" CssClass="dato-valor"></asp:Label>
                                </div>
                            </div>


                            <h4 class="form-section-title"><i class="fa fa-clock me-2"></i>4. Rutina y Compromiso</h4>

                            <div class="row">
                                <div class="col-md-6">
                                    <span class="dato-label">Tiempo solo al día</span>
                                    <asp:Label ID="lblHorasSolo" runat="server" CssClass="dato-valor"></asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <span class="dato-label">Lugar para dormir</span>
                                    <asp:Label ID="lblLugarDormir" runat="server" CssClass="dato-valor"></asp:Label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <span class="dato-label">Plan en caso de mudanza</span>
                                    <asp:Label ID="lblMudanza" runat="server" CssClass="dato-valor"></asp:Label>
                                </div>
                            </div>

                            <div class="row mt-2">
                                <div class="col-md-12">
                                    <span class="dato-label text-info">Motivo de adopción</span>
                                    <div class="p-3 border border-info rounded bg-dark bg-opacity-50">
                                        <asp:Label ID="lblMotivo" runat="server" Text="..."></asp:Label>
                                    </div>
                                </div>
                            </div>

                            <div class="mt-4 p-3 bg-secondary bg-opacity-10 rounded border border-secondary">
                                <div class="d-flex align-items-center mb-2">
                                    <asp:Label ID="lblIconoGastos" runat="server" CssClass="me-2 check-display"><i class="fa fa-check-circle"></i></asp:Label>
                                    <span class="text-white">Aceptó cubrir gastos veterinarios y alimentación.</span>
                                </div>
                                <div class="d-flex align-items-center">
                                    <asp:Label ID="lblIconoCompromiso" runat="server" CssClass="me-2 check-display"><i class="fa fa-check-circle"></i></asp:Label>
                                    <span class="text-white">Aceptó el compromiso de vida (10-15 años).</span>
                                </div>
                            </div>

                            <div class="row mt-5 pt-3 border-top border-secondary">
                                <div class="col-md-12 text-center">
                                    <p class="mb-3 text-muted">Acciones sobre la solicitud:</p>
                                    
                                    <asp:Button ID="btnAprobar" runat="server" Text="Aprobar Solicitud" 
                                        CssClass="btn btn-success btn-lg m-2 px-4 fw-bold" 
                                        OnClick="btnAprobar_Click" 
                                        OnClientClick="return confirm('¿Estás seguro de APROBAR esta solicitud?');" />

                                    <asp:Button ID="btnRechazar" runat="server" Text="Rechazar" 
                                        CssClass="btn btn-danger btn-lg m-2 px-4" 
                                        OnClick="btnRechazar_Click" 
                                        OnClientClick="return confirm('¿Estás seguro de RECHAZAR esta solicitud?');" />

                                    <asp:Button ID="btnPendiente" runat="server" Text="Marcar Pendiente" 
                                        CssClass="btn btn-warning btn-lg m-2 px-4 text-dark" 
                                        OnClick="btnPendiente_Click" />

                                    <asp:Button ID="btnCancelar" runat="server" Text="Volver" 
                                        CssClass="btn btn-outline-light btn-lg m-2 px-4" 
                                        OnClick="btnCancelar_Click" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
