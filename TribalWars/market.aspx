﻿<%@ Page Title="" Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true"
    CodeFile="market.aspx.cs" Inherits="market" %>
    
<%@ Reference Control="MerchantStatus.ascx" %>
<%@ Reference Control="SendResource.ascx" %>
<%@ Reference Control="MakeMarketOffer.ascx" %>
<%@ Reference Control="OtherOffers.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
<asp:Panel ID="pNotConstruct" runat="server" Visible="false">
        <h1>Công trình chưa được xây dựng</h1>
    </asp:Panel>
    <asp:Panel ID="pConstructed" runat="server" Visible="false">
    <table>
        <tbody>
            <tr>
                <td>
                    <img src="images/big_buildings/market3.png" title="Market" alt="">
                </td>
                <td>
                    <h2>
                        Market Level <% = this.Village.VillageBuildingData.Market %></h2>
                    On the market you can trade with other players.
                </td>
            </tr>
        </tbody>
    </table>
    <br>
    <table>
        <tbody>
            <tr>
                <td valign="top">
                    <table class="vis" id="tblMenu" runat="server">
                        <tbody>
                            <tr>
                                <td width="100">
                                    <a href="market.aspx?id=<%= this.Village.ID %>">Gửi tài nguyên</a>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <a href="market.aspx?id=<%= this.Village.ID %>&page=make_offer">Your offers</a>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <a href="market.aspx?id=<%= this.Village.ID %>&page=market">Other offers</a>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <a href="market.aspx?id=<%= this.Village.ID %>&page=merchant_status">Merchant status</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td valign="top">
                    
                    <asp:PlaceHolder ID="pMarket" runat="server"></asp:PlaceHolder>
                    
                </td>
            </tr>
        </tbody>
    </table>
    </asp:Panel>
</asp:Content>
