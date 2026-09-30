<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Adopcion.Log" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />

    <title>Login</title>

    <link href="Content/Login/Login1.css" rel="stylesheet" type="text/css" />
    <link href="Content/Login/Login2.css" rel="stylesheet" type="text/css" />

    <style>
        .gradient-custom {
                background: linear-gradient(to right, #7fbce9, #1f4e79);
            }
    </style>
  </head>

    <body class="gradient-custom">
    <form id="form1" runat="server">
        <section class="vh-100">
            <div class="container py-5 h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                        <div class="card bg-dark text-white" style="border-radius: 1rem;">
                            <div class="card-body p-5 text-center">

                                <div class="mb-md-5 mt-md-4 pb-5">
                                    <h2 class="fw-bold mb-2 text-uppercase">Inicio de sesión</h2>

                                    <div class="form-outline form-white mb-4">
                                        <asp:Label ID="Lbl_User" runat="server" AssociatedControlID="Txt_user" CssClass="form-label text-white" Text="Usuario" />
                                        <asp:TextBox ID="Txt_user" runat="server" CssClass="form-control form-control-lg"  />
                                        
                                    </div>

                                    <div class="form-outline form-white mb-4">
                                        <asp:Label ID="Lbl_password" runat="server" AssociatedControlID="Txt_password" CssClass="form-label text-white" Text="Contraseña" />
                                        <asp:TextBox ID="Txt_password" runat="server" TextMode="Password" CssClass="form-control form-control-lg" />
                                        
                                    </div>
                                     <br />
                                        <asp:Button ID="Btn_INICIO" runat="server" CssClass="btn btn-outline-light btn-lg px-5" Text="Iniciar sesión" OnClick="Btn_INICIO_Click" />
                                        <br /> 
                                        <br />
                                    <p class="mb-0">¿No tienes cuenta?
                                        <asp:LinkButton ID="link_registro" runat="server" CssClass="text-white-50 fw-bold" OnClick="link_registro_Click">Regístrate</asp:LinkButton>
                                    </p>
                                        <asp:Label ID="Label2" runat="server" CssClass="text-danger mt-3" />
                                </div>
                                        
                                <div>
                                    
                                </div>

                                

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>

