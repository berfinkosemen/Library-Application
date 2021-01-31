<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_panel_2.aspx.cs" Inherits="Kutuphane_Uygulamasi.User_panel_2" %>

<!DOCTYPE html>

<html lang="en">
<head>
        <title>Bootstrap Example</title>
            <meta charset="utf-8">
            <meta name="viewport" content="width=device-width, initial-scale=1">
            <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
            <link href="Content/Style.css" rel="stylesheet" />
            <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
            <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body style="background-image:url('images/library_2.jpg')">
    <form id="form1" runat="server" >
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <a class="navbar-brand" href="#">Library App</a>
                </div>
                <ul class="nav navbar-nav"></ul>
            </div>
        </nav>
        <div class="row">
            <br />
            <br />
            <br />
            <br />
            <br />
                <div class="col-sm-3">
                                        
                </div>
                <div class="col-sm-6" style="background-color:palegoldenrod">
                    <h2>Kitap İade Et</h2>
                    <h3>Resmi Yükleyiniz</h3>                   
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Resmi Yükle ve ISBN oku" />
                    <br />
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="true"></asp:Label>
                    <br />
                    <asp:Label ID="ısbn_number" runat="server" Height="26px" Width="200px"></asp:Label>
                    <br />
                    <asp:Button ID="insert" runat="server" Text="İade et" OnClick="insert_Click" />
                    <br />
                    <br />
                </div>
            </div>
            <div style="position:absolute; z-index:1; top: 11px; left: 1369px; height: 39px; width: 150px;" id="layer7">
                    <div class="row">
                        <div class="col-xl-4">              
                            <asp:Button ID="Logout" runat="server" Text="Çıkış Yap" Font-Bold="True" Onclick="logout_Click" type="submit" class="btn btn-success btn-block" />
                        </div>                         
                    </div>
                </div> 
            <div style="position:absolute; z-index:1; top: 11px; left: 1180px; height: 39px; width: 150px;" id="layer8">
                    <div class="row">
                        <div class="col-xl-4">              
                            <asp:Button ID="return" runat="server" Text="İşlemler" Font-Bold="True" Onclick="return_Click" type="submit" class="btn btn-success btn-block" />
                        </div>                         
                    </div>
                </div>
    </form>
</body>
</html>
