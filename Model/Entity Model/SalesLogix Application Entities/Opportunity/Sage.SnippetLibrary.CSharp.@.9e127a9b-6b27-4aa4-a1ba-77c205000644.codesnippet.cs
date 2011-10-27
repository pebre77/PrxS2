/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="9e127a9b-6b27-4aa4-a1ba-77c205000644">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>ValidateSalesOrderStep</name>
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
    public static partial class OpportunityBusinessRules
    {
        public static void ValidateSalesOrderStep( IOpportunity opportunity, out Boolean result)
        {
            // TODO: Complete business rule implementation
			result = false;

			using (ISession session = new SessionScopeWrapper()) {
				string strSQL = "select count(*) from salesorder where accountid='"+opportunity.Account.Id.ToString()+"' and opportunityid='"+opportunity.Id.ToString()+"'";
				int salesorder = session.CreateSQLQuery(strSQL).UniqueResult<int>();
				if (salesorder > 0) {				
					result = true;
				}
			}
        }
    }
}
