﻿<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="wood.aspx.cs"
    Inherits="wood"  %>

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
                    <img src="images/wood3.png" title="Timber camp" alt="" />
                </td>
                <td>
                    <h2>
                        Trại đốn gỗ cấp <% Response.Write(this.current.VillageBuildingData.TimberCamp); %></h2>
                    Mỗi thành phố đều được hệ thống sinh thái rừng rậm bảo vệ khỏi nạn ô nhiễm môi 
                    trường từ khói thuốc, xe cộ và khí thải CO2. Từ rừng, chúng ta mới có những 
                    chuyện cổ tích như Thạch Sanh - Lý Thông hay Cây tre trăm đốt. Hi vọng các bác 
                    tiều phu của chúng ta không đốn quá nhiều, để dành cho con cháu mai sau.</td>
            </tr>
        </tbody>
    </table>
    <br>
    <table class="vis">
        <tbody>
            <tr>
                <td width="200">
                    <img src="images/holz.png" title="Wood" alt=""> Sản lượng hiện tại</td>
                <td>
                    Tăng <b><% Response.Write(current.VillageResourceMethods.ProductPerHour(beans.ResourcesType.Wood).ToString()); %></b>&nbsp;đơn 
                    vị gỗ mỗi giờ</td>
            </tr>
        </tbody>
    </table>
    </asp:Panel>
</asp:Content>
