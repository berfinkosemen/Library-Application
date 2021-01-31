<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transfer_user_panel.aspx.cs" Inherits="Kutuphane_Uygulamasi.Transfer_user_panel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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
                <div style="position:absolute; z-index:1; top: 93px; left: 218px;" id="layer1">
                    <div class="row">
                        <div class="col-xl-8">
                            <label for="sign_in" class="control-label" style="color:wheat;font-size:60px;font-weight:bold">İşlemler</label>
                        </div>
                    </div>        
               </div>
            
                <div style="position:absolute; z-index:1; top: 250px; left: 75px; height: 100px; width: 200px;" id="layer2">
                    <div class="row">
                        <div class="col-xl-4">
                            <label for="kitap al" class="control-label" style="color:wheat;font-size:26px;font-weight:bold">Kitap Listele ve Al</label>                                
                        </div>
                   </div>                         
               </div>

                <div style="position:absolute; z-index:1; top: 321px; left: 97px; height: 40px; width: 150px;" id="layer5">
                    <div class="row">
                        <div class="col-xl-4">                                 
                            <asp:Button ID="take_book" runat="server" Text="İleri" Font-Bold="True" Onclick="take_book_Click" type="submit" class="btn btn-success btn-block" />
                        </div>                         
                    </div>
                </div>

                <div style="position:absolute; z-index:1; top: 319px; left: 396px; height: 36px; width: 147px;" id="layer3">
                    <div class="row">
                        <div class="col-xl-4">
                            <asp:Button ID="return_book" runat="server" Text="İleri" Font-Bold="True" Onclick="return_book_Click" type="submit" class="btn btn-success btn-block" Height="38px" />
                        </div>
                   </div>                         
               </div>


                <div style="position:absolute; z-index:1; top: 249px; left: 402px; height: 42px; width: 150px;" id="layer4">
                    <div class="row">
                        <div class="col-xl-4">                            
                            <label for="Kitap iade" class="control-label" style="color:wheat;font-size:26px;font-weight:bold">Kitap iade et</label></div>
                        </div>                         
                    </div>
                </div>

                <div style="position:absolute; z-index:1; top: 11px; left: 1369px; height: 39px; width: 150px;" id="layer7">
                    <div class="row">
                        <div class="col-xl-4">              
                            <asp:Button ID="Logout" runat="server" Text="log out" Font-Bold="True" Onclick="logout_Click" type="submit" class="btn btn-success btn-block" />
                        </div>                         
                    </div>
                </div>                    
            </diz>                
        </div>
    </form>
</body>
</html>
