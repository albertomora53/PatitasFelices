<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mirefugio.aspx.cs" Inherits="Adopcion.Mirefugio" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Patitas Felices - Mi Refugio</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../Content/CSS/bootstrap.css" rel="stylesheet" />
    <link href="../Content/CSS/bootstrap_icons.css" rel="stylesheet" />
    <link rel="icon" href="Content/Proyecto_light.ico" type="image/x-icon" />
    <link href="../Content/CSS/personalisado.css" rel="stylesheet" />
    <link href="../Content/CSS/personalizado2.css" rel="stylesheet" />
    <link href="../Content/CSS/carrucel.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    
    <style>
        .pet-card {
            border: 1px solid #e0e0e0;
            border-radius: 12px;
            overflow: hidden;
            background: #fff;
            transition: transform 0.2s;
            height: 100%; /* Para que todas midan lo mismo */
            display: flex;
            flex-direction: column;
        }
        .pet-card:hover {
            transform: translateY(-5px);
            box-shadow: 0 10px 20px rgba(0,0,0,0.1);
        }
        .pet-img-container {
            height: 200px;
            overflow: hidden;
            position: relative;
        }
        .pet-img {
            width: 100%;
            height: 100%;
            object-fit: cover;
        }
        .badge-type {
            position: absolute;
            top: 10px;
            right: 10px;
            background: rgba(255,255,255,0.9);
            padding: 5px 10px;
            border-radius: 20px;
            font-size: 0.8rem;
            font-weight: bold;
        }
        .tag-status {
            background: #f8f9fa;
            padding: 2px 8px;
            border-radius: 4px;
            font-size: 0.75rem;
            margin-right: 5px;
            border: 1px solid #dee2e6;
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

            <div class="container mt-5">

                <div class="d-flex justify-content-between align-items-center mb-4 p-4 bg-light rounded shadow-sm">
                    <h1 class="fw-bold mb-0">Mis Animales en Adopción</h1>
                    
                    <a href="RegistroMascota.aspx" class="btn btn-success btn-lg">
                        <i class="bi bi-plus-circle-fill me-2"></i> Agregar Mascota
                    </a>
                </div>

                <asp:Panel ID="pnlNoDatos" runat="server" Visible="false">
                    <div class="alert alert-warning text-center">
                        No has publicado ningún animal en adopción todavía. ¡Empieza agregando uno!
                    </div>
                </asp:Panel>

                <div class="row g-4">
                    <asp:Repeater ID="RepMascotasPage" runat="server">
                        <ItemTemplate>
                            <div class="col-12 col-md-6 col-lg-3">
                                <div class="pet-card shadow-sm">
                                    
                                    <div class="pet-img-container">
                                        <img src='<%# ResolveUrl("~/Imagenes/Animales/" + Eval("Imagen")) %>' class="pet-img" alt="Mascota">
                                        <span class="">
                                 
                                        </span>
                                    </div>

                                    <div class="card-body p-3 d-flex flex-column">
                                        <h4 class="fw-bold mb-1"><%# Eval("Nombre") %></h4>
                                        <p class="text-muted small mb-2"><%# Eval("Especie") %></p>
                                        
                                        <div class="mb-3">
                                            <span class="tag-status"><%# Eval("Edad") %></span>
                                            <span class="tag-status"><%# Eval("Genero") %></span>
                                            <span class="tag-status"><%# Eval("Tamano") %></span>
                                        </div>

                                        <p class="text-secondary small mb-3 flex-grow-1">
                                            <%# Eval("Descripcion") %>
                                        </p>

                                        <div class="d-grid gap-2 mt-auto">
                                            <a href='Editar_Animal.aspx?id=<%# Eval("Id_Animal") %>' class="btn btn-outline-primary btn-sm">
                                                <i class="bi bi-pencil-square"></i> Editar
                                            </a>

                                            <asp:LinkButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("Id_Animal") %>'
                                                OnClick="btnEliminar_Click" CssClass="btn btn-sm btn-outline-danger"
                                                OnClientClick="return confirm('¿Estás seguro de que deseas eliminar este Animal?');" ToolTip="Eliminar">                                        
                                                 <i class=""></i> Eliminar
                                              </asp:LinkButton>
                                          
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div> <div class="mt-5 text-end">
                    <a href="Index.aspx" class="btn btn-secondary">Volver al Inicio</a>
                </div>

            </div>
        </main>
    </form>
</body>
</html>
