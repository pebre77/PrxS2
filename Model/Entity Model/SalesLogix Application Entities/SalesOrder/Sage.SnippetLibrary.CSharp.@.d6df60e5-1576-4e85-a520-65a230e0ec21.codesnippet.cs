/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="d6df60e5-1576-4e85-a520-65a230e0ec21">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>GetCSAnticNoStep</name>
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
        public static void GetCSAnticNoStep( ISalesOrder salesorder, out System.String result)
        {
			
			try{		
				using (ISession session = new SessionScopeWrapper()){
					string fswon = string.Empty;
						if (salesorder!=null){
							if (!string.IsNullOrEmpty(salesorder.Id.ToString())){
    							string sql = "select documentid from salesorder where actual = 'F' and salesorderid='"+salesorder.Id.ToString()+"'";
    							fswon = session.CreateSQLQuery(sql).UniqueResult<string>();    							
							}
						}	
						if (!string.IsNullOrEmpty(fswon)){
							result=fswon;
						}
						else
						{
							result="-";
						}
   				}		
			} catch(Exception){ result="-";}
			
        }
    }
}
