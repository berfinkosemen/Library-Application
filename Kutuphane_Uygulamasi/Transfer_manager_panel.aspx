<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transfer_manager_panel.aspx.cs" Inherits="Kutuphane_Uygulamasi.Transfer_manager_panel" %>

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
                <div style="position:absolute; z-index:1; top: 56px; left: 224px;" id="layer1">
                    <div class="row">
                        <div class="col-xl-8">
                            <label for="sign_in" class="control-label" style="color:wheat;font-size:60px;font-weight:bold">İşlemler</label>
                        </div>
                    </div>        
               </div>
            
                <div style="position:absolute; z-index:1; top: 175px; left: 100px; height: 100px; width: 200px;" id="layer2">
                    <div class="row">
                        <div class="col-xl-4">
                            <label for="Kitap_ekle" class="control-label" style="color:wheat;font-size:26px;font-weight:bold">Kitap Ekle</label>                                
                        </div>
                   </div>                         
               </div>

                <div style="position:absolute; z-index:1; top: 228px; left: 73px; height: 37px; width: 150px;" id="layer5">
                    <div class="row">
                        <div class="col-xl-4">                                 
                            <asp:Button ID="add_book" runat="server" Text="İleri" Font-Bold="True" Onclick="add_book_Click" type="submit" class="btn btn-success btn-block" />
                        </div>                         
                    </div>
                </div>

                <div style="position:absolute; z-index:1; top: 228px; left: 423px; height: 36px; width: 153px; right: 874px;" id="layer3">
                    <div class="row">
                        <div class="col-xl-4">
                            <asp:Button ID="zaman_atla" runat="server" Text="İleri" Font-Bold="True" Onclick="time_change_Click" type="submit" class="btn btn-success btn-block" />
                        </div>
                   </div>                         
               </div>


                <div style="position:absolute; z-index:1; top: 171px; left: 442px; height: 48px; width: 146px;" id="layer4">
                    <div class="row">
                        <div class="col-xl-4">                            
                            <label for="zaman atla" class="control-label" style="color:wheat;font-size:26px;font-weight:bold">Zaman Atla</label></div>
                        </div>                         
                    </div>
                </div>
                
                <div style="position:absolute; z-index:1; top: 385px; left: 611px; height: 57px; width: 225px;" id="layer6">
                    <div class="row">
                        <div class="col-xl-4">
                            <label for="kitap al" class="control-label" style="color:wheat;font-size:26px;font-weight:bold">Kullanıcıları Listele</label>                                
                        </div>
                   </div>                         
               </div>

                <div style="position:absolute; z-index:1; top: 453px; left: 636px; height: 37px; width: 150px;" id="layer7">
                    <div class="row">
                        <div class="col-xl-4">                                 
                            <asp:Button ID="list" runat="server" Text="İleri" Font-Bold="True" Onclick="list_Click" type="submit" class="btn btn-success btn-block" />
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

        </div>
    </form>
</body>
</html>
