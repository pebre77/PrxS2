<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UpdateSalesOrderStatus.ascx.cs" Inherits="SmartParts_SalesOrder_UpdateSalesOrderStatus" %>
<%@ Register Assembly="Sage.SalesLogix.Web.Controls" Namespace="Sage.SalesLogix.Web.Controls.PickList" TagPrefix="SalesLogix" %>
<%@ Register Assembly="Sage.SalesLogix.Web.Controls" Namespace="Sage.SalesLogix.Web.Controls" TagPrefix="SalesLogix" %>
<%@ Register Assembly="Sage.SalesLogix.Web.Controls" Namespace="Sage.SalesLogix.Web.Controls.DependencyLookup" TagPrefix="SalesLogix" %>
<%@ Register Assembly="Sage.SalesLogix.Web.Controls" Namespace="Sage.SalesLogix.Web.Controls.Lookup" TagPrefix="SalesLogix" %>
<%@ Register Assembly="Sage.SalesLogix.HighLevelTypes" Namespace="Sage.SalesLogix.HighLevelTypes" TagPrefix="SalesLogix" %>
<div style="display:none"></div>
<table border="0" cellpadding="1" cellspacing="0" class="formtable">
         <col width="40%" />
            <col width="30%" />
			<col width="30%" />
<tr><td>
    <asp:Label ID="Label1" runat="server" AssociatedControlID="lkpGroupName" 
    Text="Group Name:" class=" lbl alignleft"></asp:Label>
    </td>
    <td>
      <asp:ListBox ID="lkpGroupName" runat="server" AutoPostBack="True" 
          DataSourceID="SqlDataSource1" DataTextField="NAME" DataValueField="PLUGINID" 
          ontextchanged="lkpGroupName_TextChanged"></asp:ListBox>
  </td>
  <td>&nbsp;</td>
  </tr>
<tr><td>
    <asp:Label ID="Label2" runat="server" Text="No. of Sales Orders Affected:" 
        AssociatedControlID="txtNoSO" class=" lbl alignleft"></asp:Label>
        </td>
    <td>
    <asp:TextBox ID="txtNoSO" runat="server" ReadOnly="True"></asp:TextBox>    
</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>
   <asp:Label ID="pklTitle_lbl" AssociatedControlID="pklTitle" runat="server" 
        Text="Sales Order Status:" class=" lbl alignleft"></asp:Label>
 </td>
    <td>
    <SalesLogix:PickListControl runat="server" ID="pklTitle" PickListId="kSYST0000387" PickListName="Sales Order Status" MustExistInList="false" AlphaSort="true"  class="textcontrol picklist"  />
	
  </td>
  <td align="left">
  <asp:Button ID="cmdUpdate" runat="server" CssClass="slxbutton" 
          onclick="cmdUpdate_Click" Text="Update" />
  </td>
  </tr>
  <tr>
  <td colspan="3">
      <SalesLogix:SlxGridView ID="GridView1" runat="server" AllowPaging="True"  
          DataSourceID="dsGroup" EnableModelValidation="True" CssClass="datagrid" 
          GridLines="None" CellPadding="4" RowStyle-CssClass="rowlt"
          SelectedRowStyle-CssClass="rowSelected" ShowEmptyTable="true" 
          EnableViewState="false" PagerStyle-CssClass="gridPager" 
          >
      </SalesLogix:SlxGridView>
      </td>
  </tr>
  </table>
<asp:SqlDataSource ID="SqlDataSource1" runat="server"       
    SelectCommand="SELECT [NAME], [PLUGINID], [DATA] FROM [PLUGIN] WHERE (([FAMILY] = ?) AND ([TYPE] = ?) AND ([USERID] = ?))">
    <SelectParameters>
        <asp:Parameter DefaultValue="SALESORDER" Name="FAMILY" Type="String" />
        <asp:Parameter DefaultValue="23" Name="TYPE" Type="Int32" />
        <asp:Parameter Name="USERID" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:SqlDataSource ID="dsGroup" runat="server"></asp:SqlDataSource>





