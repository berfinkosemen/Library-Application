<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manager_sign_in.aspx.cs" Inherits="Kutuphane_Uygulamasi.manager_sign_in" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Manager Login</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Style.css" rel="stylesheet" />
</head>
<body style="background-image:url('images/sign_in.jpg')">
    <form id="form1" runat="server">
        <div class="panel-img">
            <img src="images/Panel.png" />
        </div>
        <div>
            <div style="position:absolute; z-index:1;" id="layer1">
                <div class="modal-body" style="margin:5px 0px 0px 550px;">
                    <div class="row">
                        <div class="col-xl-12">
                            <label for="user_login" class="control-label" style="color:black;font-size:26px;font-weight:bold">Yönetici Girişi</label>
                            <div class="form-group">
                                <label for="username" class="control-label">Username</label><br />
                                <asp:TextBox ID="TextBox_user_name" runat="server"  type="text" class="form-control" title="User_name"></asp:TextBox>
                                <span class="help-block"></span>
                            </div>
                            <div class="form-group">
                                <label for="password" class="control-label">Password</label><br />
                                <asp:TextBox ID="TextBox_password" runat="server" TextMode="Password" type="password" class="form-control" name="password" title="Password"></asp:TextBox>
                                <span class="help-block"></span>
                            </div>
                            <asp:Button ID="btn_login" runat="server" Text="Login" Font-Bold="True" onclick="btn_login_Click" type="submit" class="btn btn-success btn-block" /><br />
                            <asp:Label ID="lb1" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label><br />
                        </div>                        
                    </div>
                </div>
            </div>
        </div>       
    </form>
</body>
</html>
