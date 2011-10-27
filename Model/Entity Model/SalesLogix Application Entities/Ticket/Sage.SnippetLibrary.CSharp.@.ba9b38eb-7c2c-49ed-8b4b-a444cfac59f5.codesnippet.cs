/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="ba9b38eb-7c2c-49ed-8b4b-a444cfac59f5">
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
    public static partial class TicketBusinessRules
    {
        public static void OnAfterUpdateStep( ITicket ticket)
        {
            // TODO: Complete business rule implementation
			   if (ticket.Area != null)
                {
					NHibernate.ISession session = new Sage.Platform.Orm.SessionScopeWrapper(); 
					string sql = "Select ownerid From ticketareaowner Where area = '"+ticket.Area+"'";
					string fswon = session.CreateSQLQuery(sql).UniqueResult<string>();
					string result = fswon;

					if (!string.IsNullOrEmpty(result)){
						ticket.AssignedTo = Sage.Platform.EntityFactory.GetRepository<Sage.Entity.Interfaces.ITicketAreaOwner>().FindFirstByProperty("Area", ticket.Area).AreaOwner;
					}	
				}
        }
    }
}