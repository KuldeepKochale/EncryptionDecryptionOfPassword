<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="EncryptionDecryptionOfPassword.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 50%;
            text-align:center;
        }
        .auto-style2 {
            width: 400px;
        }
        .auto-style3 {
            width: 485px;
        }
    </style>
</head>
<body style="width: 543px">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Larger" Text="Encryption And Decryption Of Password"></asp:Label>
        </div>
        <asp:Label ID="Label2" runat="server" Text="LogIn or SignUp" BackColor="#66FFFF" Font-Names="Arial Narrow" ForeColor="#CC66FF"></asp:Label>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="Button1" runat="server" ForeColor="#FF9966" Height="29px" OnClick="Button1_Click" Text="Login" Width="142px" BackColor="#FFFF99" />
                </td>
                <td class="auto-style3">
                    <asp:Button ID="Button2" runat="server" ForeColor="#FF9966" OnClick="Button2_Click" Text="Signup" Width="141px" Height="29px" BackColor="#FFFF99" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
