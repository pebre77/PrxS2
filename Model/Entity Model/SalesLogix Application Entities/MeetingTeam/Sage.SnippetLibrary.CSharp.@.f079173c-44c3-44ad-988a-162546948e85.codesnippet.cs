/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="f079173c-44c3-44ad-988a-162546948e85">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>GetMemberPhoneStep</name>
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
    public static partial class MeetingTeamBusinessRules
    {
        public static void GetMemberPhoneStep( IMeetingTeam meetingteam, out System.String result)
        {
            // TODO: Complete business rule implementation
			using (ISession session = new SessionScopeWrapper())
    		{
				string sql = "select phone from userinfo where userid='"+ meetingteam.UserID.ToString()+"'";
     		    result=session.CreateSQLQuery(sql).UniqueResult<string>();
    		}
        }
    }
}