/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="07382060-c5bc-4c43-a8ed-1f507a8ef9cc">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>GetInitialSalesRepStep</name>
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
    public static partial class CustcontractBusinessRules
    {
        public static void GetInitialSalesRepStep( ICustcontract custcontract, out System.String result)
        {
            // TODO: Complete business rule implementation
			string fswon = string.Empty;
			try{
			using (ISession session = new SessionScopeWrapper())
			{
				string sql = "select username from userinfo where userid='"+custcontract.Account.AccountConferon.InitialSalesRep.ToString()+"'";
				fswon = session.CreateSQLQuery(sql).UniqueResult<string>();
			}
			}
			catch(Exception){				
			}
			result=fswon;
        }
    }
}
