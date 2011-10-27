/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="9b3c8ef4-411f-432d-bc04-83edf5772f76">
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
    public static partial class OpportunityProductBusinessRules
    {
        public static void ValidateSalesOrderStep( IOpportunityProduct opportunityproduct, out Boolean result)
        {
            // TODO: Complete business rule implementation
			result = false;
			
			using (ISession session = new SessionScopeWrapper()) {
				string strSQL = "select count(*) from salesorderdetail where productid ='"+opportunityproduct.Product.Id.ToString()+"' and salesorderid in  (select salesorderid from salesorder where Actual = 'F' and Opportunityid='"+opportunityproduct.Opportunity.Id.ToString()+"')";
				int salesorder = session.CreateSQLQuery(strSQL).UniqueResult<int>();
				if (salesorder > 0) {				
					result = true;
				}
			}
        }
    }
}
