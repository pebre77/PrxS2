/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="6638f6e2-d562-431e-9633-95211190354d">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>dtpDepartDate_OnChangeStep</name>
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
		public static void dtpDepartDate_OnChangeStep( IInsertOpportunity form,  EventArgs args) {
			DateTime dtDepartDate;	 
			Sage.Entity.Interfaces.IOpportunity objOpportunity = form.CurrentEntity as Sage.Entity.Interfaces.IOpportunity;	 	
			if (objOpportunity.OpportunityCIUDF.Main_departure_Date != null) {
				dtDepartDate = Convert.ToDateTime(objOpportunity.OpportunityCIUDF.Main_departure_Date);
				objOpportunity.OpportunityCIUDF.Main_departure_day = dtDepartDate.DayOfWeek.ToString();
			}		
		}		
    }
}