/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="f879929c-2935-4f35-9c00-c38b7f546281">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>DuplicateOpportunityStep</name>
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
using Sage.Platform;
#endregion Usings

namespace Sage.BusinessRules.CodeSnippets
{
    public static partial class OpportunityBusinessRules
    {
        public static void DuplicateOpportunityStep( IOpportunity opportunity)
        {
            // TODO: Complete business rule implementation
			IOpportunity opty = EntityFactory.Create<IOpportunity>();
			opty.Description 							= "Copy of "+opportunity.Description;
			opty.Account 								= opportunity.Account;
			opty.Closed									= false;
			opty.OpportunityCIUDF.Lost					= false;
			opty.OpportunityCIUDF.Cancelled				= false;
			opty.OpportunityCIUDF.FirstTimeEvent		= null;
			opty.CreateUser								= "ADMIN";
			opty.OpportunityCIUDF.CreateUser			= "ADMIN";		
			opty.Win 									= null;
			opty.EstimatedClose							= opportunity.EstimatedClose;
			opty.LeadSource								= opportunity.LeadSource;
			opty.AccountManager							= opportunity.AccountManager;
			opty.OpportunityCIUDF.Main_arrival_Date 	= opportunity.OpportunityCIUDF.Main_arrival_Date;
			opty.OpportunityCIUDF.Main_departure_Date 	= opportunity.OpportunityCIUDF.Main_departure_Date;
			opty.OpportunityCIUDF.Main_arrival_day 		= opportunity.OpportunityCIUDF.Main_arrival_day;
			opty.OpportunityCIUDF.Main_departure_day 	= opportunity.OpportunityCIUDF.Main_departure_day;
			opty.OpportunityCIUDF.Location 				= opportunity.OpportunityCIUDF.Location;
			opty.Owner									= opportunity.Owner;
			foreach(IOpportunityProduct op in opportunity.Products)
			{
				IOpportunityProduct opprd = EntityFactory.Create<IOpportunityProduct>();
				opprd.Opportunity			= opty;
				opprd.Product 				= op.Product;
				opprd.Price					= op.Price;
				opprd.Status				= "Satisfaction";
				opprd.CloseProbability		= 20;
				opprd.CreateUser			= "ADMIN";				
				opprd.ExtendedPrice			= op.ExtendedPrice;
				opprd.PriceEffectiveDate	=	op.PriceEffectiveDate;
				opty.Products.Add(opprd);
			}
			opty.Save();				
        }
    }
}
