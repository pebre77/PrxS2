/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="c8e35097-63a0-40e0-b070-27028c1f645e">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>GetSalesOrdAnticRevStep</name>
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
		public static void GetSalesOrdAnticRevStep(ISalesOrder salesorder, out System.Double result)
		{
			// TODO: Complete business rule implementation
			try{
			using (ISession session = new SessionScopeWrapper()) {
				double fswon=0;
				if (salesorder!=null){
							if (!string.IsNullOrEmpty(salesorder.Id.ToString())){
								string sql = "select ordertotal from salesorder where Actual='F' and salesorderid='" + salesorder.Id.ToString() + "'";
								fswon = session.CreateSQLQuery(sql).UniqueResult<double>();
							}
				}
				
				if (!string.IsNullOrEmpty(fswon.ToString())){
				result = fswon;
				} else {
				result = 0;
				}
			}
			} catch(Exception) {result=0;}
		}
	}
}
