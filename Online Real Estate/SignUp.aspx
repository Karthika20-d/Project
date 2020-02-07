<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Online_Real_Estate.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
          Registration
            <table>
                <tr>
                    <td>Name</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" required="" /></td>
                </tr>
                <tr>
                    <td>Mail-id</td>
                    <td>
                        <asp:TextBox ID="txtMail" TextMode="Email" runat="server" required="" />
                    </td>
                </tr>
                <tr>
                    <td>Phone number</td>
                    <td>
                        <asp:TextBox ID="txtNumber" TextMode="Phone" runat="server" required="" /></td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" required="" />
                    </td>
                </tr>
                <tr>
                    <td>Role </td>
                    <td>
                        <asp:RadioButton ID="btnBuyer" runat="server" Text="Buyer" GroupName="Role" />
                        <asp:RadioButton ID="btnSeller" runat="server" Text="Seller" GroupName="Role" />
                    </td>
                </tr>
                <tr>
                    <td>Location </td>
                    <td>
                        <asp:TextBox ID="txtLocation" runat="server" required="" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="submit_Click" />

                    </td>
                </tr>
            </table>

</asp:Content>
