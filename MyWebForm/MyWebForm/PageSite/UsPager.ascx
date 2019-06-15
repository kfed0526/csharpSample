<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UsPager.ascx.cs" Inherits="MyWebForm.PageSite.UsPager" %>
<div class="pager" style="float:right;font-size:10px;display:block;">
    <asp:LinkButton runat="server" CssClass="page-numbers-prev" OnClick="lblpre_Click" Text="上一頁" ID="lblpre"></asp:LinkButton>
    <asp:LinkButton runat="server" CssClass="page-numbers" Text="1..." OnClick="lblIst_Click" ID="lblIst" Visible="false"></asp:LinkButton>
    <asp:Label CssClass="page-small" ID="Label_Page"  runat="server" Text="1"></asp:Label>
    <asp:PlaceHolder ID="pl" runat="server"></asp:PlaceHolder>
    <asp:LinkButton runat="server" CssClass="page-numbers" OnClick="lblLast_Click" ID="lblLast" Visible="false"></asp:LinkButton>
    <asp:LinkButton runat="server" CssClass="page-numbers-next" OnClick="lblnext_Click" Text="下一頁" ID="lblnext"></asp:LinkButton>
    <asp:LinkButton runat="server" Text="4" ID="LinkButton_Go" style=" display:none;width:0px" OnClick="lnk_Click"></asp:LinkButton>
</div>

<input type="hidden" runat="server" id="hdSize" />
<asp:HiddenField ID="HiddenField_Index" runat="server" Value="0" />
<asp:HiddenField ID="HiddenField_MaxPageIndex" runat="server" Value="0" />
<asp:HiddenField ID="HiddenField_Size" runat="server"  Value="0"/>
<asp:HiddenField ID="HiddenField_Total" runat="server"  Value="0"/>
<div style="clear:both;"></div>