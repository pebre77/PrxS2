/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="4576903e-61a8-4d17-a257-1612cee5c6a0">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>GetActualFSalesOrdersStep</name>
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
using Sage.Platform.Repository;
using Sage.Platform;
#endregion Usings

namespace Sage.BusinessRules.CodeSnippets
{
    public static partial class CustfinancialBusinessRules
    {
        public static void GetActualFSalesOrdersStep( ICustfinancial custfinancial, out object result)
        {
			
            Sage.Platform.Repository.IRepository<ISalesOrder> rep = EntityFactory.GetRepository<ISalesOrder>();
			IQueryable qry = (IQueryable)rep;
			
			IExpressionFactory ef = qry.GetExpressionFactory();
			
			ICriteria criteria = qry.CreateCriteria();
			criteria.Add(ef.Eq("Custfinancial",custfinancial));
			criteria.Add(ef.Eq("Actual",false));
			result = criteria.List<ISalesOrder>();
			
        }
    }
}