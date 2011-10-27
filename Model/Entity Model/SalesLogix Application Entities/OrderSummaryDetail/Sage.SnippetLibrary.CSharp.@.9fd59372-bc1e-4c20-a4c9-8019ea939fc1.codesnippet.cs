/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="9fd59372-bc1e-4c20-a4c9-8019ea939fc1">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>GetProductName</name>
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
    public static partial class OrderSummaryDetailBusinessRules
    {
        public static void GetProductName( IOrderSummaryDetail ordersummarydetail, out System.String result)
        {
            using (ISession session = new SessionScopeWrapper())
			{
				string sql = "select description from product where productid='"+ordersummarydetail.Productid.ToString()+"'";
				string prodname = session.CreateSQLQuery(sql).UniqueResult<string>();
				result=prodname;
			}
        }
    }
}