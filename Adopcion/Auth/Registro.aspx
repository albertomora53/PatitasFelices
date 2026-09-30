<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Adopcion.Registro" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Registro</title>

    <!-- Tus estilos personalizados -->
    <link href="../Content/Login/Login1.css" rel="stylesheet" type="text/css" />
    <link href="../Content/Login/Login2.css" rel="stylesheet" type="text/css" />

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
                    <div class="col-12 col-md-10 col-lg-8 col-xl-7">
                        <div class="card bg-dark text-white" style="border-radius: 1rem;">
                            <div class="card-body p-5">
                                <h2 class="fw-bold mb-4 text-uppercase text-center">Registro</h2>

                                <div class="form-outline form-white mb-3">
                                    <asp:Label ID="Lbl_usuario" runat="server" AssociatedControlID="Txt_nameuser" CssClass="form-label text-white" Text="Nombre de usuario" />
                                    <asp:TextBox ID="Txt_nameuser" runat="server" CssClass="form-control form-control-lg" />
                                    
                                </div>

                                <div class="form-outline form-white mb-3">
                                    <asp:Label ID="Lbl_intpassword" runat="server" AssociatedControlID="Txt_password" CssClass="form-label text-white" Text="Contraseña" />
                                    <asp:TextBox ID="Txt_password" runat="server" TextMode="Password" CssClass="form-control form-control-lg"  />
                                    
                                </div>

                                <div class="form-outline form-white mb-3">
                                    <asp:Label ID="Lbl_correo" runat="server" AssociatedControlID="Txt_correo" CssClass="form-label text-white" Text="Correo" />
                                    <asp:TextBox ID="Txt_correo" runat="server" CssClass="form-control form-control-lg" />
                                    
                                </div>

                                <div class="form-outline form-white mb-3">
                                    <asp:Label ID="Lbl_tel" runat="server" AssociatedControlID="Txt_telefono" CssClass="form-label text-white" Text="Teléfono" />
                                    <asp:TextBox ID="Txt_telefono" runat="server" CssClass="form-control form-control-lg"  />
                                    
                                </div>

                                <div class="mb-3">
                                    <asp:Label ID="Lbl_textregistro" runat="server" CssClass="text-white mb-2" Text="¿Cómo deseas registrarte?" />
                                    <asp:RadioButtonList ID="rblTipoUsuario" runat="server" CssClass="text-white" AutoPostBack="true" OnSelectedIndexChanged="rblTipoUsuario_SelectedIndexChanged">
                                        <asp:ListItem Text="Adoptador" Value="3" />
                                        <asp:ListItem Text="Refugio" Value="2" />
                                        <asp:ListItem Text="Admin" Value="1" />

                                    </asp:RadioButtonList>
                                </div>

                                <asp:Panel ID="pnlAdoptador" runat="server" Visible="false">
                                    <div class="form-outline form-white mb-3">
                                        <br />
                                        <asp:Label runat="server" AssociatedControlID="txtNombre" CssClass="form-label text-white" Text="Nombre" />
                                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control form-control-lg" />
                                        
                                    </div>
                                    <div class="form-outline form-white mb-3">
                                        <asp:Label runat="server" AssociatedControlID="txt_ApePa" CssClass="form-label text-white" Text="Apellido Paterno" />
                                        <asp:TextBox ID="txt_ApePa" runat="server" CssClass="form-control form-control-lg"  />
                                        
                                    </div>
                                    <div class="form-outline form-white mb-3">
                                        <asp:Label runat="server" AssociatedControlID="txt_ApeMa" CssClass="form-label text-white" Text="Apellido Materno" />
                                        <asp:TextBox ID="txt_ApeMa" runat="server" CssClass="form-control form-control-lg"  />
                                        
                                    </div>
                                </asp:Panel>

                                <asp:Panel ID="pnlRefugio" runat="server" Visible="false">
                                    <div class="form-outline form-white mb-3">
                                        <br />
                                         <asp:Label runat="server" AssociatedControlID="txt_Institucion" CssClass="form-label text-white" Text="Nombre de la institución" />
                                         <asp:TextBox ID="txt_Institucion" runat="server" CssClass="form-control form-control-lg"  />
                                       
                                    </div>
                                    <div class="form-outline form-white mb-3">
                                        <asp:Label ID="RFC" runat="server" AssociatedControlID="Txt_rfc" CssClass="form-label text-white" Text="RFC" />
                                        <asp:TextBox ID="Txt_rfc" runat="server" CssClass="form-control form-control-lg" placeholder="RFC" />
                                        
                                    </div>

                                    <div class="form-outline form-white mb-3">
                                        <asp:Label ID="Label2" runat="server" AssociatedControlID="Txt_direc" CssClass="form-label text-white" Text="Direccion" />
                                        <asp:TextBox ID="Txt_direc" runat="server" CssClass="form-control form-control-lg" placeholder="Direccion" OnTextChanged="Txt_direc_TextChanged" />
    
                                    </div>
                                </asp:Panel>

                                <asp:Panel ID="pnlAdmin" runat="server" Visible="false">
                                    <div class="form-outline form-white mb-3">
                                        <br />
                                        <asp:Label runat="server" AssociatedControlID="TextBox1" CssClass="form-label text-white" Text="Nombre" />
                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control form-control-lg" />
        
                                    </div>
                                    <div class="form-outline form-white mb-3">
                                        <asp:Label runat="server" AssociatedControlID="TextBox2" CssClass="form-label text-white" Text="Apellido Paterno" />
                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control form-control-lg"  />
        
                                    </div>
                                    <div class="form-outline form-white mb-3">
                                        <asp:Label runat="server" AssociatedControlID="TextBox3" CssClass="form-label text-white" Text="Apellido Materno" />
                                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control form-control-lg"  />
        
                                    </div>
                                </asp:Panel>

                                <asp:Button ID="Btn_registrar" runat="server" CssClass="btn btn-outline-light btn-lg w-100 mt-3" Text="REGISTRAR" OnClick="Button1_Click" />

                                <asp:Label ID="Label1" runat="server" CssClass="text-danger mt-3 d-block" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>