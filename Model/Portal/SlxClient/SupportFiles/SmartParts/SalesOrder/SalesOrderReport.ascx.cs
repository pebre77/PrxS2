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



public partial class SmartParts_SalesOrder_SalesOrderReport : UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {

        string vlabelSOGrid = "";
        string pSalesOrderId = Request.QueryString["entityId"];//(string)((WebPortalPage)Page).;
        NHibernate.ISession session = new Sage.Platform.Orm.SessionScopeWrapper();
        string sql = string.Empty;

        Sage.Entity.Interfaces.ISalesOrder saleso = Sage.Platform.EntityFactory.GetById<Sage.Entity.Interfaces.ISalesOrder>(pSalesOrderId);

        bool vtype = saleso.Actual.Value;

        if (vtype == true)
        {
            lblSalesOrderType.Text = "Actual Sales Order";
            lblTotRevenuelbl.Text  = "Total Actual Revenue";
            vlabelSOGrid = "Revenue";
        }
        else
        {
            lblSalesOrderType.Text = "Anticipated Sales Order";
            lblTotRevenuelbl.Text = "Total Anticipated Revenue";
            vlabelSOGrid = "Revenue";
        }

        //Meeting Id
        lblEventId.Text = saleso.Opportunity.OpportunityCIUDF.Meeting_Id.ToString();

        //Sales Order No
        lblSalesOrderNo.Text = saleso.DocumentId.ToString();

        //Event Name
        lblEventName.Text = saleso.Opportunity.Description.ToString();

        //Bill To Account
        if (saleso.Billtoaccount != null)
        {
            sql = "Select Account from Account where AccountID ='" + saleso.Billtoaccount.ToString() + "'";
            string vBillToAccount = session.CreateSQLQuery(sql).UniqueResult<string>();
            lblBillToAccount.Text = vBillToAccount;
        }
        else
        {
            lblBillToAccount.Text = "";
        }

        //Po No
        if (!string.IsNullOrEmpty(saleso.CustomerPurchaseOrderNumber))
        {
            lblPoNo.Text = saleso.CustomerPurchaseOrderNumber.ToString();
        }
        else
        {
            lblPoNo.Text = "";
        }
        //Project ID
        if (string.IsNullOrEmpty(saleso.OriginaldocumentId))
        {
            lblProjectId.Text = "";
        }
        else
        {
          lblProjectId.Text = saleso.OriginaldocumentId.ToString();
        }

        //Account Name
        lblAccountName.Text = saleso.Account.ToString();

        //Account Status
        lblAccountStatus.Text = saleso.Account.Status.ToString();

        //Main Arrival
        if (saleso.Opportunity.OpportunityCIUDF.Main_arrival_Date == null)
        {
            lblMainArrival.Text = "";
        }
        else
        {
            DateTime vMainArrival = saleso.Opportunity.OpportunityCIUDF.Main_arrival_Date.Value;
            lblMainArrival.Text = vMainArrival.ToShortDateString();
        }

        //Main Departure

        if (saleso.Opportunity.OpportunityCIUDF.Main_departure_Date == null)
        {
            lblMainDeparture.Text = "";
        }
        else
        {
            DateTime vMainDeparture = saleso.Opportunity.OpportunityCIUDF.Main_departure_Date.Value;
            lblMainDeparture.Text = vMainDeparture.ToShortDateString();
        }


     //Client Account Section
        //Cust NO
        sql = "Select AccountingSystemId from AccountingInfo where AccountID ='" + saleso.Account.Id.ToString() + "'";
        string vCustNoCA = session.CreateSQLQuery(sql).UniqueResult<string>();
        lblCustNoCA.Text = vCustNoCA;

        //Name
        sql = "Select Account from Account where AccountID  ='" + saleso.Account.Id.ToString() + "'";
        string vNameCA = session.CreateSQLQuery(sql).UniqueResult<string>();
        lblNameCA.Text = vNameCA;

        //Address
        sql = "Select Address1 from Address where EntityId ='" + saleso.Account.Id.ToString() + "'";
        string vAddressCA = session.CreateSQLQuery(sql).UniqueResult<string>();
        lblAddressCA.Text = vAddressCA;

        sql = "Select Address2 from Address where EntityId ='" + saleso.Account.Id.ToString() + "'";
        string vAddress2CA = session.CreateSQLQuery(sql).UniqueResult<string>();
        lblAddress2CA.Text = vAddress2CA;

