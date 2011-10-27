/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="d956e77a-6a36-4eb7-97f5-166d87a314da">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>ConvertionButtonStep</name>
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
  <reference>
   <assemblyName>Sage.SalesLogix.Security.dll</assemblyName>
   <hintPath>%BASEBUILDPATH%\assemblies\Sage.SalesLogix.Security.dll</hintPath>
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
using Sage.Platform;
using Sage.SalesLogix.Security;

using NHibernate;
#endregion Usings

namespace Sage.BusinessRules.CodeSnippets
{
    public static partial class OpportunityProductBusinessRules
    {
        public static void ConvertionButtonStep( IOpportunityProduct opportunityproduct, out Boolean result)
        {
            // TODO: Complete business rule implementation
			Sage.SalesLogix.Security.SLXUserService usersvc = (Sage.SalesLogix.Security.SLXUserService)Sage.Platform.Application.ApplicationContext.Current.Services.Get<Sage.Platform.Security.IUserService>();
			Sage.Entity.Interfaces.IUser user = usersvc.GetUser();			
			int team =0;
			using (NHibernate.ISession session = new Sage.Platform.Orm.SessionScopeWrapper())
    		{
        		string sql = "select count(*) from seccodejoins sj join seccode s on s.seccodeid=sj.parentseccodeid where sj.childseccodeid in (select defaultseccodeid from usersecurity where userid='"+user.Id.ToString()+"') and s.seccodetype='G' and s.seccodedesc='Training'";
				team = session.CreateSQLQuery(sql).UniqueResult<int>();			
			}
			
			
			if (team>0 || user.Id.ToString().Trim()=="ADMIN"){
				result=true;}
			else{
				result=false;}
        }
		
    }
}
