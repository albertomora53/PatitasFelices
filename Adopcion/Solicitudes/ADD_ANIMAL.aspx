<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADD_ANIMAL.aspx.cs" Inherits="Adopcion.WebForm1" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <title>Agregar Animal</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500;700;900&display=swap" rel="stylesheet" />
    <link href="../css/bootstrap-login-form.min.css" rel="stylesheet" />
    <link href="../Content/Admin/style.css" rel="stylesheet" type="text/css" />
    <link href="../Content/Login/Login1.css" rel="stylesheet" type="text/css" />
    <link href="../Content/Login/Login2.css" rel="stylesheet" type="text/css" />
    <script src="../Content/Admin/script.js"></script>

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
                                <h2 class="fw-bold mb-4 text-uppercase">Agregar Animal</h2>

                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="lblNombreAnimal" runat="server" AssociatedControlID="txtNombreAnimal" CssClass="form-label text-white" Text="Nombre del Animal" />
                                    <asp:TextBox ID="txtNombreAnimal" runat="server" CssClass="form-control form-control-lg" placeholder="Nombre" OnTextChanged="txtNombreAnimal_TextChanged" />
                                </div>

                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="lblEspecie" runat="server" AssociatedControlID="ddlEspecie" CssClass="form-label text-white" Text="Especie" />
                                    <asp:DropDownList ID="ddlEspecie" runat="server" CssClass="form-control form-control-lg" OnSelectedIndexChanged="ddlEspecie_SelectedIndexChanged">
                                        <asp:ListItem Text="Perro" Value="Perro" />
                                        <asp:ListItem Text="Gato" Value="Gato" />
                                        <asp:ListItem Text="Otro" Value="Otro" />
                                    </asp:DropDownList>
                                </div>
                                
                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="lblIdRefugio" runat="server" AssociatedControlID="txtIdRefugio" CssClass="form-label text-white" Text="ID de Refugio" />
                                    <asp:TextBox ID="txtIdRefugio" runat="server" CssClass="form-control form-control-lg" placeholder="Ej: 15" TextMode="Number" OnTextChanged="txtIdRefugio_TextChanged" />
                                </div>

                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="lblGenero" runat="server" AssociatedControlID="ddlGenero" CssClass="form-label text-white" Text="Género" />
                                    <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-control form-control-lg">
                                        <asp:ListItem Text="Macho" Value="Macho" />
                                        <asp:ListItem Text="Hembra" Value="Hembra" />
                                    </asp:DropDownList>
                                </div>
                                
                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="LblTamano" runat="server" AssociatedControlID="ddlTamano" CssClass="form-label text-white" Text="Tamaño" />
                                    <asp:DropDownList ID="ddlTamano" runat="server" CssClass="form-control form-control-lg">
                                        <asp:ListItem Text="Pequeño (hasta 10 kg)" Value="Pequeño" />
                                        <asp:ListItem Text="Mediano (10 a 25 kg)" Value="Mediano" />
                                        <asp:ListItem Text="Grande (25 a 40 kg)" Value="Grande" />
                                        <asp:ListItem Text="Gidante (mas de 40 kg)" Value="Gigante" />
                                    </asp:DropDownList>
                                </div>

                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="Lblpersonalidad" runat="server" AssociatedControlID="ddlPersonalidad" CssClass="form-label text-white" Text="Personalidad" />
                                    <asp:DropDownList ID="ddlPersonalidad" runat="server" CssClass="form-control form-control-lg" >
                                        <asp:ListItem Text="Timido" Value="Timido" />
                                        <asp:ListItem Text="Imperactivo" Value="Imperactivo" />
                                        <asp:ListItem Text="Tranquilo" Value="Jugeton" />
                                        <asp:ListItem Text="Jugeton" Value="Jugeton" />
                                    </asp:DropDownList>
                                </div>                               
                                
                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="Lbledad1" runat="server" AssociatedControlID="ddledad" CssClass="form-label text-white" Text="Edad" />
                                    <asp:DropDownList ID="ddledad" runat="server" CssClass="form-control form-control-lg">
                                        <asp:ListItem Text="Cachorro" Value="Cachoro" />
                                        <asp:ListItem Text="Joven" Value="Joven" />
                                        <asp:ListItem Text="Adulto" Value="Adulto" />  
                                    </asp:DropDownList>
                                </div>

                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="lblDescripcion" runat="server" AssociatedControlID="txtDescripcion" CssClass="form-label text-white" Text="Descripción" />
                                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control form-control-lg" placeholder="Breve descripción del animal" TextMode="MultiLine" Rows="3" />
                                </div>
                                
                        

                                <div class="form-outline form-white mb-4 text-start">
                                    <asp:Label ID="lblImagen" runat="server" AssociatedControlID="fileImagen" CssClass="form-label text-white" Text="Seleccionar Foto" />
                                    <asp:FileUpload ID="fileImagen" runat="server" CssClass="form-control form-control-lg" />
                                </div>


                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                <br />
                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar Animal" CssClass="btn btn-outline-light btn-lg px-5 mb-3" OnClick="btnGuardar_Click"/>
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
