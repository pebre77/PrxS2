/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="b89c5117-0a34-430c-975a-411f51ea4ef6">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>GetPrimaryContactPhoneStep</name>
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
    public static partial class CusteventBusinessRules
    {
        public static void GetPrimaryContactPhoneStep( ICustevent custevent, out System.String result)
        {
            // TODO: Complete business rule implementation
			using (ISession session = new SessionScopeWrapper())
			{
				string sql = "select top 1 c.workphone from sysdba.opportunity_contact oc left join sysdba.contact c on oc.contactid=c.contactid where oc.isprimary='T' and opportunityid='"+custevent.Id.ToString()+"'";
				string fswon = session.CreateSQLQuery(sql).UniqueResult<string>();
				result=fswon;
			}
        }
    }
}