<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accountSetting.aspx.cs" Inherits="sampleWeb.page.Account.accountSetting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <asp:Label ID="showMessage" runat="server" ></asp:Label>
    <form id="form1" runat="server">
    <div>       
        <table border="1">
            <tr>
                <td><h3>新增帳號</h3></td>
            </tr>
            <tr>
                <td>帳號：<asp:TextBox ID="AddAccount" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>姓名：<asp:TextBox ID="AddAccountName" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>帳號類別：<asp:TextBox ID="AddAccountType" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Button ID="Add" runat="server" Text="新增" OnClick="Add_Click" /></td>
            </tr>
        </table>     
    </div>
    <div>       
        <table border="1">
            <tr>
                <td><h3>修改帳號</h3></td>
            </tr>
            <tr>
                <td>查詢資料:
                    <asp:TextBox ID="QueryAccount" runat="server"></asp:TextBox>
                    <asp:Button ID="QueryAccountBtn" runat="server" Text="查詢" OnClick="Query_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="UpdateAccount" runat="server" Visible="false" ></asp:TextBox>
                    姓名：<asp:TextBox ID="UpdateAccountName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Update" runat="server" Text="修改" OnClick="Update_Click" style="height: 21px" />
                    <asp:Button ID="Delete" runat="server" Text="刪除" OnClick="Delete_Click" style="height: 21px" />
                </td>
            </tr>
        </table>     
    </div>
    </form>
</body>
</html>