        sql = "Select Address3 from Address where EntityId ='" + saleso.Account.Id.ToString() + "'";
        string vAddress3CA = session.CreateSQLQuery(sql).UniqueResult<string>();
        lblAddress3CA.Text = vAddress3CA;

        sql = "Select State from Address where EntityId ='" + saleso.Account.Id.ToString() + "'";
        string vAddress4CA = session.CreateSQLQuery(sql).UniqueResult<string>();
        lblAddress4CA.Text = vAddress4CA;

        sql = "Select ', '+PostalCode from Address where EntityId ='" + saleso.Account.Id.ToString() + "'";
        string vAddress5CA = session.CreateSQLQuery(sql).UniqueResult<string>();
        lblAddress5CA.Text = vAddress5CA;



        //Phone
        sql = "Select MainPhone from Account where AccountID ='" + saleso.Account.Id.ToString() + "'";
        string vPhoneCA = session.CreateSQLQuery(sql).UniqueResult<string>();
        lblPhoneCA.Text = vPhoneCA;

        //Fax
        sql = "Select Fax from Account where AccountID ='" + saleso.Account.Id.ToString() + "'";
        string vFaxCA = session.CreateSQLQuery(sql).UniqueResult<string>();
        lblFaxCA.Text = vFaxCA;

        if (saleso.Billtocontact != null)
        {
            //Contact
            sql = "Select FirstName+' '+lastname from Contact where ContactID ='" + saleso.Billtocontact.ToString() + "'";
            string vContactCA = session.CreateSQLQuery(sql).UniqueResult<string>();
            lblContactCA.Text = vContactCA;

            //Bill to Account Section
            //Cust NO
            sql = "Select AccountingSystemId from AccountingInfo where AccountID ='" + saleso.Billtoaccount.ToString() + "'";
            string vCustNoBA = session.CreateSQLQuery(sql).UniqueResult<string>();
            lblCustNoBA.Text = vCustNoBA;

            //Name
            sql = "Select Account from Account where AccountID  ='" + saleso.Billtoaccount.ToString() + "'";
            string vNameBA = session.CreateSQLQuery(sql).UniqueResult<string>();
            lblNameBA.Text = vNameBA;

            //Address
            sql = "Select Address1 from Address where EntityId ='" + saleso.Billtoaccount.ToString() + "'";
            string vAddressBA = session.CreateSQLQuery(sql).UniqueResult<string>();
            lblAddressBA.Text = vAddressBA;

            sql = "Select Address2 from Address where EntityId ='" + saleso.Account.Id.ToString() + "'";
            string vAddress2BA = session.CreateSQLQuery(sql).UniqueResult<string>();
            lblAddress2BA.Text = vAddress2BA;

            sql = "Select Address3 from Address where EntityId ='" + saleso.Billtoaccount.ToString() + "'";
            string vAddress3BA = session.CreateSQLQuery(sql).UniqueResult<string>();
            lblAddress3BA.Text = vAddress3BA;

            sql = "Select State from Address where EntityId ='" + saleso.Billtoaccount.ToString() + "'";
            string vAddress4BA = session.CreateSQLQuery(sql).UniqueResult<string>();
            lblAddress4BA.Text = vAddress4BA;

            sql = "Select ', '+PostalCode from Address where EntityId ='" + saleso.Billtoaccount.ToString() + "'";
            string vAddress5BA = session.CreateSQLQuery(sql).UniqueResult<string>();
            lblAddress5BA.Text = vAddress5BA;

            //Contact
            sql = "Select FirstName+' '+lastname from Contact where ContactID  ='" + saleso.Billtocontact.ToString() + "'";
            string vContactBA = session.CreateSQLQuery(sql).UniqueResult<string>();
            lblContactBA.Text = vContactBA;
        }
        else 
        {
            lblContactCA.Text = "";
            lblCustNoBA.Text = "";
            lblNameBA.Text = "";
            lblAddressBA.Text = "";
            lblAddress2BA.Text = "";
            lblAddress3BA.Text = "";
            lblAddress4BA.Text = "";
            lblAddress5BA.Text = "";
            lblContactBA.Text = "";
        }
        //Phone

        if (saleso.Billtoaccount != null)
        {
            sql = "Select MainPhone from Account where AccountID ='" + saleso.Billtoaccount.ToString() + "'";
            string vPhoneBA = session.CreateSQLQuery(sql).UniqueResult<string>();
            lblPhoneBA.Text = vPhoneBA;

            //Fax
            sql = "Select Fax from Account where AccountID ='" + saleso.Billtoaccount.ToString() + "'";
            string vFaxBA = session.CreateSQLQuery(sql).UniqueResult<string>();
            lblFaxBA.Text = vFaxBA;
        }
        else
        {
            lblPhoneBA.Text = "";
            lblFaxBA.Text = "";
        }


