/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="4aef644b-2575-4265-a4d4-9e4aa92ed8d4">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>GetPrimaryContactAddressStep</name>
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
        public static void GetPrimaryContactAddressStep( ICustevent custevent, out System.String result)
        {
            // TODO: Complete business rule implementation
			using (ISession session = new SessionScopeWrapper())
			{
				string sql = "select top 1 a.address1  from sysdba.opportunity_contact oc left join sysdba.contact c on oc.contactid=c.contactid left join sysdba.address a on a.entityid=c.contactid where oc.isprimary='T' and a.isprimary='T' and opportunityid='"+custevent.Id.ToString()+"'";
				string add1 = session.CreateSQLQuery(sql).UniqueResult<string>();
				
				sql = "select top 1 a.address2  from sysdba.opportunity_contact oc left join sysdba.contact c on oc.contactid=c.contactid left join sysdba.address a on a.entityid=c.contactid where oc.isprimary='T' and a.isprimary='T' and opportunityid='"+custevent.Id.ToString()+"'";
				string add2 = session.CreateSQLQuery(sql).UniqueResult<string>();
				
				sql = "select top 1 a.city  from sysdba.opportunity_contact oc left join sysdba.contact c on oc.contactid=c.contactid left join sysdba.address a on a.entityid=c.contactid where oc.isprimary='T' and a.isprimary='T' and opportunityid='"+custevent.Id.ToString()+"'";
				string city = session.CreateSQLQuery(sql).UniqueResult<string>();
				
				sql = "select top 1 a.state  from sysdba.opportunity_contact oc left join sysdba.contact c on oc.contactid=c.contactid left join sysdba.address a on a.entityid=c.contactid where oc.isprimary='T' and a.isprimary='T' and opportunityid='"+custevent.Id.ToString()+"'";
				string state = session.CreateSQLQuery(sql).UniqueResult<string>();
				
				sql = "select top 1 a.postalcode  from sysdba.opportunity_contact oc left join sysdba.contact c on oc.contactid=c.contactid left join sysdba.address a on a.entityid=c.contactid where oc.isprimary='T' and a.isprimary='T' and opportunityid='"+custevent.Id.ToString()+"'";
				string pcode = session.CreateSQLQuery(sql).UniqueResult<string>();
				
				sql = "select top 1 a.country  from sysdba.opportunity_contact oc left join sysdba.contact c on oc.contactid=c.contactid left join sysdba.address a on a.entityid=c.contactid where oc.isprimary='T' and a.isprimary='T' and opportunityid='"+custevent.Id.ToString()+"'";
				string country = session.CreateSQLQuery(sql).UniqueResult<string>();
				
				
				string fswon = string.Concat(add1," ",add2," ",city,", ",state," ",pcode," ",country);
				result=fswon;
			}
        }
    }
}