/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="018c5487-6a4d-4414-860a-b224726a4a3d">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>GetWonServiceRevStep</name>
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
	public static partial class CustfinancialBusinessRules
	{
		public static void GetWonServiceRevStep(ICustfinancial custfinancial, out System.Decimal result)
		{
			// TODO: Complete business rule implementation
			using (ISession session = new SessionScopeWrapper()) {
				string sql = "select sum(extendedprice) from opportunity_product where status='Execution' and opportunityid='" + custfinancial.Id.ToString() + "'";
				decimal fswon = session.CreateSQLQuery(sql).UniqueResult<decimal>();
				result = fswon;
			}
		}
	}
}
