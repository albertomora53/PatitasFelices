<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_solicitudes.aspx.cs" Inherits="Adopcion.Admin_solicitudes" %>


<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <title>Panel de administración</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500;700;900&display=swap" rel="stylesheet" />
    <link href="../Content/Login/Login1.css" rel="stylesheet" />
    <link href="../Content/Admin/style.css" rel="stylesheet" type="text/css" />
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
        .w3-sidebar {
            width: 250px;
            position: fixed;
            height: 100%;
        }
        .main-content {
            margin-left: 250px;
            padding: 40px;
            color: white;
        }
        .card-custom {
            background-color: rgba(0, 0, 0, 0.7);
            border-radius: 1rem;
            padding: 2rem;
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
        <!-- Barra lateral fija -->
        <div class="w3-sidebar w3-bar-block w3-light-grey w3-card">
            <a href="#" class="w3-bar-item w3-button"><h2>Admin</h2></a>
            <asp:LinkButton ID="btnusuarios" runat="server" CssClass="w3-bar-item w3-button" OnClick="btnusuarios_Click">
                Usuarios
            </asp:LinkButton>
            <asp:LinkButton ID="btnanimales" runat="server" CssClass="w3-bar-item w3-button" OnClick="btnanimales_Click">
                Animales
            </asp:LinkButton>
            <asp:LinkButton ID="btnsolicitud" runat="server" CssClass="w3-bar-item w3-button" OnClick="btnsolicitud_Click">
                Solicitudes
            </asp:LinkButton>
            <asp:LinkButton ID="btnrefugios" runat="server" CssClass="w3-bar-item w3-button" OnClick="btnrefugios_Click">
                Refugios
            </asp:LinkButton>
            <asp:LinkButton ID="btnCerrarSesion" runat="server" CssClass="w3-bar-item w3-button" OnClick="LinkCerrarSesion_Click">
                Cerrar sesión
            </asp:LinkButton>
        </div>

        <!-- Contenido principal -->
        <div class="main-content">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-md-10">
                        <div class="text-center text-white">
                            <h2 class="fw-bold mb-4 text-uppercase">Gestion de solicitudes</h2>

                            <!-- Buscador -->
                            <div class="form-group mb-4">
                                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control form-control-lg" placeholder="Buscar usuario" />
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-outline-light btn-lg px-4" OnClick="btnBuscar_Click" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnAgregar" runat="server" Text="Agregar Solcitud" CssClass="btn btn-outline-light btn-lg px-4" OnClick="btnAgregar_Click" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblMensaje" runat="server"></asp:Label> 
                            </div>

                            <!-- Tabla dinámica -->
                           <h2 class="fw-bold mb-4 text-uppercase">Lista de solicitudes</h2>
                                <div class="table-responsive mb-4 rounded-4 overflow-hidden border border-secondary">
                                <asp:GridView ID="gvSolicitudes" runat="server" AutoGenerateColumns="False"
                                    CssClass="table table-dark text-center mx-auto mb-0"
                                    HeaderStyle-CssClass="bg-dark text-white"
                                    RowStyle-CssClass="bg-light text-dark"
                                    EmptyDataText="No se encontraron Solicitudes." OnSelectedIndexChanged="gvSolicitudes_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="Id_Solicitud" HeaderText="Id Solicitud" />
                                        <asp:BoundField DataField="Id_Usuario" HeaderText="Id Usuario" />                                  
                                        <asp:BoundField DataField="Id_Animal" HeaderText="Id Animal" />
                                        <asp:BoundField DataField="Situacion" HeaderText="Situacion" />
                                        <asp:BoundField DataField="Folio" HeaderText="Folio" />
                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha de registro" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
                                        <asp:TemplateField HeaderText="Acciones">

                                            <ItemTemplate>

                                                <a href='<%# Eval("Id_Solicitud", "Versolicitud.aspx?id={0}") %>' class="btn btn-sm btn-outline-info me-2" title="Ver detalles">
                                                    <i class="fa fa-eye"></i>
                                                </a>

                                                
                                                <asp:LinkButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("Id_Solicitud") %>'
                                                    OnClick="btnEliminar_Click" CssClass="btn btn-sm btn-outline-danger"
                                                    OnClientClick="return confirm('¿Estás seguro de que deseas eliminar esta Solicitud?');" ToolTip="Eliminar">
                                                    <i class="fa fa-trash"></i>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                          </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

