/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="2a700cd2-d4c7-4183-ac83-659415302e6d">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>OnAfterInsertStep</name>
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
    public static partial class MeetingTeamBusinessRules
    {
        public static void OnAfterInsertStep( IMeetingTeam meetingteam)
        {
            // TODO: Complete business rule implementation
			Sage.Entity.Interfaces.IUserInfo useri = Sage.Platform.EntityFactory.GetRepository<Sage.Entity.Interfaces.IUserInfo>().FindFirstByProperty("Id", meetingteam.UserID.ToString());
			Sage.Entity.Interfaces.IAddress address = Sage.Platform.EntityFactory.GetRepository<Sage.Entity.Interfaces.IAddress>().FindFirstByProperty("Id", useri.AddressId.ToString());
			string add1 = address.City.ToString()+","+address.State.ToString();
			meetingteam.Division =  add1;
			meetingteam.Save();			
        }
    }
}