<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home_page.aspx.cs" Inherits="Kutuphane_Uygulamasi.Home_page" %>

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
    <form id="form1" runat="server">
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <a class="navbar-brand" href="#">Library App</a>
                </div>
                <ul class="nav navbar-nav"></ul>
            </div>
        </nav>

        <div class="modal-body" style="margin:5px 0px 0px 400px;">
            <img src="images/panel_4.png" />
                <div style="position:absolute; z-index:1; top: 100px; left: 140px;" id="layer1">
                    <div class="row">
                        <div class="col-xl-8">
                            <label for="sign_in" class="control-label" style="color:wheat;font-size:60px;font-weight:bold">GİRİŞ YAPINIZ</label>
                        </div>
                    </div>        
               </div>
            
                <div style="position:absolute; z-index:1; top: 250px; left: 100px; height: 100px; width: 200px;" id="layer2">
                    <div class="row">
                        <div class="col-xl-4">
                            <label for="user_sign_in" class="control-label" style="color:wheat;font-size:26px;font-weight:bold">Kullanıcı Girişi</label>                         
                        </div>
                   </div>                         
               </div>

                <div style="position:absolute; z-index:1; top: 330px; left: 395px; height: 120px; width: 150px;" id="layer3">
                    <div class="row">
                        <div class="col-xl-4">
                            <asp:Button ID="maneger_login" runat="server" Text="Login" Font-Bold="True" Onclick="maneger_login_Click" type="submit" class="btn btn-success btn-block" />
                        </div>
                   </div>                         
               </div>


                <div style="position:absolute; z-index:1; top: 250px; left: 390px; height: 100px; width: 150px;" id="layer4">
                    <div class="row">
                        <div class="col-xl-4">                            
                            <label for="manager_sign_in" class="control-label" style="color:wheat;font-size:26px;font-weight:bold">Yönetici Girişi</label></div>
                        </div>                         
                    </div>
                </div>
                
                <div style="position:absolute; z-index:1; top: 400px; left: 500px; height: 120px; width: 150px;" id="layer5">
                    <div class="row">
                        <div class="col-xl-4">                                 
                            <asp:Button ID="user_login" runat="server" Text="Login" Font-Bold="True" Onclick="user_login_Click" type="submit" class="btn btn-success btn-block" />
                        </div>                         
                    </div>
                </div>
        </div>
    </form>           
</body>
</html>




        