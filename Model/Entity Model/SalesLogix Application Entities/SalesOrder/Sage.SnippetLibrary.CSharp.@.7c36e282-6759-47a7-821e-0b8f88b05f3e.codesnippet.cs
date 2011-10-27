/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="7c36e282-6759-47a7-821e-0b8f88b05f3e">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>GetSalesOrdAnticDateStep</name>
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
        public static void GetSalesOrdAnticDateStep( ISalesOrder salesorder, out System.DateTime result)
        {
            // TODO: Complete business rule implementation]
			try{
			using (ISession session = new SessionScopeWrapper()) {
				DateTime fswon = System.DateTime.MinValue;
				if (salesorder!=null){
							if (!string.IsNullOrEmpty(salesorder.Id.ToString())){
								string sql = "select orderdate from salesorder where actual = 'F' and salesorderid='" + salesorder.Id.ToString() + "'";
								fswon = session.CreateSQLQuery(sql).UniqueResult<DateTime>();								
							}
				}
				
				if (!string.IsNullOrEmpty(fswon.ToString())){
				result = fswon;
				}
				else {
				result=System.DateTime.MinValue;	
				}
			}
			}			
			catch(Exception){ result=System.DateTime.MinValue;}
        }
    }
}
