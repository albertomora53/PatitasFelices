<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Misolicitudes.aspx.cs" Inherits="Adopcion.Misolicitudes" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Patitas Felices</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../Content/CSS/bootstrap.css" rel="stylesheet" />
    <link href="../Content/CSS/bootstrap_icons.css" rel="stylesheet" />
    <link rel="icon" href="../Content/Proyecto_light.ico" type="image/x-icon" />
    <link href="../Content/CSS/personalisado.css" rel="stylesheet" />
    <link href="../Content/CSS/personalizado2.css" rel="stylesheet" />
    <link href="../Content/CSS/carrucel.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    
    
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

            <div class="container mt-5" style="max-width: 800px;">

    <div class="mb-4 text-dark text-center p-4 border-0">
        <h1 class="fw-bold mb-2">Historial de solicitudes</h1>
    </div>

    <asp:Panel ID="pnlNoDatos" runat="server" Visible="false">
        <div class="alert alert-warning text-center">
            No has realizado ninguna solicitud de adopción todavía.
        </div>
    </asp:Panel>

    <asp:Repeater ID="rptSolicitudes" runat="server">
        <ItemTemplate>
            
            <div class="card mb-5 shadow border-0"> <div class="card-body">
                    
                    <h2 class="mb-3 fw-bold">
                        Solicitud #<%# Eval("Id_Solicitud") %>
                    </h2>

                    <div class="progress mb-4" style="height: 10px;">
                        <div class="progress-bar" role="progressbar" 
                             style='<%# ObtenerEstiloBarra(Eval("Situacion").ToString()) %>'>
                        </div>
                    </div>              

                    <div class="card mb-4 text-white text-center p-4 border-0" 
                         style='<%# "border-radius: 10px; background-color: " + ObtenerColorEstado(Eval("Situacion").ToString()) %>'>
                        <h2 class="fw-bold mb-2">
                            <i class="bi bi-clock"></i> ESTADO: <%# Eval("Situacion") %>
                        </h2>
                        <p class="mb-0 fs-5">
                            <%# ObtenerMensajeDescripcion(Eval("Situacion").ToString()) %>
                        </p>
                    </div>

                    <div class="card border-0 shadow-sm">
                        <div class="card-header fw-bold py-3" style="background-color: #e9ecef;">
                            Detalles de la Solicitud
                        </div>
                        <div class="card-body p-0">
                            <table class="table table-hover mb-0">
                                <tbody>
                                    <tr>
                                        <td class="ps-4 py-3 fw-semibold text-secondary">Fecha de Solicitud:</td>
                                        <td class="pe-4 py-3 text-end">
                                            <%# Eval("Fecha") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="ps-4 py-3 fw-semibold text-secondary">ID Mascota:</td>
                                        <td class="pe-4 py-3 text-end">
                                            <%# Eval("Id_Animal") %> 
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="ps-4 py-3 fw-semibold text-secondary">Folio:</td>
                                        <td class="pe-4 py-3 text-end">
                                            <%# Eval("Folio") %> 
                                            </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>

                </div>
            </div>

        </ItemTemplate>
    </asp:Repeater>

    <div class="mt-4 text-end">
        <a href="Index.aspx" class="btn btn-outline-secondary">Volver al Inicio</a>
    </div>



            </div>
        </main>
    </form>
</body>
</html>
