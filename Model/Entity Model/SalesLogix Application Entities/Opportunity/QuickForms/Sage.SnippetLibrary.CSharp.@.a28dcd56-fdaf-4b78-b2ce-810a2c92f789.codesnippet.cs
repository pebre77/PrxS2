/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="a28dcd56-fdaf-4b78-b2ce-810a2c92f789">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>dtpArrivalDate_OnChangeStep</name>
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
    public static partial class InsertOpportunityEventHandlers
    {
		// SSI JKL 10/03/2011
		// Fix Praxi issue of Arrival Day and Departure Day are not being computed...
		public static void dtpArrivalDate_OnChangeStep(IInsertOpportunity form,  EventArgs args) {
			DateTime dtArrivalDate;	 
			Sage.Entity.Interfaces.IOpportunity objOpportunity = form.CurrentEntity as Sage.Entity.Interfaces.IOpportunity;	 	
			if (objOpportunity.OpportunityCIUDF.Main_arrival_Date != null) {
				dtArrivalDate = Convert.ToDateTime(objOpportunity.OpportunityCIUDF.Main_arrival_Date);
				objOpportunity.OpportunityCIUDF.Main_arrival_day = dtArrivalDate.DayOfWeek.ToString();
			}		 	 	
		}		
    }
}