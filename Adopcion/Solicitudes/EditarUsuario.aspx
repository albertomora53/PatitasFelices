<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarUsuario.aspx.cs" Inherits="Adopcion.EditarUsuario" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <title>Editar Usuario</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Iconos y fuentes -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500;700;900&display=swap" rel="stylesheet" />
    <!-- Estilos MDB -->
    <link href="css/bootstrap-login-form.min.css" rel="stylesheet" />
    <!-- Estilos personalizados -->
    <link href="../Content/Admin/style.css" rel="stylesheet" type="text/css" />
    <link href="../Content/Login/Login1.css" rel="stylesheet" type="text/css" />
    <link href="../Content/Login/Login2.css" rel="stylesheet" type="text/css" />
    <script src="../Content/Admin/script.js" type="text/javascript"></script>

    <style>
        body {
            margin: 0;
            font-family: 'Roboto', sans-serif;
        }
        .gradient-custom {
            background: linear-gradient(to right, #7fbce9, #1f4e79);
            min-height: 100vh;
        }
        .card-custom {
            background-color: rgba(0, 0, 0, 0.8);
            border-radius: 1rem;
            padding: 2rem;
            color: white;
        }
        .form-label {
            font-weight: 500;
            margin-bottom: 0.5rem;
        }
        .form-control-lg {
            border-radius: 2rem;
            padding: 1rem 1.5rem;
            font-size: 1.1rem;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
            border: none;
        }
        .btn-outline-light {
            border-radius: 2rem;
            padding: 0.75rem 2rem;
            font-weight: 500;
            transition: all 0.3s ease;
        }
    </style>
</head>
<body class="gradient-custom">
    <form id="form1" runat="server">
        <section class="vh-100">
            <div class="container py-5 h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                        <div class="card card-custom text-center">
                            <div class="mb-md-5 mt-md-4 pb-2">
                                <h2 class="fw-bold mb-4 text-uppercase">Actualizar información del usuario</h2>
                                

                                <!-- Campos del formulario -->
                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="lblUsername" runat="server" CssClass="form-label text-white" Text="Usuario" />
                                </div>

                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="LblPassword" runat="server" AssociatedControlID="txtPassword" CssClass="form-label text-white" Text="Contraseña nueva (opcional)" />
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control form-control-lg" placeholder="Nueva contraseña" />
                                </div>

                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="LblNombre" runat="server" AssociatedControlID="txtNombre" CssClass="form-label text-white" Text="Nombre" />
                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control form-control-lg" placeholder="Nombre" />
                                </div>

                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="LblApellidoPat" runat="server" AssociatedControlID="txtApellidoPat" CssClass="form-label text-white" Text="Apellido paterno" />
                                    <asp:TextBox ID="txtApellidoPat" runat="server" CssClass="form-control form-control-lg" placeholder="Apellido paterno" />
                                </div>

                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="LblApellidoMat" runat="server" AssociatedControlID="txtApellidoMat" CssClass="form-label text-white" Text="Apellido materno" />
                                    <asp:TextBox ID="txtApellidoMat" runat="server" CssClass="form-control form-control-lg" placeholder="Apellido materno" />
                                </div>

                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="LblTelefono" runat="server" AssociatedControlID="txtTelefono" CssClass="form-label text-white" Text="Teléfono" />
                                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control form-control-lg" placeholder="Teléfono" />
                                </div>

                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="LblCorreo" runat="server" AssociatedControlID="txtCorreo" CssClass="form-label text-white" Text="Correo" />
                                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control form-control-lg" placeholder="Correo" />
                                </div>

                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="LblRFC" runat="server" AssociatedControlID="txtRFC" CssClass="form-label text-white" Text="RFC" />
                                    <asp:TextBox ID="txtRFC" runat="server" CssClass="form-control form-control-lg" placeholder="RFC" />
                                </div>

                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="Label1" runat="server" AssociatedControlID="txtRef" CssClass="form-label text-white" Text="RFC" />
                                    <asp:TextBox ID="txtRef" runat="server" CssClass="form-control form-control-lg" placeholder="RFC" OnTextChanged="txtRef_TextChanged" />
                                </div>

                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="LblTipo" runat="server" AssociatedControlID="ddlTipo" CssClass="form-label text-white" Text="Tipo de usuario" />
                                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control form-control-lg">
                                        <asp:ListItem Text="Administrador" Value="1" />
                                        <asp:ListItem Text="Refugio" Value="2" />
                                        <asp:ListItem Text="Adoptante" Value="3" />
                                    </asp:DropDownList>
                                </div>

                                <!-- Botón y mensaje -->
                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" CssClass="btn btn-outline-light btn-lg px-5 mb-3" OnClick="btnGuardar_Click" />
                                <asp:Label ID="lblMensaje" runat="server" CssClass="text-success mt-2" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>