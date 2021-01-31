<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager_panel.aspx.cs" Inherits="Kutuphane_Uygulamasi.Manager_panel" %>

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
                    <a class="navbar-brand" href="#">Library app</a>
                </div>
                <ul class="nav navbar-nav">
                    <li><a href="#"></a></li>
                </ul>
            </div>
        </nav>

        
        <div class="container">
            <div class="row" >
                <br />
            <br />
            <br />
            <br />
            <br />
                <div class="col-sm-3">
                                        
                </div>
                <div class="col-sm-6" style = "background-color:palegoldenrod">
                    <h2>Kitap Ekle</h2>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload File And Get ISBN" Width="206px" />
                    <br />
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="true"></asp:Label>
                    <br />
                    <asp:Label ID="ısbn_number" runat="server" Height="25px" Width="200px"></asp:Label>
                    <asp:TextBox ID="TextBox_book_name" runat="server"  type="text" class="form-control" title="Book name" Width="210px"></asp:TextBox>
                    <asp:Button ID="insert" runat="server" Text="Kitap Ekle" OnClick="insert_Click" />
                    
                    <br />
                    <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
                    <br />
                    <br />
                    
                    
                </div>              
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
        </div>    
    </form>
</body>
</html>
