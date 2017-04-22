<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication5.WebForm1" %>

<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="hy" runat="server" Text="sdfsdfsf"></asp:HyperLink>
       
       <%-- <uc1:WebUserControl1 runat="server" id="WebUserControl1" />--%>
        <asp:Button ID="Button_Save" runat="server" Text="save" OnClick="Button_Save_Click" />
    </div>
    </form>
</body>
</html>
