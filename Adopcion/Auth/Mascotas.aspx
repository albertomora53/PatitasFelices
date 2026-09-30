<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mascotas.aspx.cs" Inherits="Adopcion.Mascotas" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Patitas Felices</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../Content/CSS/bootstrap.css" rel="stylesheet" />
    <link href="../Content/CSS/bootstrap_icons.css" rel="stylesheet" />
    <link rel="icon" href="../Content/Proyecto_light.ico" type="image/x-icon" />
    <link href="../Content/CSS/personalizado2.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    
    <style>
        .hero-block {
            background-image: linear-gradient(rgba(0, 0, 0, 0.4), rgba(0, 0, 0, 0.4)), url('Content/Imagenes/Animals.png');
            background-size: cover;
            background-position: center;
            height: 80vh;
            width: 100%;
            display: flex;
            align-items: center;
            justify-content: center;
            color: white;
            text-align: center;
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
                    <li class="nav-item"><a href="Index.aspx#contacto" class="nav-link text-white">Contacto</a></li>

                    <asp:PlaceHolder ID="phAnonimo" runat="server">
                        <li class="nav-item">
                            <a href="Login.aspx" class="nav-link active">Acceder</a>
                        </li>
                    </asp:PlaceHolder>

                    <asp:PlaceHolder ID="phLogueado" runat="server" Visible="false">
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle text-white d-flex align-items-center" href="#" id="navbarDropdownUser" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                <i class="bi bi-person-circle me-2"></i>
                                <asp:Literal ID="litNombreUsuario" runat="server"></asp:Literal>
                            </a>

                            <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="navbarDropdownUser">
            
                                <li>
                                    <a class="dropdown-item" href="Perfil.aspx">
                                        <i class="bi bi-person"></i> Mi Perfil
                                    </a>
                                </li>
            
                                <li>
                                    <a class="dropdown-item" href="Misolicitudes.aspx">
                                        <i class="bi bi-file-earmark-text"></i> Solicitudes
                                    </a>
                                </li>

                                <asp:PlaceHolder ID="phRefugio" runat="server" Visible="false">
                                    <li>
                                        <a class="dropdown-item" href="Mirefugio.aspx">
                                            <i class="bi bi-house-heart"></i> Mi Refugio
                                        </a>
                                    </li>
                                </asp:PlaceHolder>

                                <li><hr class="dropdown-divider"></li>

                                <li>
                                    <asp:LinkButton ID="btnCerrarSesion" runat="server" 
                                        CssClass="dropdown-item text-danger" 
                                        OnClick="btnCerrarSesion_Click">
                                        <i class="bi bi-box-arrow-right"></i> Cerrar Sesión
                                    </asp:LinkButton>
                                </li>
                            </ul>
                        </li>
                    </asp:PlaceHolder>
                </ul>
            </header>
        </div>
    </div>

    <section class="bg-light py-5">
    <div class="container">
        <div class="text-center mb-5">
            <h1 class="fw-bold display-5">Mascotas en Adopción</h1>
            <p class="text-muted">Cada uno de ellos tiene una historia y un corazón lleno de amor esperando por ti</p>
        </div>

        <div class="filters-container d-flex flex-wrap align-items-center justify-content-center mb-5">
    
                    <asp:LinkButton ID="btnFiltroTodos" runat="server" CssClass="filter-pill active" OnClick="BtnFiltroEspecie_Click" CommandArgument="Todos">
                        <i class="bi bi-stars me-1"></i> Todos
                    </asp:LinkButton>

                    <asp:LinkButton ID="btnFiltroPerros" runat="server" CssClass="filter-pill" OnClick="BtnFiltroEspecie_Click" CommandArgument="Perro">
                        <i class="bi bi-dog me-1"></i> Perros
                    </asp:LinkButton>

                    <asp:LinkButton ID="btnFiltroGatos" runat="server" CssClass="filter-pill" OnClick="BtnFiltroEspecie_Click" CommandArgument="Gato">
                        <i class="bi bi-cat me-1"></i> Gatos
                    </asp:LinkButton>
    
                    <asp:DropDownList ID="ddlEdad" runat="server" CssClass="form-select w-auto filter-pill ms-2" AutoPostBack="true" OnSelectedIndexChanged="FiltrosCombinados_Event">
                        <asp:ListItem Text="Todas las edades" Value="Todos" />
                        <asp:ListItem Text="Cachorro" Value="Cachoro" />
                        <asp:ListItem Text="Joven" Value="Joven" />
                        <asp:ListItem Text="Adulto" Value="Adulto" />
                    </asp:DropDownList>

                    <asp:DropDownList ID="ddlTamano" runat="server" CssClass="form-select w-auto filter-pill ms-2" AutoPostBack="true" OnSelectedIndexChanged="FiltrosCombinados_Event">
                        <asp:ListItem Text="Todos los tamaños" Value="Todos" />
                        <asp:ListItem Text="Pequeño" Value="Pequeño" />
                        <asp:ListItem Text="Mediano" Value="Mediano" />
                        <asp:ListItem Text="Grande" Value="Grande" />
                        <asp:ListItem Text="Gigante" Value="Gigante" />
                    </asp:DropDownList>
                    
                    <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-select w-auto filter-pill ms-2" AutoPostBack="true" OnSelectedIndexChanged="FiltrosCombinados_Event">
                        <asp:ListItem Text="Todos los sexos" Value="Todos" />
                        <asp:ListItem Text="Macho" Value="macho" />
                        <asp:ListItem Text="Hembra" Value="hembra" />
                    </asp:DropDownList>

                </div>

        <div class="row g-4">
            <asp:Repeater ID="RepMascotasPage" runat="server">
                <ItemTemplate>
                    <div class="col-md-3">
                        <div class="pet-card">
                            <div class="pet-img-container">
                                <img src='<%# ResolveUrl("~/Imagenes/Animales/" + Eval("Imagen")) %>' class="pet-img" alt="Mascota">
                                <span class="badge-type">
                                    <i class="bi bi-tag-fill me-1 text-warning"></i> <%# Eval("Especie") %>
                                </span>
                 
                            </div>
                            <div class="card-body p-4">
                                <h4 class="fw-bold mb-1"><%# Eval("Nombre") %></h4>
                                <p class="text-muted small mb-3"><%# Eval("Especie") %></p>
                                
                                <div class="mb-3">
                                    <span class="tag-status"><%# Eval("Edad") %></span>
                                    <span class="tag-status"><%# Eval("Genero") %></span>
                                    <span class="tag-status"><%# Eval("Tamano") %></span>
                                    <span class="tag-status"><%# Eval("Personalidad") %></span>
                                </div>

                                <div class="mb-3">
                                    <span class="tag-health text-success me-3">✓ Vacunado</span>
                                    <span class="tag-health text-info">✓ Esterilizado</span>
                                </div>

                                <p class="text-secondary small line-clamp-2">
                                    <%# Eval("Descripcion") %>
                                </p>

                                <asp:LinkButton ID="btnAdoptar" runat="server" 
                                    CssClass="btn btn-adopt" 
                                    CommandName="Adoptar" 
                                    CommandArgument='<%# Eval("Id_Animal") %>'
                                    OnCommand="btnAdoptar_Command">
                                    Quiero Adoptarlo
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</section>

</main>

</form> </body>
</html>