/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="82876f33-86a7-402a-8b48-30c92ac42c50">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>ValidateRequiredStep</name>
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
    public static partial class OpportunityProductBusinessRules
    {
        public static void ValidateRequiredStep( IOpportunityProduct opportunityproduct, out Boolean result)
        {
            // TODO: Complete business rule implementation
			bool validate=false;
			
			if (opportunityproduct.OpportunityProductCI.Won==true){	
			//PSG - FHV
			//Fix Issue: Default Status Value Change
			
				//opportunityproduct.Status="Apprehension";		
				if (string.IsNullOrEmpty(opportunityproduct.OpportunityProductCI.Reason)){				
					throw new Sage.Platform.Application.ValidationException("Reason is required");
				}
				
				if (string.IsNullOrEmpty(opportunityproduct.OpportunityProductCI.CompetitorReplaced)){
					throw new Sage.Platform.Application.ValidationException("Competitor Replaced is required");					
				}									
			}else{validate=true;}
			
			if (opportunityproduct.OpportunityProductCI.Lost==true){				
				if (string.IsNullOrEmpty(opportunityproduct.OpportunityProductCI.Reason)){				
					throw new Sage.Platform.Application.ValidationException("Reason is required");
				}
				
				if (string.IsNullOrEmpty(opportunityproduct.OpportunityProductCI.CompetitorReplaced)){
					throw new Sage.Platform.Application.ValidationException("Competitor Replaced is required");					
				}
			}
			else{validate=true;}
						
			// SSI JKL 10/03/2011
			// Fix Praxi issue: Validate Estimated Close control...			
			// Estimated Close...			
			if (opportunityproduct.EstimatedClose == null) {
				throw new Sage.Platform.Application.ValidationException("Estimated Close");					
			}			
			else {
				validate = true;
			}				
			
			result=validate;
        }
    }
}
