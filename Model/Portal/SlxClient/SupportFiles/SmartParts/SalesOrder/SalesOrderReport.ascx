<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SalesOrderReport.ascx.cs" Inherits="SmartParts_SalesOrder_SalesOrderReport" %>
<%@ Register Assembly="Sage.SalesLogix.Web.Controls" Namespace="Sage.SalesLogix.Web.Controls.PickList" TagPrefix="SalesLogix" %>
<%@ Register Assembly="Sage.SalesLogix.Web.Controls" Namespace="Sage.SalesLogix.Web.Controls" TagPrefix="SalesLogix" %>
<%@ Register Assembly="Sage.SalesLogix.Web.Controls" Namespace="Sage.SalesLogix.Web.Controls.DependencyLookup" TagPrefix="SalesLogix" %>
<%@ Register Assembly="Sage.SalesLogix.Web.Controls" Namespace="Sage.SalesLogix.Web.Controls.Lookup" TagPrefix="SalesLogix" %>
<%@ Register Assembly="Sage.SalesLogix.HighLevelTypes" Namespace="Sage.SalesLogix.HighLevelTypes" TagPrefix="SalesLogix" %>
<style type="text/css">
    .style2
    {
        font-size: small;
        text-align: left;
    }
    .style3
    {
        font-size: small;
        font-weight: bold;
    }
    .style4
    {
        text-align: left;
    }
    .style5
    {
        font-size: small;
        font-weight: bold;
        text-align: center;
    }
    .style6
    {
        text-align: center;
        font-size: small;
    }
    .style8
    {
        text-align: center;
    }
    .style9
    {
        border-left-style: solid;
        border-left-width: 1px;
        border-right-style: solid;
        border-right-width: 1px;
    }
    .style10
    {
        font-size: small;
        text-align: left;
    }
    .style12
    {
        text-align: center;
        width: 81px;
    }
    .style13
    {
        text-align: left;
        width: 174px;
    }
    .style14
    {
        font-size: small;
        font-weight: bold;
        width: 174px;
    }
    .style16
    {
        border-left-style: solid;
        border-left-width: 1px;
        border-right-style: solid;
        border-right-width: 1px;
        border-bottom-style: solid;
        border-bottom-width: 1px;
    }
    .style17
    {
        text-align: center;
        font-size: small;
        }
    .style18
    {
        text-align: center;
        font-size: small;
        width: 81px;
    }
    .style19
    {
        text-align: center;
        font-size: small;
        border-left-style: solid;
        border-left-width: 1px;
        border-right-style: solid;
        border-right-width: 1px;
        border-top-style: solid;
        border-top-width: 1px;
    }
    .style20
    {
        text-align: center;
        font-size: small;
        border-bottom-style: solid;
        border-bottom-width: 1px;
    }
    .style21
    {
        font-size: small;
        font-weight: bold;
        text-align: left;
    }
</style>
<div style="display:none"></div>
<table width="100%">
<tr>
<td colspan="4" style="text-align: center">
    &nbsp;</td>
<td colspan="3" style="text-align: center">
    &nbsp;</td>
<td colspan="3" style="text-align: center">
<asp:ImageButton ID="ImageButton1" runat="server"
AlternateText="Print" ImageUrl="~/ImageResource.axd?scope=global&type=Global_Images&key=Print_View_16x16"
OnClientClick="javascript:window.print()"
ToolTip="Print page" />
    
</td>
</tr>
<tr>
<td colspan="10" style="text-align: center">
    <asp:Label ID="lblSalesOrderType" runat="server" 
        Text="Anticipated Sales Orders" style="font-size: large"></asp:Label>
    </td>
</tr>
<tr>
<td class="style13">&nbsp;</td>
<td colspan="5">&nbsp;</td>
<td colspan="3">&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td class="style14">Event ID:</td>
<td colspan="5">
    <b>
    <asp:Label ID="lblEventId" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </b>
    </td>
<td class="style3" style="text-align: right" colspan="3">Sales Order No.:</td>
<td>
    <b>
    <asp:Label ID="lblSalesOrderNo" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </b>
    </td>
</tr>
<tr>
<td class="style14">Event Name:</td>
<td colspan="8">
    <b>
    <asp:Label ID="lblEventName" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </b>
    </td>
