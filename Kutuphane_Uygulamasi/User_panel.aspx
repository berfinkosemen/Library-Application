<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_panel.aspx.cs" Inherits="Kutuphane_Uygulamasi.User_panel" %>

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
                <ul class="nav navbar-nav">
                </ul>
            </div>
        </nav>

        <div class="container">
            <div class="row" >
                <div class="col-sm-3">
                                        
                </div>
                <div class="col-sm-6" style="background-color:palegoldenrod">
                    <h2>Arama Çubuğu</h2>
                    <h3>İsme veya ISBN numarasına göre arama yapabilirsiniz</h3>
                    
                    <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="true" Rows="2" Width="150" Font-Size="medium" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged">
                        <asp:ListItem>ISBN</asp:ListItem>
                        <asp:ListItem>Kitap İsmi</asp:ListItem>
                    </asp:ListBox>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" Width="149px"></asp:TextBox>
                    <asp:Button ID="btn_list" runat="server" Text="listele" Font-Bold="True" onclick="btn_list_Click" type="submit" class="btn btn-success btn-block" />
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                    <br />
                    <table style="width: 100%; text-align: center; ">  
                        <tr>  
                            <td class="center">  
                                <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
                            </td>  
                        </tr>  
                    </table> 
                    <br />
                </div>
            </div>
            <br />
            <br />
            <br />
            <div class="row">
                <div class="col-sm-3">
                                        
                </div>
                <div class="col-sm-6" style="background-color:palegoldenrod">
                    <h2>Almak istediğinin Kitap</h2>
                    <h3>İsme veya ISBN numarasına göre seçebilirsiniz</h3>                   
                    <asp:TextBox ID="TextBox2" runat="server" Width="149px"></asp:TextBox>                    
                    <asp:Button ID="btn_rent" runat="server" Text="Al" Font-Bold="True" onclick="btn_rent_Click" type="submit" class="btn btn-success btn-block" />
                    <asp:Label ID="warn" runat="server" Text=""></asp:Label>
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
    </form>
</body>
</html>