﻿<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="clay.aspx.cs"
    Inherits="clay"  %>

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
                    <img src="images/stone3.png" title="Lò gạch" alt="" />
                </td>
                <td>
                    <h2>
                        Lò gạch cấp <% Response.Write(this.current.VillageBuildingData.ClayPit); %></h2>
                    Cung cấp vật liệu xây dựng dùng cho phát triển thành phố to - đẹp - hiện đại. Nghe
                    giang hồ đồn đại rằng vào những đêm trăng sáng hoặc lễ hội Valentine, 8/3, hai vợ
                    chồng nhà Thị Nở - Chí Phèo chuyên môn ra đây tâm sự.
                </td>
            </tr>
        </tbody>
    </table>
    <br>
    <table class="vis">
        <tbody>
            <tr>
                <td width="200">
                    <img src="images/lehm.png" title="Wood" alt="">
                    Sản lượng hiện tại
                </td>
                <td>
                    Tăng <b>
                        <% Response.Write(current.VillageResourceMethods.ProductPerHour(beans.ResourcesType.Clay).ToString()); %></b>&nbsp;đơn vị gạch
                    mỗi giờ
                </td>
            </tr>
        </tbody>
    </table>
    </asp:Panel>
</asp:Content>
