/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="9e211680-369d-4aa2-bb5a-151fb2e8e023">
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
using Sage.Platform.Orm;
using NHibernate;
#endregion Usings

namespace Sage.BusinessRules.CodeSnippets
{
    public static partial class CustfinancialBusinessRules
    {
        public static void GetInitialSalesRepStep( ICustfinancial custfinancial, out System.String result)
        {
			string fswon = string.Empty;
			try{
    	 	using (ISession session = new SessionScopeWrapper())
   				{
				
					if (!string.IsNullOrEmpty(custfinancial.Account.AccountConferon.InitialSalesRep.ToString()) || custfinancial.Account.AccountConferon.InitialSalesRep.ToString()!=null)
					{
    					string sql = "select username from userinfo where userid='"+custfinancial.Account.AccountConferon.InitialSalesRep.ToString()+"'";
    					fswon = session.CreateSQLQuery(sql).UniqueResult<string>();
						}
					}	
			}
			catch(Exception){				
			}
			result=fswon;
        }
    }
}