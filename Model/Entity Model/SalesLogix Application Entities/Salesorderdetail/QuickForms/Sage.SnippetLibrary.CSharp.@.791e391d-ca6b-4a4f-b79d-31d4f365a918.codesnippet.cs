/*
 * This metadata is used by the Sage platform.  Do not remove.
<snippetHeader xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="791e391d-ca6b-4a4f-b79d-31d4f365a918">
 <assembly>Sage.SnippetLibrary.CSharp</assembly>
 <name>txtAdj_OnChangeStep</name>
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
    public static partial class EditSalesOrderServicesEventHandlers
    {
        public static void txtAdj_OnChangeStep( IEditSalesOrderServices form,  EventArgs args)
        {            
			// SSI JKL 09/16/2011
			// Fix Praxi's issue: Add code to calculate Profit...
			Sage.Entity.Interfaces.ISalesorderdetail objSalesOrderDetail = form.CurrentEntity as Sage.Entity.Interfaces.ISalesorderdetail;	
			double dblCost = 0;
			double dblAdj = 0;			
			if (objSalesOrderDetail != null) {		
				if (!String.IsNullOrEmpty(form.txtCost.Text)) {
					dblCost = Convert.ToDouble(form.txtCost.Text);
				}
				if (!String.IsNullOrEmpty(form.txtAdj.Text)) {
					dblAdj = Convert.ToDouble(form.txtAdj.Text);
				}			
				objSalesOrderDetail.Profit = (dblCost + dblAdj);																	
			}			
        }
    }
}