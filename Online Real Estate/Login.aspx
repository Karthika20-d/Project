<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Online_Real_Estate.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

          Login
        <table>
          <tr>
               <td>Name</td>
               <td>
                   <asp:TextBox ID="txtName" runat="server" required="" /></td>
           </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" required="" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" Text="Submit" runat="server" OnClick="submit_Click" /></td>
            </tr>


        </table>

</asp:Content>
