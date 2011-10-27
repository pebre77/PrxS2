/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="f3ef013b-6b28-49d6-b322-243835289990">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>ValidateRequiredInsertStep</name>
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
#endregion Usings

namespace Sage.BusinessRules.CodeSnippets
{
    public static partial class OpportunityBusinessRules
    {
        public static void ValidateRequiredInsertStep( IOpportunity opportunity, out Boolean result)
        {
            // TODO: Complete business rule implementation
			bool validate = true;
							
				if (opportunity.AccountManager.ToString()==null || string.IsNullOrEmpty(opportunity.AccountManager.ToString())){
					validate = false;
					throw new Sage.Platform.Application.ValidationException("AccountManager is required.");
				}
				if (opportunity.OpportunityCIUDF.Main_arrival_Date.ToString()==null || string.IsNullOrEmpty(opportunity.OpportunityCIUDF.Main_arrival_Date.ToString())){
					validate = false;
					throw new Sage.Platform.Application.ValidationException("Main Arrival Date is required.");
				}
				
				if (opportunity.OpportunityCIUDF.Main_departure_Date.ToString()==null || string.IsNullOrEmpty(opportunity.OpportunityCIUDF.Main_departure_Date.ToString())){
					validate = false;
					throw new Sage.Platform.Application.ValidationException("Main Departure Date is required.");
				}
				
				if (opportunity.Owner==null ){
					validate = false;
					throw new Sage.Platform.Application.ValidationException("Sales Domain is required.");					
				}
				
				if (opportunity.Type==null || string.IsNullOrEmpty(opportunity.Type)){
					validate = false;
					throw new Sage.Platform.Application.ValidationException("Event Type is required.");
				}
				
				if (opportunity.OpportunityCIUDF.Frequency==null || string.IsNullOrEmpty(opportunity.OpportunityCIUDF.Frequency.ToString())){
					validate = false;
					throw new Sage.Platform.Application.ValidationException("Frequency is required.");
				}
				
				if (opportunity.LeadSource==null){
					validate = false;
					throw new Sage.Platform.Application.ValidationException("Opp. Lead Source is required.");
				}
															
				//if (opportunity.OpportunityCIUDF.FirstTimeEvent==false || string.IsNullOrEmpty(opportunity.OpportunityCIUDF.FirstTimeEvent.ToString())){				 				
				if (opportunity.OpportunityCIUDF.FirstTimeEvent==null) {
					validate = false;
					throw new Sage.Platform.Application.ValidationException("First Time Event is required.");
				}
				
				result=validate;
							
        }
    }
}
