﻿<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="list_mail.aspx.cs"
    Inherits="list_mail" Title="Mail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
 <h2>Hòm thư đến</h2>
    <table width="100%">
        <tbody>
            <tr>
                <td valign="top">
                    <table class="vis" width="100" runat="server" id="Mail" visible="True">
                        <tbody>
                            <tr>
                                <td width="100" class="selected">
                                    <a href="list_mail.aspx?id=<% = this.village.ID %>">Thư đến</a>
                                </td>
                            </tr>
                            <tr>
                                <td width="100" >
                                    <a href="mail_send.aspx?id=<% = this.village.ID %>">Thư đi</a>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <a href="write_mail.aspx?id=<% = this.village.ID %>">Viết thư</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
               <td valign="top" width="100%">
               <asp:Repeater runat="server" ID="rMails">
                <HeaderTemplate>
                    <table cellspacing="0" rules="all" border="1" style="border-color: Black; border-width: 1px;
                                    border-style: Solid; width: 100%; border-collapse: collapse;">
                                    <tbody>
                                        <tr>
                                            <th>
                                            </th>
                                            <th>
                                                <center>
                                                    Tiêu đề</center>
                                            </th>
                                            <th>Người gửi</th>
                                            <th>
                                                <center>
                                                    Thời gian</center>
                                            </th>
                                        </tr>
                </HeaderTemplate>
                <FooterTemplate>
                    </tbody></table>
                </FooterTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            
                        </td>
                        <td> 
                            <a href="mail_detail.aspx?id=<% = this.village.ID %>&mail=<%# Eval("ID") %>"><%# Eval("Title") %> <%# this.UnreadStatus((bool)Eval("Unread")) %></a>
                        </td>
                        <td>
                            <a href="user_info.aspx?id=<% = this.village.ID %>&player=<%# ((beans.Player)Eval("To")).ID %>"><%# ((beans.Player)Eval("To")).Username %></a>
                        </td>
                        <td>
                            <%# ((DateTime)Eval("Time")).ToString("HH:mm:ss 'ngày' dd/MM/yyyy") %>
                        </td>
                    </tr>
                </ItemTemplate>
               </asp:Repeater>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
      