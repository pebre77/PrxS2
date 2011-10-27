/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="b4ee69c4-4f00-40ab-901c-1b2f1e5697c6">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>CreateSalesOrderStep</name>
 <references>
  <reference>
   <assemblyName>Sage.Entity.Interfaces.dll</assemblyName>
   <hintPath>%BASEBUILDPATH%\interfaces\bin\Sage.Entity.Interfaces.dll</hintPath>
  </reference>
  <reference>
   <assemblyName>Sage.Form.Interfaces.dll</assemblyName>
   <hintPath>%BASEBUILDPATH%\formInterfaces\bin\Sage.Form.Interfaces.dll</hintPath>
  </reference>
  <reference>
   <assemblyName>Sage.Platform.dll</assemblyName>
   <hintPath>%BASEBUILDPATH%\assemblies\Sage.Platform.dll</hintPath>
  </reference>
  <reference>
   <assemblyName>Sage.SalesLogix.API.dll</assemblyName>
  </reference>
 </references>
</snippetHeader>
*/


#region Usings
using System;
using Sage.Entity.Interfaces;
using Sage.Form.Interfaces;
using Sage.SalesLogix.API;
using NHibernate;
using Sage.Platform.Orm;

#endregion Usings

namespace Sage.BusinessRules.CodeSnippets
{
    public static partial class OpportunityProductBusinessRules
    {
        public static void CreateSalesOrderStep( IOpportunityProduct opportunityproduct)
        {
            // TODO: Complete business rule implementation
			ISession session = new SessionScopeWrapper();
			string strSQL = "select max(documentid)+1 from salesorder where len(documentid)>5";
			int docid = session.CreateSQLQuery(strSQL).UniqueResult<int>();
			//--------	

			Sage.Entity.Interfaces.ISalesOrder saleso  =Sage.Platform.EntityFactory.Create<Sage.Entity.Interfaces.ISalesOrder>();
			Sage.Entity.Interfaces.ISalesorderdetail sodetail = Sage.Platform.EntityFactory.Create<Sage.Entity.Interfaces.ISalesorderdetail>();			
			try {
			
			saleso.Account = opportunityproduct.Opportunity.Account;
			saleso.Opportunity = opportunityproduct.Opportunity;
			
			if (opportunityproduct.ExtendedPrice!=null){	
			saleso.OrderTotal = (double) opportunityproduct.ExtendedPrice;
			} else {
			saleso.OrderTotal = 0;
			}
			
			if (opportunityproduct.ExtendedPrice!=null){
				saleso.Totalcommissionable = (double) opportunityproduct.ExtendedPrice;
			} else {
				saleso.Totalcommissionable = 0;
			}
			saleso.OrderType = "Regular Order" ;
			saleso.DocumentId = docid.ToString();
			saleso.Status = "Open Order";
			
			saleso.UserId = opportunityproduct.Opportunity.AccountManager.Id.ToString();
			if (opportunityproduct.Opportunity.OpportunityCIUDF.Accountmanagerid2!=null){
			saleso.UserID2 = opportunityproduct.Opportunity.OpportunityCIUDF.Accountmanagerid2.ToString();
			 }
			saleso.Owner   = opportunityproduct.Opportunity.Owner;			
			if (opportunityproduct.Product.Family.ToString().Trim()=="FAMCLI"){
				saleso.BillToName = opportunityproduct.Opportunity.Account.AccountName;
				saleso.Billtoaccount = opportunityproduct.Opportunity.Account.Id.ToString();
				strSQL = "select contactid from contact where accountid='"+opportunityproduct.Opportunity.Account.Id.ToString()+"' and isprimary='T'";
				saleso.Billtocontact = session.CreateSQLQuery(strSQL).UniqueResult<string>();
			}
			saleso.Actual=false;
			}
			catch 
			{
				throw new Sage.Platform.Application.ValidationException("Sales Order Information Incomplete. Please Check that this Opportunity have a Primary Contact Related.");

			}
			
			try {

			
			sodetail.SalesOrder = saleso;
			sodetail.ProductId = opportunityproduct.Product.Id.ToString();
			
			if (opportunityproduct.OpportunityProductCI.Other_fees!=null || opportunityproduct.OpportunityProductCI.Other_fees>0)
			{
				//
				//sodetail.Num2 = (short)opportunityproduct.OpportunityProductCI.Num2;
				/*sodetail.Num3 = opportunityproduct.OpportunityProductCI.Num3;
				sodetail.Num4 = opportunityproduct.OpportunityProductCI.Num4;
				sodetail.Fees1 = opportunityproduct.OpportunityProductCI.Fees1;
				sodetail.Fees1Desc = opportunityproduct.OpportunityProductCI.Fees1Desc;
				sodetail.Fees2 = opportunityproduct.OpportunityProductCI.Fees2;
				sodetail.Fees2Desc = opportunityproduct.OpportunityProductCI.Fees2Desc;
				sodetail.Fees3 = opportunityproduct.OpportunityProductCI.Fees3;
				sodetail.Fees3Desc = opportunityproduct.OpportunityProductCI.Fees3Desc;
				sodetail.Fees4 = opportunityproduct.OpportunityProductCI.Fees4;
				sodetail.Fees4Desc = opportunityproduct.OpportunityProductCI.Fees4Desc;
				sodetail.Rate = opportunityproduct.OpportunityProductCI.Rate;
				sodetail.Rate2 = opportunityproduct.OpportunityProductCI.Rate2;
				sodetail.Rate3 = opportunityproduct.OpportunityProductCI.Rate3;
				sodetail.Rate4 = opportunityproduct.OpportunityProductCI.Rate4;	*/
				
				if (opportunityproduct.CalculatedPrice!=null){
				sodetail.Calcprice 		= (double)opportunityproduct.CalculatedPrice;
				}
				if (opportunityproduct.ExtendedPrice!=null){
					sodetail.Extendedprice 	= (double)opportunityproduct.ExtendedPrice;	
				}
				if (opportunityproduct.Price!=null){
					sodetail.Price 			= (double)opportunityproduct.Price;
				}
				if (opportunityproduct.OpportunityProductCI.Commission!=null){
					sodetail.Commission 	= opportunityproduct.OpportunityProductCI.Commission;
				}	
				if (opportunityproduct.OpportunityProductCI.Discount!=null){
					sodetail.Discount 		= opportunityproduct.OpportunityProductCI.Discount;
				}
				if (opportunityproduct.OpportunityProductCI.Onsite_fees!=null){
					sodetail.Onsite_fees 	= (decimal) opportunityproduct.OpportunityProductCI.Onsite_fees;
				}
				else
				{
					sodetail.Onsite_fees = 0;
				}
				
				
				if (opportunityproduct.OpportunityProductCI.Other_fees!=null){
					sodetail.Other_fees 	= (decimal) opportunityproduct.OpportunityProductCI.Other_fees;
				} 
				else {
					sodetail.Other_fees = 0;
				}
				if (opportunityproduct.OpportunityProductCI.Num!=null){
				sodetail.Num 			= opportunityproduct.OpportunityProductCI.Num;
				}
			}
			
			saleso.OrderDate = DateTime.Now;
			saleso.Salesorderdetails.Add(sodetail);
			saleso.Save();
			} //End Try
			catch 
			{
				throw new Sage.Platform.Application.ValidationException("Creation Process not completed. Please Check that this Opportunity have a Primary Contact Related.");

			}
        }
    }
}