    //Sales Order Section
        //Account Owner
        lblAccountOwner.Text = saleso.Account.AccountManager.ToString();

        //Order Owner
        lblOrderOwner.Text = saleso.Opportunity.AccountManager.ToString();

        if (saleso.SalesCommission != null)
        {
            lblOrderOwnerComm.Text = saleso.SalesCommission.ToString();
            lblRoomComm.Text = saleso.SalesCommission.ToString();
        }
        else
        {
            lblOrderOwnerComm.Text = "";
            lblRoomComm.Text = "";
        }

        //Sec Owner
        if (saleso.UserID2 != null)
        {
            sql = "Select username from UserInfo where UserId ='" + saleso.UserID2.ToString() + "'";
            string vSecOwner = session.CreateSQLQuery(sql).UniqueResult<string>();
            lblSecOwner.Text = vSecOwner;
        }
        else {
            lblSecOwner.Text = "";
        }

        if (saleso.Salescommission2 != null){ 
        lblSecOwnerComm.Text  = saleso.Salescommission2.ToString();
        } else 
        {
            lblSecOwnerComm.Text  = "";
        }

        //Addtl Owner
        if (saleso.UserID3 != null)
        {
            sql = "Select username from UserInfo where UserId ='" + saleso.UserID3.ToString() + "'";
            string vAddlOwner = session.CreateSQLQuery(sql).UniqueResult<string>();
            lblAddlOwner.Text = vAddlOwner;
        }
        else
        {
            lblAddlOwner.Text = "";
        }

        //Mem
        if (saleso.MEM != null)
        {
            lblMem.Text = saleso.MEM.ToString();
        }
        else
        {
            lblMem.Text = "";
        }

        //Market
        if (saleso.Account.AccountConferon.Market != null)
        {
            lblMarket.Text = saleso.Account.AccountConferon.Market.ToString();
        }
        else
        {
            lblMarket.Text = "";
        }

        //Comments
        if (saleso.Comments != null)
        {
            lblComments.Text = saleso.Comments.ToString();
        }
        else
        {
            lblComments.Text = "";
        }

        //Domains
        if (saleso.Opportunity.Owner.OwnerDescription != null)
        {
            lblDomain.Text = saleso.Opportunity.Owner.OwnerDescription.ToString();
        }
        else
        {
            lblDomain.Text = "";
        }

        //Drop Off%
        if (saleso.Discount != null)
        {
            lblDropOff.Text = saleso.Discount.ToString();
        }
        else
        {
            lblDropOff.Text = "";
        }

        //Compare Date
        

        //Total Revenue
        if (saleso.OrderTotal != null)
        {
            lblTotRevenue.Text = string.Format("{0:C}",saleso.OrderTotal);
        }
        else {
            lblTotRevenue.Text = "0.00";
        }

        //Detail grid
        dsDetail.ProviderName = "System.Data.OleDb";
        dsDetail.ConnectionString = ApplicationContext.Current.Services.Get<IDataService>().GetConnectionString();

        dsDetail.SelectCommand = "select p.name Service,s.Num Quantity,'$'+CONVERT(VARCHAR,CONVERT(MONEY,s.rate),1) Rate,'$'+CONVERT(VARCHAR,CONVERT(MONEY,s.extendedprice),1) " + vlabelSOGrid + " from salesorderdetail s,product p where s.productid = p.productid and s.salesorderid = '" + saleso.Id.ToString() + "'";
        
        //Roomblock Section
        sql = "select count(*) from salesorderdetail s,product p where s.productid = p.productid and name = 'Hotel Commissions' and s.salesorderid  ='" + saleso.Id.ToString() + "'";
        int vcount = session.CreateSQLQuery(sql).UniqueResult<int>();
        
