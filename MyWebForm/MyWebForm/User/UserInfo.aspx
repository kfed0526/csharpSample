<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/WebFormSite.master" CodeBehind="UserInfo.aspx.cs" Inherits="MyWebForm.User.UserInfo" %>
<%@ Register Src="~/PageSite/UsPager.ascx" TagPrefix="uc1" TagName="UsPager" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:Panel runat="server" ID="Panel_Query">
            <asp:Label ID="Message" runat="server" ForeColor="Red"></asp:Label>
            <div class="table-wrapper">
                <asp:LinkButton ID="LinkButton_NewAccount" runat="server" OnClick="LinkButton_NewAccount_Click" CssClass="button">新增帳號
                </asp:LinkButton>
                <table class="alt" style="margin-bottom:0px;">
                <thead>
                    <tr>
                        <td>帳號名稱</td>
                        <td>帳號姓名</td>
                        <td>生日</td>
                        <td>功能</td>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater_View" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# HttpContext.Current.Server.HtmlEncode (ProcessNullDataItem(Eval("USER_ID"))) %> </td>
                                <td>
                                    <%# HttpContext.Current.Server.HtmlEncode (ProcessNullDataItem(Eval("USER_NAME"))) %> </td>
                                <td>
                                    <%# HttpContext.Current.Server.HtmlEncode (ProcessNullDataItem(Eval("USER_BIRTHDAY"))) %> </td>
                                <td>
                                    <asp:LinkButton class="button" ID="LinkButton_Edit" ToolTip="編輯" OnClick="LinkButton_Edit_Click" runat="server" Text="修改"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton_Del" OnClick="LinkButton_Del_Click" CssClass="button green" runat="server" ToolTip="刪除"
                                        OnClientClick="return confirm(&quot;確認要刪除這筆資料嗎?&quot;)" Text="刪除"></asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField_cNo" runat="server" Value='<%#Eval("USER_ID") %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <uc1:UsPager runat="server" ID="ucPage" Size="10" OnPageIndexChanged="ucPage_PageIndexChanged"  />
            </div>                                     
    </asp:Panel>
    <asp:Panel runat="server" ID="Panel_Edit" Visible="false">
        <asp:HiddenField ID="HiddenField_Edit_cNo" runat="server" />
        <table  summary="列表" border="0" style="border:solid 1px #be9e9e;">
            <tbody>
                <tr>
                    <td>帳號名稱</td>
                    <td><asp:TextBox ID="TextBox_User_Id" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>帳號姓名</td>
                    <td><asp:TextBox ID="TextBox_User_Name" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>電話</td>
                    <td><asp:TextBox ID="TextBox_User_Phone" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>地址</td>
                    <td><asp:TextBox ID="TextBox_User_Address" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>生日</td>
                    <td><asp:TextBox ID="TextBox_User_Birthday" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button_Submit" runat="server" Text="確定" OnClick="Button_Submit_Click" />
                        <asp:Button ID="Button_Cancel" runat="server" Text="取消" OnClick="Button_Cancel_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
</asp:Content>