<td class="style3">&nbsp;</td>
</tr>
<tr>
<td class="style14">Bill To Account</td>
<td colspan="8">
    <b>
    <asp:Label ID="lblBillToAccount" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </b>
    </td>
<td class="style3">&nbsp;</td>
</tr>
<tr>
<td class="style13" >&nbsp;</td>
<td colspan="5" >&nbsp;</td>
<td colspan="3" >&nbsp;</td>
<td >&nbsp;</td>
</tr>
<tr>
<td class="style13" >&nbsp;</td>
<td class="style8" colspan="8" ><span class="style2">PO No.:</span><asp:Label 
        ID="lblPoNo" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td >&nbsp;</td>
</tr>
<tr>
<td class="style13" >&nbsp;</td>
<td class="style8" colspan="8" ><span class="style2">Project ID:</span><asp:Label 
        ID="lblProjectId" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td >&nbsp;</td>
</tr>
<tr>
<td class="style13" >&nbsp;</td>
<td colspan="5" >&nbsp;</td>
<td colspan="3" >&nbsp;</td>
<td >&nbsp;</td>
</tr>
<tr>
<td colspan="6" style="font-weight: 700" >
    <asp:Label ID="lblAccountName" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style2" style="text-align: right" colspan="3" >Main Arrival:</td>
<td >
    <asp:Label ID="lblMainArrival" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
</tr>
<tr>
<td colspan="6" style="font-weight: 700" >&nbsp;</td>
<td class="style2" style="text-align: right" colspan="3" >&nbsp;</td>
<td >&nbsp;</td>
</tr>
<tr>
<td class="style13" ><span class="style2">Acct Status:</span><asp:Label 
        ID="lblAccountStatus" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style2" colspan="5" >Event Sub-Class:</td>
<td class="style2" style="text-align: right" colspan="3" >Main Departure:</td>
<td >
    <asp:Label ID="lblMainDeparture" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
</tr>
<tr>
<td class="style13" >&nbsp;</td>
<td class="style2" colspan="5" >&nbsp;</td>
<td class="style2" style="text-align: right" colspan="3" >&nbsp;</td>
<td >&nbsp;</td>
</tr>
<tr>
<td class="style19" colspan="6" ><strong class="style5">Client Account&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </strong>
    <asp:Label ID="lblCustNoCA" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style19" colspan="4" ><strong class="style5" style="text-align: center">
    Bill To Account&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </strong>
    <asp:Label ID="lblCustNoBA" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
</tr>
<tr>
<td class="style9" colspan="6" >Name:<asp:Label ID="lblNameCA" runat="server" 
        Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style9" colspan="4" >&nbsp; Name:<asp:Label ID="lblNameBA" 
        runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
</tr>
<tr>
<td class="style9" colspan="6" >
    <asp:Label ID="lblAddressCA" runat="server" Text="Label" CssClass="style2"></asp:Label>
    &nbsp;<asp:Label ID="lblAddress2CA" runat="server" Text="Label" 
        CssClass="style2"></asp:Label>
    &nbsp;<asp:Label ID="lblAddress3CA" runat="server" Text="Label" 
        CssClass="style2"></asp:Label>
    </td>
<td class="style9" colspan="4" >&nbsp;
    <asp:Label ID="lblAddressBA" runat="server" Text="Label" CssClass="style2"></asp:Label>
    &nbsp;<asp:Label ID="lblAddress2BA" runat="server" Text="Label" 
        CssClass="style2"></asp:Label>
    &nbsp;<asp:Label ID="lblAddress3BA" runat="server" Text="Label" 
        CssClass="style2"></asp:Label>
    </td>
</tr>
<tr>
<td class="style9" colspan="6" >
    <asp:Label ID="lblAddress4CA" runat="server" Text="Label" CssClass="style2"></asp:Label>
    <asp:Label ID="lblAddress5CA" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style9" colspan="4" >&nbsp;
    <asp:Label ID="lblAddress4BA" runat="server" Text="Label" CssClass="style2"></asp:Label>
    <asp:Label ID="lblAddress5BA" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
</tr>
<tr>
<td class="style9" colspan="6" >Contact:<asp:Label ID="lblContactCA" runat="server" 
        Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style9" colspan="4" >&nbsp; Contact:<asp:Label ID="lblContactBA" 
        runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
