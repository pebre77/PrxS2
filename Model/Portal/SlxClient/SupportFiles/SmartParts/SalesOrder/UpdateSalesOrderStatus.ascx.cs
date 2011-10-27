using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sage.Platform.Application.UI;
using Sage.Platform.Data;
using Sage.Platform.Security;
using Sage.Platform.WebPortal;
using Sage.SalesLogix.Client.GroupBuilder;
using System.Data.OleDb;
using Sage.Platform.ComponentModel;
using Sage.Platform.WebPortal.Services;
using Sage.Platform.Application;
using Sage.SalesLogix.BusinessRules;
using System.Xml;
using System.Reflection;
using NHibernate;


public partial class SmartParts_SalesOrder_UpdateSalesOrderStatus : UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataSource1.ProviderName = "System.Data.OleDb";
        SqlDataSource1.ConnectionString = ApplicationContext.Current.Services.Get<IDataService>().GetConnectionString();

        string MyCurrentUserID = BusinessRuleHelper.GetCurrentUser()﻿.Id.ToString();
        SqlDataSource1.SelectParameters["USERID"].DefaultValue = MyCurrentUserID;

        dsGroup.ProviderName = "System.Data.OleDb";
        dsGroup.ConnectionString = ApplicationContext.Current.Services.Get<IDataService>().GetConnectionString();

        pklTitle.PickListValue = string.Empty;
    }

    protected void lkpGroupName_TextChanged(object sender, EventArgs e)
    {
     
        GroupInfo groupInfo = GroupInfo.GetGroupInfo(lkpGroupName.SelectedValue);
        string WhereSQL = groupInfo.WhereSQL.Trim();
        string fromSQL = groupInfo.FromSQL.Trim();
        NHibernate.ISession session = new Sage.Platform.Orm.SessionScopeWrapper();
        string sql = string.Empty;
        if (string.IsNullOrEmpty(WhereSQL)){
            sql = "Select count(*) from "+fromSQL;}
        else {
            sql = "Select count(*) from "+fromSQL+" where " + WhereSQL + "";
        }
        int fswon = session.CreateSQLQuery(sql).UniqueResult<int>();
        txtNoSO.Text = fswon.ToString();

        
        pklTitle.PickListValue = string.Empty;

        string alias = string.Empty;
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.LoadXml(groupInfo.GroupXML);
        string selectSQL = ((XmlElement)xmldoc.GetElementsByTagName("selectsql")[0]).InnerText;
        XmlNodeList layoutNodes = xmldoc.GetElementsByTagName("layout");

            foreach (XmlElement node in layoutNodes)
        {
            XmlNodeList nAlias = node.GetElementsByTagName("caption");
            alias = nAlias[0].InnerText;
        }

            
            if (string.IsNullOrEmpty(WhereSQL))
            {
                sql = "Select "+selectSQL+" from " + fromSQL;
            }
            else
            {
                sql = "Select " + selectSQL + " from " + fromSQL + " where " + WhereSQL + "";
            }
            dsGroup.SelectCommand = sql;
            
        
    }
    protected void cmdUpdate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(pklTitle.PickListValue))
        {
            throw new Sage.Platform.Application.ValidationException("Status must be contain data");
        }
        else
        {
            GroupInfo groupInfo = GroupInfo.GetGroupInfo(lkpGroupName.SelectedValue);
            string WhereSQL = groupInfo.WhereSQL.Trim();
            string fromSQL = groupInfo.FromSQL.Trim();
            NHibernate.ISession session = new Sage.Platform.Orm.SessionScopeWrapper();
            string sql = string.Empty;
            if (string.IsNullOrEmpty(WhereSQL))
            {
                sql = "select distinct salesorderid from " + fromSQL;
            }
            else
            {
                sql = "select distinct salesorderid from " + fromSQL + " where " + WhereSQL + "";
            }
            System.Collections.IList test = session.CreateSQLQuery(sql).List();
            string ids = string.Empty;
            for (int i = 0; i < test.Count; ++i)
            {
                ids = "update salesorder set status='" + pklTitle.PickListValue.ToString().Trim() + "' where salesorderid='"+test[i].ToString() + "'";
                session.CreateSQLQuery(ids).ExecuteUpdate();
            }
            string alias = string.Empty;
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(groupInfo.GroupXML);
            string selectSQL = ((XmlElement)xmldoc.GetElementsByTagName("selectsql")[0]).InnerText;
            XmlNodeList layoutNodes = xmldoc.GetElementsByTagName("layout");

            foreach (XmlElement node in layoutNodes)
            {
                XmlNodeList nAlias = node.GetElementsByTagName("caption");
                alias = nAlias[0].InnerText;
            }


            if (string.IsNullOrEmpty(WhereSQL))
            {
                sql = "Select " + selectSQL + " from " + fromSQL;
            }
            else
            {
                sql = "Select " + selectSQL + " from " + fromSQL + " where " + WhereSQL + "";
            }
            dsGroup.SelectCommand = sql;
          
        }
    }
}