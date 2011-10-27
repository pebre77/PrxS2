/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="f18b1167-51ae-4f42-bdbd-24cc2ba3df48">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>QFTextBox_OnChangeStep</name>
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
    public static partial class EditOpportunityProductEventHandlers
    {
      		
		// SSI JKL 09/30/2011
		// Fix Praxi issue...also, did not rename Praxi control b/c it may be referenced in code elsewhere...
		// When a user edits an Opportunity Service (Product) and changes the Status, the Close Probability must be updated according the chart in the Requirements Document under 103.5.0 circa page 401...
		public static void QFTextBox_OnChangeStep(IEditOpportunityProduct form,  EventArgs args) {		
			Sage.Entity.Interfaces.IOpportunityProduct objOpportunityProduct = form.CurrentEntity as Sage.Entity.Interfaces.IOpportunityProduct;
			if (objOpportunityProduct != null) {			
				switch (objOpportunityProduct.Status.ToString().ToUpper().Trim()) {		
					// Execution...		
					case "EXECUTION": 
						objOpportunityProduct.CloseProbability = 100;
						break;								
					// Early Shopping...		
					case "EARLY SHOPPING": 
						objOpportunityProduct.CloseProbability = 50;			
						break;								
					// Satisfaction...		
					case "SATISFACTION": 
						objOpportunityProduct.CloseProbability = 20;			
						break;								
					// Late Shopping...		
					case "LATE SHOPPING": 
						objOpportunityProduct.CloseProbability = 80;							
						break;								
					// Apprehension...		
					case "APPREHENSION": 
						objOpportunityProduct.CloseProbability = 95;							
						break;								
					// Closed - Lost...		
					case "CLOSED - LOST": 
						objOpportunityProduct.CloseProbability = 0;							
						break;																			 																														
				}
				objOpportunityProduct.Save();					
			}	
		}		
    }
}