</tr>
<tr>
<td class="style9" colspan="6" >Phone:<asp:Label ID="lblPhoneCA" runat="server" 
        Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style9" colspan="4" >&nbsp; Phone:<asp:Label ID="lblPhoneBA" 
        runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
</tr>
<tr>
<td class="style9" colspan="6" >Fax:<asp:Label ID="lblFaxCA" runat="server" 
        Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style9" colspan="4" >&nbsp; Fax:<asp:Label ID="lblFaxBA" runat="server" 
        Text="Label" CssClass="style2"></asp:Label>
    </td>
</tr>
<tr>
<td class="style9" colspan="6" >&nbsp;</td>
<td class="style9" colspan="4" >&nbsp;</td>
</tr>
<tr>
<td class="style16" colspan="6" >&nbsp;</td>
<td class="style16" colspan="4" >&nbsp;</td>
</tr>
<tr>
<td class="style10" colspan="3" ><strong class="style5">Person</strong></td>
<td class="style6" >&nbsp;</td>
<td class="style18" colspan="2" ><strong class="style5" style="text-align: center">Comm. (%)</strong></td>
<td class="style2" colspan="4" style="text-align: right" >&nbsp;</td>
</tr>
<tr>
<td class="style10" colspan="3" >Account Owner:</td>
<td class="style4" >
    <asp:Label ID="lblAccountOwner" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style12" colspan="2" >&nbsp;</td>
<td class="style10" colspan="4" >Domain:<asp:Label ID="lblDomain" runat="server" 
        Text="Label" CssClass="style2"></asp:Label>
    </td>
</tr>
<tr>
<td class="style10" colspan="3" >Order Owner:</td>
<td class="style4" >
    <asp:Label ID="lblOrderOwner" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style12" colspan="2" >
    <asp:Label ID="lblOrderOwnerComm" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style10" colspan="4" >Room Comm:<asp:Label ID="lblRoomComm" 
        runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
</tr>
<tr>
<td class="style10" colspan="3" >Sec. Owner:</td>
<td class="style4" >
    <asp:Label ID="lblSecOwner" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style12" colspan="2" >
    <asp:Label ID="lblSecOwnerComm" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style10" colspan="4" >Drop Off%:<asp:Label ID="lblDropOff" 
        runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
</tr>
<tr>
<td class="style10" colspan="3" >Add&#39;l Owner:</td>
<td class="style4" >
    <asp:Label ID="lblAddlOwner" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style12" colspan="2" >&nbsp;</td>
<td class="style10" colspan="4" >Rate Confirmed:<asp:Label ID="lblRateConfirmed" 
        runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
</tr>
<tr>
<td class="style10" colspan="3" >MEM:</td>
<td class="style4" >
    <asp:Label ID="lblMem" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style12" colspan="2" >&nbsp;</td>
<td class="style10" colspan="4" >Compare Date:<asp:Label ID="lblCompareDate" 
        runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
</tr>
<tr>
<td class="style10" colspan="3" >Market:</td>
<td class="style4" >
    <asp:Label ID="lblMarket" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style12" colspan="2" >&nbsp;</td>
<td class="style2" colspan="4" style="text-align: right" >&nbsp;</td>
</tr>
<tr>
<td class="style10" colspan="3" >&nbsp;</td>
<td class="style4" >&nbsp;</td>
<td class="style12" colspan="2" >&nbsp;</td>
<td class="style2" colspan="4" style="text-align: right" >&nbsp;</td>
</tr>
<tr>
<td class="style2" colspan="6" >
    <asp:Label ID="lblTotRevenuelbl" runat="server" style="font-weight: 700" 
        Text="Total Anticipated Revenue: $"></asp:Label>
&nbsp;&nbsp; </td>
<td class="style2" colspan="4" style="text-align: left" >&nbsp;
    <asp:Label ID="lblTotRevenue" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
</tr>
<tr>
<td class="style2" colspan="6" >&nbsp;</td>
<td class="style2" colspan="4" style="text-align: left" >&nbsp;</td>
</tr>
<tr>
<td class="style5" colspan="3" >Comments:</td>
<td class="style4" colspan="7" >
    <br />
    <asp:Label ID="lblComments" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
