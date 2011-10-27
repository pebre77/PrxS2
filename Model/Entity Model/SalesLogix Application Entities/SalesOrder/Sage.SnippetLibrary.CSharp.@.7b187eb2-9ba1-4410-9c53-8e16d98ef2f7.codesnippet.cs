/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="7b187eb2-9ba1-4410-9c53-8e16d98ef2f7">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>GetSalesOrdActNoStep</name>
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
        public static void GetSalesOrdActNoStep( ISalesOrder salesorder, out System.String result)
        {
            // TODO: Complete business rule implementation
			try{		
			using (ISession session = new SessionScopeWrapper()){
				string fswon=string.Empty;	
				if (salesorder!=null){
							if (!string.IsNullOrEmpty(salesorder.Id.ToString())){
    								string sql = "select top 1 documentid from salesorder where actual = 'T' and anticipatedid='"+salesorder.Id.ToString()+"'";
    								fswon = session.CreateSQLQuery(sql).UniqueResult<string>();    								
							}
				}
				
				if (!string.IsNullOrEmpty(fswon)){
					result=fswon;
				} else {
					result = "-";
				}
   			}
			}				
			catch(Exception){result = "-";}
        }
    }
}
