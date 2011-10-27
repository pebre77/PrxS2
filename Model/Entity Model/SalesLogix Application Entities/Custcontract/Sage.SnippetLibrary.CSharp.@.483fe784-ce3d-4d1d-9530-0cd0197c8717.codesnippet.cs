/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="483fe784-ce3d-4d1d-9530-0cd0197c8717">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>GetFirstServiceWonStep</name>
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
    public static partial class CustcontractBusinessRules
    {
        public static void GetFirstServiceWonStep( ICustcontract custcontract, out System.DateTime result)
        {
            // TODO: Complete business rule implementation
			using (ISession session = new SessionScopeWrapper())
			{
				string sql = "select min(actualclose) from opportunity_product where status='Execution' and opportunityid='"+custcontract.Id.ToString()+"'";
				DateTime fswon = session.CreateSQLQuery(sql).UniqueResult<DateTime>();
				result=fswon;
			}
        }
    }
}