</tr>
<tr>
<td  colspan="10" >&nbsp;</td>
</tr>
<tr>
<td  colspan="10" >
    <asp:GridView ID="dgDetails" runat="server" CaptionAlign="Left" 
        DataSourceID="dsDetail" EnableModelValidation="True" 
        onselectedindexchanged="dgDetails_SelectedIndexChanged" Width="100%">
        <HeaderStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" />
        <RowStyle HorizontalAlign="Left" />
    </asp:GridView>
    </td>
</tr>
<tr>
<td  colspan="10" >
    <asp:SqlDataSource ID="dsDetail" runat="server"></asp:SqlDataSource>
    </td>
</tr>
<tr>
<td class="style17" colspan="10" >
    &nbsp;</td>
</tr>
<tr>
<td class="style5" colspan="10" >
    <asp:Label ID="lblRoomBMessage" runat="server" style="font-weight: 700; color: #FF0000;" 
        Text="Text"></asp:Label>
    </td>
</tr>
<tr>
<td class="style5" colspan="10" >
    &nbsp;</td>
</tr>
<tr>
<td class="style21" colspan="2" >
    <asp:Label ID="lblConcessions" runat="server" style="font-weight: 700" 
        Text="Concessions:"></asp:Label>
    </td>
<td class="style2" colspan="3" >
    <asp:Label ID="lblCon" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style2" colspan="3" >
    <asp:Label ID="lblConQ" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style21" colspan="2" >
    &nbsp;</td>
</tr>
<tr>
<td class="style21" colspan="2" >
    &nbsp;</td>
<td class="style2" colspan="3" >
    <asp:Label ID="lblCon0" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style2" colspan="3" >
    <asp:Label ID="lblConQ0" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style21" colspan="2" >
    &nbsp;</td>
</tr>
<tr>
<td class="style21" colspan="2" >
    &nbsp;</td>
<td class="style2" colspan="3" >
    <asp:Label ID="lblCon1" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style2" colspan="3" >
    <asp:Label ID="lblConQ1" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style21" colspan="2" >
    &nbsp;</td>
</tr>
<tr>
<td class="style21" colspan="2" >
    &nbsp;</td>
<td class="style2" colspan="3" >
    <asp:Label ID="lblCon2" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style2" colspan="3" >
    <asp:Label ID="lblConQ2" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style21" colspan="2" >
    &nbsp;</td>
</tr>
<tr>
<td class="style21" colspan="2" >
    &nbsp;</td>
<td class="style2" colspan="3" >
    <asp:Label ID="lblCon3" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style2" colspan="3" >
    <asp:Label ID="lblConQ3" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style21" colspan="2" >
    &nbsp;</td>
</tr>
<tr>
<td class="style21" colspan="2" >
    &nbsp;</td>
<td class="style2" colspan="3" >
    <asp:Label ID="lblCon4" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style2" colspan="3" >
    <asp:Label ID="lblConQ4" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style21" colspan="2" >
    &nbsp;</td>
</tr>
<tr>
<td class="style21" colspan="2" >
    &nbsp;</td>
<td class="style2" colspan="3" >
    <asp:Label ID="lblCon5" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style2" colspan="3" >
    <asp:Label ID="lblConQ5" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style21" colspan="2" >
    &nbsp;</td>
</tr>
<tr>
<td class="style21" colspan="2" >
    &nbsp;</td>
<td class="style2" colspan="3" >
    <asp:Label ID="lblCon6" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style2" colspan="3" >
    <asp:Label ID="lblConQ6" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style21" colspan="2" >
    &nbsp;</td>
</tr>
<tr>
<td class="style21" colspan="2" >
    &nbsp;</td>
<td class="style2" colspan="3" >
    <asp:Label ID="lblCon7" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style2" colspan="3" >
    <asp:Label ID="lblConQ7" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style21" colspan="2" >
    &nbsp;</td>
</tr>
<tr>
<td class="style21" colspan="2" >
    &nbsp;</td>
<td class="style2" colspan="3" >
    <asp:Label ID="lblCon8" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style2" colspan="3" >
    <asp:Label ID="lblConQ8" runat="server" Text="Label" CssClass="style2"></asp:Label>
    </td>
<td class="style21" colspan="2" >
    &nbsp;</td>
</tr>
</table>




<asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>








