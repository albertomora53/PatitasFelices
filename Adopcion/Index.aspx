<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Adopcion.Index1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Patitas Felices</title>

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Content/CSS/bootstrap.css" rel="stylesheet" />
    <link href="Content/CSS/bootstrap_icons.css" rel="stylesheet" />
    <link rel="icon" href="Content/Proyecto_light.ico" type="image/x-icon" />
    <link href="Content/CSS/personalisado.css" rel="stylesheet" />
    <link href="Content/CSS/personalizado2.css" rel="stylesheet" />
    <link href="Content/CSS/carrucel.css" rel="stylesheet" />
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
                        <li class="nav-item"><a href="#contacto" class="nav-link text-white">Contacto</a></li>

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

    <section class="hero-block">
        <div class="hero-content">
            <h1 class="fw-bold">Amor Incondicional</h1>
            <p>Encuentra tu compañero fiel, dale un hogar lleno de alegría.</p>
            <a href="#mascotas" class="btn-ver">Ver Mascotas</a>
        </div>
    </section>

    <section id="mascotas" class="seccion-contacto py-5">        
        <div class="container-fluid px-4 px-lg-5"> 
            <div class="text-center mb-2">
                <h2 class="titulo-contacto">Conoce a nuestros amigos</h2>      
            </div>
            
            <div class="contenedor-carrusel">
                <div class="swiper mySwiper">
                    <div class="swiper-wrapper">
                        <asp:Repeater ID="RepMascotas" runat="server">
                            <ItemTemplate>
                                <div class="swiper-slide">
                                    <div class="card shadow-sm pet-card" style="border-radius: 15px; overflow: hidden; border:none; margin: 0 10px;">
                                        <div class="position-relative">
                                            <img src='<%# ResolveUrl("~/Imagenes/Animales/" + Eval("Imagen"))%>' class="card-img-top" alt="Mascota">
                                            <span class="position-absolute top-0 end-0 m-2 badge bg-light text-dark shadow-sm">
                                                <%# Eval("Especie") %>
                                            </span>
                                        </div>
                                        <div class="card-body">
                                            <h4 class="fw-bold"><%# Eval("Nombre") %></h4>
                                            <p class="card-text text-muted small"><%# Eval("Descripcion") %></p>
                                            <div class="d-grid mt-3">
                                                <a href="Mascotas.aspx" class="btn btn-primary rounded-pill">Ver perfil</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    
                    <div class="swiper-button-next"></div>
                    <div class="swiper-button-prev"></div>
                    <div class="swiper-pagination"></div>
                </div>
            </div>
        </div>
    </section>

    <section class="seccion-pasos">
    <div class="container text-center">
        <h2 class="fw-bold mb-2" style="font-size: 2.5rem;">¿Cómo adoptar?</h2>
        <p class="mb-5 text-muted" style="font-size: 1.2rem;">Es un proceso sencillo diseñado para encontrar el mejor hogar</p>

        <div class="row g-4">
            <div class="col-md-4">
                <div class="paso-card text-start">
                    <div class="paso-icono">💖</div>
                    <span class="paso-numero">Paso 01</span>
                    <h3 class="paso-titulo">Elige tu mascota</h3>
                    <p class="paso-texto">Explora nuestros amigos peludos y encuentra al que más conecte contigo.</p>
                </div>
            </div>
            <div class="col-md-4">
                <div class="paso-card text-start">
                    <div class="paso-icono">📝</div>
                    <span class="paso-numero">Paso 02</span>
                    <h3 class="paso-titulo">Completa el formulario</h3>
                    <p class="paso-texto">Cuéntanos sobre ti y tu hogar para asegurar una adopción responsable.</p>
                </div>
            </div>
            <div class="col-md-4">
                <div class="paso-card text-start">
                    <div class="paso-icono">🏠</div>
                    <span class="paso-numero">Paso 03</span>
                    <h3 class="paso-titulo">¡Bienvenido a casa!</h3>
                    <p class="paso-texto">Coordinaremos la entrega y el inicio de una hermosa amistad.</p>
                </div>
            </div>
        </div>
    </div>
</section>

<section class="seccion-pasos" style="background-color: #111827; border-top: 1px solid #1e293b;">
    <div class="container text-center">
        <h2 class="fw-bold mb-2" style="font-size: 2.5rem;">¿Cómo dar en adopción?</h2>
        <p class="mb-5 text-muted" style="font-size: 1.2rem;">Ayúdanos a encontrarle una nueva familia a un peludito</p>

        <div class="row g-4">
            <div class="col-md-4">
                <div class="paso-card text-start">
                    <div class="paso-icono">📄</div>
                    <span class="paso-numero">Paso 01</span>
                    <h3 class="paso-titulo">Registra los datos</h3>
                    <p class="paso-texto">Sube fotos y cuéntanos la historia, salud y carácter de la mascota.</p>
                </div>
            </div>
            <div class="col-md-4">
                <div class="paso-card text-start">
                    <div class="paso-icono">🔍</div>
                    <span class="paso-numero">Paso 02</span>
                    <h3 class="paso-titulo">Revisión de solicitudes</h3>
                    <p class="paso-texto">Analizaremos a los candidatos interesados para ver si son aptos.</p>
                </div>
            </div>
            <div class="col-md-4">
                <div class="paso-card text-start">
                    <div class="paso-icono">🤝</div>
                    <span class="paso-numero">Paso 03</span>
                    <h3 class="paso-titulo">Entrevista y entrega</h3>
                    <p class="paso-texto">Conoce a la nueva familia y realiza el proceso de entrega segura.</p>
                </div>
            </div>
        </div>
    </div>
</section>

 <section id="contacto" class="seccion-contacto">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-8 text-center">
                <h2 class="titulo-contacto">Contáctanos</h2>
                
                <div class="form-contacto">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre" OnTextChanged="txtNombre_TextChanged"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Correo" TextMode="Email"></asp:TextBox>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-12">
                            <asp:TextBox ID="txtMensaje" runat="server" CssClass="form-control" placeholder="Mensaje" TextMode="MultiLine" Rows="4" OnTextChanged="txtMensaje_TextChanged"></asp:TextBox>
                        </div>
                    </div>

                    <div class="mt-4">
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn-enviar" OnClick="btnEnviar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

<footer class="py-4 text-center text-muted" style="background-color: #090C11">
    <hr class="container" />
    <p>&copy; 2025 Patitas Felices. Todos los derechos reservados.</p>
</footer>

</main>
</form> 
   <script src="https://cdn.jsdelivr.net/npm/swiper@11/swiper-bundle.min.js"></script>
    <script src="Content/JS/Personalizados.js"></script>
</body>
</html>
