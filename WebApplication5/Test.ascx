<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Test.ascx.cs" Inherits="WebApplication5.Test1" %>
<script type="text/javascript">

    function Validate() {
        debugger;
        var value = document.getElementById('<%=TextBox_UserName.ClientID%>').value;
        if (value == '') {
            alert("Please enter date of birth");
            return false;
        }
        else {
            return true;
        }
    }
</script>
<div>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label_UserName" runat="server" Text="Enter DOB">
                </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox_UserName" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="CustomValidator_UserName" runat="server" ControlToValidate="TextBox_UserName"  OnServerValidate="CustomValidator_UserName_ServerValidate"
                    ErrorMessage="Please enter valid date of birth in valid format">

                </asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="Button_Save" runat="server" OnClientClick="return Validate();" OnClick="Button_Save_Click" Text="Save" />
            </td>
        </tr>
    </table>
</div>
