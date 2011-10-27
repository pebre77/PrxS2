/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="2fb12515-4dda-400b-8382-43c028b43761">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>ValidateCommissionStep</name>
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
using Sage.Platform.Orm;
using NHibernate;
#endregion Usings

namespace Sage.BusinessRules.CodeSnippets
{
	public static partial class OpportunityBusinessRules
	{
		public static void ValidateCommissionStep(IOpportunity opportunity, out Boolean result)
		{
			// TODO: Complete business rule implementation
			result = false;
			using (ISession session = new SessionScopeWrapper()) {
				string strSQL = "select count(*) from salesorder where salescommission>0 and salescommission2>0 and accountid='"+opportunity.Account.Id.ToString()+"' and opportunityid='"+opportunity.Id.ToString()+"'";
				int salesorder = session.CreateSQLQuery(strSQL).UniqueResult<int>();
				if (salesorder > 0) {				
					result = true;
				}
			}

		}
	}
}
