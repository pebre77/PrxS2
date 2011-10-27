/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="7f6f4ed3-e563-4d31-a9f8-acf78eb03e9c">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>OnAfterUpdateStep</name>
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
#endregion Usings

namespace Sage.BusinessRules.CodeSnippets
{
    public static partial class SalesOrderBusinessRules
    {
        public static void OnAfterUpdateStep( ISalesOrder salesorder)
        {
            // TODO: Complete business rule implementation
				if ((salesorder.Actual==false || salesorder.Actual==null) && salesorder.Account.Status!="Active Client" && salesorder.Status=="Accepted Order"){
					using (NHibernate.ISession session = new Sage.Platform.Orm.SessionScopeWrapper()){
						string sql = "update Account set Status='Active Client' where AccountId='"+salesorder.Account.Id.ToString()+"'";
						session.CreateQuery(sql)
						.ExecuteUpdate();
					}
				}
				
				if ((salesorder.Actual==false || salesorder.Actual==null) && salesorder.Account.Status!="Active Client" && salesorder.Status=="Accepted Order" && salesorder.Account.AccountConferon.Clientsince==null){
					using (NHibernate.ISession session = new Sage.Platform.Orm.SessionScopeWrapper()){
						string sql = "update AccountConferon set Clientsince='"+DateTime.Now+"' where AccountId='"+salesorder.Account.Id.ToString()+"'";
						session.CreateQuery(sql)
						.ExecuteUpdate();
					}
				}
				
				
        }
    }
}