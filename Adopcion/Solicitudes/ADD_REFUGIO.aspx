<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADD_REFUGIO.aspx.cs" Inherits="Adopcion.ADD_REFUGIO" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <title>Agregar Usuario</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Iconos y fuentes -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500;700;900&display=swap" rel="stylesheet" />
    <!-- Estilos MDB -->
    <link href="css/bootstrap-login-form.min.css" rel="stylesheet" />
    <!-- Estilo personalizado -->
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

        .form-label {
            font-weight: 500;
            margin-bottom: 0.5rem;
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
                                <h2 class="fw-bold mb-4 text-uppercase">Agregar Refugio</h2>

                                <!-- Campos del formulario -->

                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="lblNombre" runat="server" AssociatedControlID="txtNombre" CssClass="form-label text-white" Text="Nombre" />
                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control form-control-lg" placeholder="Nombre" />
                                </div>

                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="LblDirrecion" runat="server" AssociatedControlID="txtDireccion1" CssClass="form-label text-white" Text="Direccion" />
                                    <asp:TextBox ID="txtDireccion1" runat="server" CssClass="form-control form-control-lg" placeholder="Direccion" />
                                </div>

                                <div class="form-outline form-white mb-4 text-start">
                                <asp:Label ID="Label3" runat="server" AssociatedControlID="txtRef" CssClass="form-label text-white" Text="Direccion" />
                                <asp:TextBox ID="TxtRef" runat="server" CssClass="form-control form-control-lg" placeholder="Direccion" OnTextChanged="TxtRef_TextChanged" />
                            </div>

                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="LblEstado" runat="server" AssociatedControlID="ddlEstado" CssClass="form-label text-white" Text="Estatus" />
                                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control form-control-lg">
                                        <asp:ListItem Text="Pendiente" Value="pendiente" />
                                        <asp:ListItem Text="Aprobado" Value="aprobado" />
                                        <asp:ListItem Text="Rechazado" Value="rechazado" />
                                    </asp:DropDownList>
                                </div>

                                <!-- Botón y mensaje -->
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                <br />
                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" CssClass="btn btn-outline-light btn-lg px-5 mb-3" OnClick="btnGuardar_Click"/>
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

