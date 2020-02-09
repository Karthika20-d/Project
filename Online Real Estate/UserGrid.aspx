<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UserGrid.aspx.cs" Inherits="Online_Real_Estate.UserGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="UserData" runat="server" DataKeyNames="UserID" AutoGenerateColumns="False"  OnRowDeleting="UserGrid_RowDeleting" OnRowEditing="UserGrid_RowEditing" OnRowCancelingEdit="UserGrid_RowCancelingEdit" OnRowUpdating="UserGrid_RowUpdating" ShowFooter="true">
                        <Columns>
                            <asp:TemplateField HeaderText="UserId">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtUserId" runat="server" Text='<%# Bind("UserId") %>'>
                                    </asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblUser" runat="server" Text='<%# Bind("UserId") %>'>
                                    </asp:Label>
                                    </ItemTemplate>
                                    <footertemplate>
                                        <asp:LinkButton ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click">
                                        </asp:LinkButton>
                                        </footertemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <EditItemTemplate>

                                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("UserName") %>'>
                                    </asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("UserName") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNameInsert" runat="server">
                                    </asp:TextBox>
                                </FooterTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Password">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPassword" runat="server" Text='<%# Bind("Password") %>'>
                                    </asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblPassword" runat="server" Text='<%# Bind("Password") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtPasswordInsert" runat="server">
                                    </asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mail_ID">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMailId" runat="server" Text='<%# Bind("Mail_ID") %>'>
                                    </asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMail" runat="server" Text='<%# Bind("Mail_ID") %>'>
                                    </asp:Label>

                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtMailInsert" runat="server">
                                    </asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Location">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtLocationId" runat="server" Text='<%# Bind("Location") %>'>
                                    </asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblLocation" runat="server" Text='<%# Bind("Location") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtLocationInsert" runat="server">
                                    </asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PhoneNumber">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPhoneId" runat="server" Text='<%# Bind("Phone_Number") %>'>
                                    </asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblPhone" runat="server" Text='<%# Bind("Phone_Number") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtPhoneInsert" runat="server">
                                    </asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Role">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtRoleId" runat="server" Text='<%# Bind("Role") %>'>
                                    </asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblRole" runat="server" Text='<%# Bind("Role") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtRoleInsert" runat="server">
                                    </asp:TextBox>
                                </FooterTemplate>
                                
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="true" />
                            <asp:CommandField ShowDeleteButton="true" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