        if (vcount>0){  //Exists Hotel Commissions
            lblRoomBMessage.Text  = "Roomblock";
            lblConcessions.Text = "Concessions:";

            if (saleso.Concessions.Con1 != null)
            {
                lblCon.Text = saleso.Concessions.Con1.ToString();
            }
            else
            {
                lblCon.Text = "";
            }

            if (saleso.Concessions.Con2 != null)
            {
                lblCon0.Text = saleso.Concessions.Con2.ToString();
            }
            else
            {
                lblCon0.Text = "";
            }

            if (saleso.Concessions.Con3 != null)
            {
                lblCon1.Text = saleso.Concessions.Con3.ToString();
            }
            else
            {
                lblCon1.Text = "";
            }

            if (saleso.Concessions.Con4 != null)
            {
                lblCon2.Text = saleso.Concessions.Con4.ToString();
            }
            else
            {
                lblCon2.Text = "";
            }

            if (saleso.Concessions.Con5 != null)
            {
                lblCon3.Text = saleso.Concessions.Con5.ToString();
            }
            else
            {
                lblCon3.Text = "";
            }

            if (saleso.Concessions.Con6 != null)
            {
                lblCon4.Text = saleso.Concessions.Con6.ToString();
            }
            else
            {
                lblCon4.Text = "";
            }

            if (saleso.Concessions.Con7 != null)
            {
                lblCon5.Text = saleso.Concessions.Con7.ToString();
            }
            else
            {
                lblCon5.Text = "";
            }

            if (saleso.Concessions.Con8 != null)
            {
                lblCon6.Text = saleso.Concessions.Con8.ToString();
            }
            else
            {
                lblCon6.Text = "";
            }

            if (saleso.Concessions.Con9 != null)
            {
                lblCon7.Text = saleso.Concessions.Con9.ToString();
            }
            else
            {
                lblCon7.Text = "";
            }

            if (saleso.Concessions.Con10 != null)
            {
                lblCon8.Text = saleso.Concessions.Con10.ToString();
            }
            else
            {
                lblCon8.Text = "";
            }


            if (saleso.Concessions.Qty1 != null)
            {
                lblConQ.Text = saleso.Concessions.Qty1.ToString();
            }
            else
            {
                lblConQ.Text = "";
            }

            if (saleso.Concessions.Qty2 != null)
            {
                lblConQ0.Text = saleso.Concessions.Qty2.ToString();
            }
            else
            {
                lblConQ0.Text = "";
            }

            if (saleso.Concessions.Qty3 != null)
            {
                lblConQ1.Text = saleso.Concessions.Qty3.ToString();
            }
            else
            {
                lblConQ1.Text = "";
            }

            if (saleso.Concessions.Qty4 != null)
            {
                lblConQ2.Text = saleso.Concessions.Qty4.ToString();
            }
            else
            {
                lblConQ2.Text = "";
            }

            if (saleso.Concessions.Qty5 != null)
            {
                lblConQ3.Text = saleso.Concessions.Qty5.ToString();
            }
            else
            {
                lblConQ3.Text = "";
            }

            if (saleso.Concessions.Qty6 != null)
            {
                lblConQ4.Text = saleso.Concessions.Qty6.ToString();
            }
            else
            {
                lblConQ4.Text = "";
            }

            if (saleso.Concessions.Qty7 != null)
            {
                lblConQ5.Text = saleso.Concessions.Qty7.ToString();
            }
            else
            {
                lblConQ5.Text = "";
            }

            if (saleso.Concessions.Qty8 != null)
            {
                lblConQ6.Text = saleso.Concessions.Qty8.ToString();
            }
            else
            {
                lblConQ6.Text = "";
            }

            if (saleso.Concessions.Qty9 != null)
            {
                lblConQ7.Text = saleso.Concessions.Qty9.ToString();
            }
            else
            {
                lblConQ7.Text = "";
            }

            if (saleso.Concessions.Qty10 != null)
            {
                lblConQ8.Text = saleso.Concessions.Qty10.ToString();
            }
            else
            {
                lblConQ8.Text = "";
            } 


        } else {
            lblRoomBMessage.Text = "You won't see a Room Block or Concessions unless you are entering a HOTEL COMMISSIONS type service";
            lblConcessions.Visible = false;
            lblConQ.Visible = false;
            lblConQ0.Visible = false;
            lblConQ1.Visible = false;
            lblConQ2.Visible = false;
            lblConQ3.Visible = false;
            lblConQ4.Visible = false;
            lblConQ5.Visible = false;
            lblConQ6.Visible = false;
            lblConQ7.Visible = false;
            lblConQ8.Visible = false;
            lblCon.Visible = false;
            lblCon0.Visible = false;
            lblCon1.Visible = false;
            lblCon2.Visible = false;
            lblCon3.Visible = false;
            lblCon4.Visible = false;
            lblCon5.Visible = false;
            lblCon6.Visible = false;
            lblCon7.Visible = false;
            lblCon8.Visible = false;
        }

        
    }


    protected void dgDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}