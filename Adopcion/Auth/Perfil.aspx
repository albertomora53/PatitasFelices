<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Adopcion.Perfil" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Patitas Felices - Mi Perfil</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../Content/CSS/bootstrap.css" rel="stylesheet" />
    <link href="../Content/CSS/bootstrap_icons.css" rel="stylesheet" />
    <link rel="icon" href="../Content/Proyecto_light.ico" type="image/x-icon" />
    <link href="../Content/CSS/personalisado.css" rel="stylesheet" />
    <link href="../Content/CSS/personalizado2.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    
    <style>
        .profile-card {
            border: none;
            border-radius: 15px;
            box-shadow: 0 4px 6px rgba(0,0,0,0.1);
            background-color: #ffffff;
        }
        .label-text {
            color: #6c757d; /* Gris suave para las etiquetas */
            font-size: 0.85rem;
            text-transform: uppercase;
            letter-spacing: 0.5px;
            margin-bottom: 5px;
        }
        .value-text {
            font-weight: 600;
            color: #212529; /* Negro para los datos */
            font-size: 1.2rem;
            padding-bottom: 10px;
            border-bottom: 1px solid #f0f0f0; /* Línea sutil debajo de cada dato */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <main>
            <div class="px-3 py-2 bg-dark text-white">
                <div class="container">
                    <header class="d-flex flex-wrap justify-content-center py-3 border-bottom">
                        <a class="d-flex align-items-center mb-3 mb-md-0 me-md-auto text-light text-decoration-none">
                            <img src="Content/Proyecto_light.ico" alt="Logo" width="40" height="40" class="me-2" />
                            <span class="fs-4">Patitas Felices</span>
                        </a>
                        <ul class="nav nav-pills">
                            <li class="nav-item"><a href="Index.aspx" class="nav-link text-white">Inicio</a></li>
                            <li class="nav-item"><a href="mascotas.aspx" class="nav-link text-white">Mascotas</a></li>
                            <li class="nav-item dropdown">
                                <a class="nav-link dropdown-toggle text-white d-flex align-items-center" href="#" id="navbarDropdownUser" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="bi bi-person-circle me-2"></i>
                                    <asp:Literal ID="litNombreUsuario" runat="server"></asp:Literal>
                                </a>
                                <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="navbarDropdownUser">
                                    <li><a class="dropdown-item" href="Perfil.aspx"><i class="bi bi-person"></i> Mi Perfil</a></li>
                                    <li><a class="dropdown-item" href="Misolicitudes.aspx"><i class="bi bi-file-earmark-text"></i> Solicitudes</a></li>
                                    <li><hr class="dropdown-divider"></li>
                                    <li>
                                        <asp:LinkButton ID="btnCerrarSesion" runat="server" CssClass="dropdown-item text-danger" OnClick="btnCerrarSesion_Click">
                                            <i class="bi bi-box-arrow-right"></i> Cerrar Sesión
                                        </asp:LinkButton>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </header>
                </div>
            </div>
            <div class="container mt-5 mb-5" style="max-width: 900px;">
                
                <h2 class="mb-4 fw-bold text-dark border-bottom pb-2">Información de Usuario</h2>

                <div class="card profile-card p-5">
                    
                    <div class="row g-5">
                        
                        <div class="row g-4"> <div class="col-md-4">
                            <div class="label-text">Nombre de Usuario (Username)</div>
                            <div class="value-text">
                                <asp:Label ID="lblUsername" runat="server" Text="..."></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="label-text">Tipo de Usuario</div>
                            <div class="value-text">
                                <asp:Label ID="lblTipoUsuario" runat="server" Text="..."></asp:Label>
                            </div>
                        </div>
                        

                        <div class="col-md-6">
                            <div class="label-text">Nombre(s)</div>
                            <div class="value-text">
                                <asp:Label ID="lblNombre" runat="server" Text="..."></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="label-text">Apellido Paterno </div>
                            <div class="value-text">
                                <asp:Label ID="lblApellidoPat" runat="server" Text="..."></asp:Label>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="label-text">Apellido Materno</div>
                            <div class="value-text">
                                <asp:Label ID="lblApellidoMat" runat="server" Text="..."></asp:Label>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="label-text">RFC</div>
                            <div class="value-text">
                                <asp:Label ID="lblRFC" runat="server" Text="..."></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="label-text">Número de Teléfono</div>
                            <div class="value-text">
                                <asp:Label ID="lblTelefono" runat="server" Text="..."></asp:Label>
                            </div>
                        </div>

                        <div class="col-12">
                            <div class="label-text">Correo Electrónico</div>
                            <div class="value-text border-0"> 
                                <asp:Label ID="lblCorreo" runat="server" Text="..."></asp:Label>
                            </div>
                        </div>

                    </div>

                    

                </div>
            </div>
            </div>

        </main>
    </form>
</body>
</html>