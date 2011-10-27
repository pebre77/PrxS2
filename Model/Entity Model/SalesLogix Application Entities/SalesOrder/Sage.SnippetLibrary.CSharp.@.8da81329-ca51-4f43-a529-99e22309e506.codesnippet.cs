/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="8da81329-ca51-4f43-a529-99e22309e506">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>GetSalesOrdReceiptsStep</name>
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
    public static partial class SalesOrderBusinessRules
    {
        public static void GetSalesOrdReceiptsStep( ISalesOrder salesorder, out System.Decimal result)
        {
            // TODO: Complete business rule implementation
			try{
			using (ISession session = new SessionScopeWrapper()) {
				decimal fswon=0;
				if (salesorder!=null){
							if (!string.IsNullOrEmpty(salesorder.Id.ToString())){
									string sql = "select sum(amount) from receipts where salesorderid= (select top 1 salesorderid from salesorder where actual = 'T' and anticipatedid='" + salesorder.Id.ToString() + "')";
									fswon = session.CreateSQLQuery(sql).UniqueResult<decimal>();
							}
				}
				if (!string.IsNullOrEmpty(fswon.ToString())){
				result = fswon;
				} else {
				result = 0;
				}
			}
			}
			catch(Exception){result=0;}
        }
    }
}
