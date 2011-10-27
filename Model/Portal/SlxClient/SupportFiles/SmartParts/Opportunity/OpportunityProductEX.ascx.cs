using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sage.Platform.Application;
using Sage.Platform.WebPortal.Services;
using Sage.Platform.WebPortal.SmartParts;
using Sage.Entity.Interfaces;
using Sage.SalesLogix;
using Sage.SalesLogix.Orm.Utility;
using Sage.SalesLogix.BusinessRules;

public partial class SmartParts_Opportunity_OpportunityProductEX : EntityBoundSmartPartInfoProvider
{
    private Sage.Platform.Security.IRoleSecurityService _roleSecurityService;
    [ServiceDependency]
    public Sage.Platform.Security.IRoleSecurityService RoleSecurityService
    {
        set
        {
            _roleSecurityService = Sage.Platform.Application.ApplicationContext.Current.Services.Get<Sage.Platform.Security.IRoleSecurityService>(true);
        }
        get
        {
            return _roleSecurityService;
        }
    }
    protected void grdProducts_RowCommand(object sender, GridViewCommandEventArgs e)
	{
        if (e.CommandName == "Page")
            return;

        int rowIndex;
        if (Int32.TryParse(e.CommandArgument.ToString(), out rowIndex))
        {
            dtsProducts.SelectedIndex = rowIndex;
            object currentEntity = dtsProducts.Current;
            if ((currentEntity is Sage.Platform.ComponentModel.ComponentView) && !((Sage.Platform.ComponentModel.ComponentView)currentEntity).IsVirtualComponent)
                currentEntity = ((Sage.Platform.ComponentModel.ComponentView)currentEntity).Component;
            string id = String.Empty;
            //Check if this is an unpersisted entity and use its InstanceId
            if (Sage.Platform.WebPortal.PortalUtil.ObjectIsNewEntity(currentEntity))
            {
                if (grdProducts.DataKeys[0].Values.Count > 1)
                {
                    foreach (DictionaryEntry val in grdProducts.DataKeys[rowIndex].Values)
                    {
                        if (val.Key.ToString() == "InstanceId")
                        {
                            Guid instanceId = (Guid)val.Value;
                            dtsProducts.SetCurrentEntityByInstanceId(instanceId);
                            id = instanceId.ToString();
                            currentEntity = dtsProducts.Current;
                            if ((currentEntity is Sage.Platform.ComponentModel.ComponentView) && !((Sage.Platform.ComponentModel.ComponentView)currentEntity).IsVirtualComponent)
                                currentEntity = ((Sage.Platform.ComponentModel.ComponentView)currentEntity).Component;
                        }
                    }
                }
            }
            else
            {
                if (grdProducts.DataKeys[0].Values.Count > 1)
                {
                    foreach (DictionaryEntry val in grdProducts.DataKeys[rowIndex].Values)
                    {
                        if (val.Key.ToString() != "InstanceId")
                        {
                            id = val.Value.ToString();
                        }
                    }
                }
            }		

            if (e.CommandName.Equals("Edit"))
            {
                if (DialogService != null)
                {
                    DialogService.SetSpecs(550, 800, "EditOpportunityProduct", HttpContext.GetLocalResourceObject(Request.Path,"EditOpportunityProduct.Title").ToString());
                    DialogService.EntityType = typeof (IOpportunityProduct);
                    DialogService.EntityID = id;
                    DialogService.ShowDialog();
                }
            }
			
			 if (e.CommandName.Equals("CreateSO"))
            {
                if (DialogService != null)
                {

                    try
                    {
						
                        string productid = this.grdProducts.DataKeys[grdProducts.SelectedIndex].Values["Id"].ToString();
                        Sage.Entity.Interfaces.IOpportunityProduct opportunityproduct = Sage.Platform.EntityFactory.GetRepository<Sage.Entity.Interfaces.IOpportunityProduct>().FindFirstByProperty("Id", productid);
                        if (opportunityproduct.Status != "Execution")
                        {
                            opportunityproduct.OpportunityProductCI.Won = true;
                            opportunityproduct.CloseProbability = 100;
                            opportunityproduct.Status = "Execution";
                            opportunityproduct.ActualClose = DateTime.Now;
                        }
						
						//DialogService.ShowMessage(opportunityproduct.Opportunity.Description);
                        //DialogService.SetSpecs(550, 800, "EditOpportunityProduct", HttpContext.GetLocalResourceObject(Request.Path,"EditOpportunityProduct.Title").ToString());
                        //DialogService.EntityType = typeof (IOpportunityProduct);
                        //DialogService.EntityID = id; 
                        //DialogService.ShowDialog();
                        //throw new Sage.Platform.Application.ValidationException(productid);				

                        using (NHibernate.ISession _session = new Sage.Platform.Orm.SessionScopeWrapper()){
							
                        string strSQL = "select max(documentid)+1 from salesorder where len(documentid)>5";
                        int docid = _session.CreateSQLQuery(strSQL).UniqueResult<int>();
						
												
                        //--------	
                        Sage.Entity.Interfaces.ISalesOrder saleso = Sage.Platform.EntityFactory.Create<Sage.Entity.Interfaces.ISalesOrder>();
                        if (opportunityproduct.Opportunity.Account!=null) {
						saleso.Account = opportunityproduct.Opportunity.Account;
						}
                        if (opportunityproduct.Opportunity!=null) {
						saleso.Opportunity = opportunityproduct.Opportunity;
						}
                        
						if (opportunityproduct.ExtendedPrice!=null){
						saleso.OrderTotal = (double)opportunityproduct.ExtendedPrice;
						} else
						{
						saleso.OrderTotal = 0;
						}
						
						if (opportunityproduct.ExtendedPrice!=null){
                        saleso.Totalcommissionable = (double)opportunityproduct.ExtendedPrice;
						} else {
						saleso.Totalcommissionable = 0;
						}

                        saleso.OrderType = "Regular Order";

                        saleso.DocumentId = docid.ToString();
                        saleso.Status = "Open Order";
						
						
                        saleso.UserId = opportunityproduct.Opportunity.AccountManager.Id.ToString();
                        
						if (opportunityproduct.Opportunity.OpportunityCIUDF.Accountmanagerid2!=null){
						saleso.UserID2 = opportunityproduct.Opportunity.OpportunityCIUDF.Accountmanagerid2.ToString();
						}
						
						if (opportunityproduct.Opportunity.Owner!=null){
                        saleso.Owner = opportunityproduct.Opportunity.Owner;
						} 

                        saleso.Actual = false;
                        Sage.Entity.Interfaces.ISalesorderdetail sodetail = Sage.Platform.EntityFactory.Create<Sage.Entity.Interfaces.ISalesorderdetail>();
                        sodetail.SalesOrder = saleso;
                        sodetail.ProductId = opportunityproduct.Product.Id.ToString();
                        if (opportunityproduct.OpportunityProductCI.Other_fees != null || opportunityproduct.OpportunityProductCI.Other_fees > 0)
                        {

								if (opportunityproduct.CalculatedPrice!=null){
									sodetail.Calcprice 		= (double)opportunityproduct.CalculatedPrice;
								} else {
									sodetail.Calcprice 	= 0;
								}
								
								if (opportunityproduct.ExtendedPrice!=null){
									sodetail.Extendedprice 	= (double)opportunityproduct.ExtendedPrice;	
								} else {
									sodetail.Extendedprice = 0;
								}
								
								if (opportunityproduct.Price!=null){
									sodetail.Price 			= (double)opportunityproduct.Price;
								} else {
									sodetail.Price = 0;
								}
								
								if (opportunityproduct.OpportunityProductCI.Commission!=null){
									sodetail.Commission 	= opportunityproduct.OpportunityProductCI.Commission;
								}	else {
									sodetail.Commission = 0;
								}
								
								if (opportunityproduct.OpportunityProductCI.Discount!=null){
									sodetail.Discount 		= opportunityproduct.OpportunityProductCI.Discount;
								} else {
									sodetail.Discount = 0;
								}
								
								if (opportunityproduct.OpportunityProductCI.Onsite_fees!=null){
									sodetail.Onsite_fees 	= (decimal) opportunityproduct.OpportunityProductCI.Onsite_fees;
								}
								else
								{
									sodetail.Onsite_fees = 0;
								}
								
								
								if (opportunityproduct.OpportunityProductCI.Other_fees!=null){
									sodetail.Other_fees 	= (decimal) opportunityproduct.OpportunityProductCI.Other_fees;
								} 
								else {
									sodetail.Other_fees = 0;
								}
								
								if (opportunityproduct.OpportunityProductCI.Num!=null){
								sodetail.Num = opportunityproduct.OpportunityProductCI.Num;
								}
                        }

                        saleso.OrderDate = DateTime.Now;
                        saleso.Salesorderdetails.Add(sodetail);
                        saleso.Save();
						DialogService.ShowMessage("Sales Order Creation process was completed successfully.");
						}
                    }
                    catch (Exception) {
                        //Response.Redirect(Request.Url.ToString());
						throw new Sage.Platform.Application.ValidationException("Creation Process not completed. Please Check that this opportunity have a Primary Contact Related.");
                    }
                }
            }
			
            if (e.CommandName.Equals("Delete"))
            {
                Sage.Entity.Interfaces.IOpportunity mainentity = this.BindingSource.Current as Sage.Entity.Interfaces.IOpportunity;
                if (mainentity != null)
                {
                    IOpportunityProduct childEntity = null;
                    if((currentEntity != null) && (currentEntity is IOpportunityProduct))
                    {
                        childEntity = (IOpportunityProduct)currentEntity;
                    }
                    else if (id != null)
                    {
                        childEntity = Sage.Platform.EntityFactory.GetById<IOpportunityProduct>(id);
                    }
                    if (childEntity != null)
                    {
                        mainentity.Products.Remove(childEntity);
                        if ((childEntity.PersistentState & Sage.Platform.Orm.Interfaces.PersistentState.New) <= 0)
                        {
                            childEntity.Delete();
                        }

                        if (mainentity.Products.Count != 0)
                        {
                            double salesPotential = 0;
                            foreach (IOpportunityProduct oppProduct in mainentity.Products)
                            {
                                if (oppProduct.Sort > rowIndex + 1)
                                {
                                    oppProduct.Sort--; 
                                }
                                salesPotential = salesPotential + (double)oppProduct.ExtendedPrice.Value;
                            }
                            mainentity.SalesPotential = salesPotential;

                            // this save prevented the user from deleting rows in the products grid.  The first delete
                            // would work fine, but then the save caused the application to lose track of the entity
                            // object so the object information didn't match the information shown on the page.

                            //mainentity.Save();
                        }
                    }
                }
            }
        }
        grdProducts_refresh();
	}
	
	protected void grdProducts_refresh()
	{
		if (PageWorkItem != null)
        {
			IPanelRefreshService refresher = PageWorkItem.Services.Get<IPanelRefreshService>();
			if (refresher != null)
			{
				refresher.RefreshAll();
			}
			else
			{
				Response.Redirect(Request.Url.ToString());
			}
		}
	}
	
    protected void grdProducts_RowEditing(object sender, GridViewEditEventArgs e)
	{
		grdProducts.SelectedIndex = e.NewEditIndex;
	}
            
    protected void grdProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		grdProducts.SelectedIndex = -1;
	}

    public override Type EntityType
    {
	    get { return typeof(IOpportunity); }
    }

     private Sage.Platform.WebPortal.Binding.WebEntityListBindingSource _dtsProducts;
     /// <summary>
     /// Gets the DTS products.
     /// </summary>
     /// <value>The DTS products.</value>
     public Sage.Platform.WebPortal.Binding.WebEntityListBindingSource dtsProducts
     {
         get
         {
             if (_dtsProducts == null)
             {
                 _dtsProducts = new Sage.Platform.WebPortal.Binding.WebEntityListBindingSource(typeof(IOpportunityProduct),
                                                                                               EntityType
                                                                                               , "Products",
                                                                                               System.Reflection.MemberTypes.
                                                                                                   Property);
                 _dtsProducts.UseSmartQuery = true;
             }
             return _dtsProducts;
         }
     }

     void dtsProducts_OnCurrentEntitySet(object sender, EventArgs e)
     {
         if (Visible)
         {
             dtsProducts.SourceObject = BindingSource.Current;
             RegisterBindingsWithClient(dtsProducts);
         }
     }

     protected override void OnAddEntityBindings()
     {
         dtsProducts.Bindings.Add(new Sage.Platform.WebPortal.Binding.WebEntityListBinding("Products", grdProducts));
         dtsProducts.BindFieldNames = new String[]
                                          {
                                              "Id", "Sort", "Product", "Product.Family", "Status", "OpportunityProductCI.Rate", "EstimatedClose",
                                              "ActualClose", "OpportunityProductCI.Num", "ExtendedPrice", "Opportunity.ExchangeRate",
                                              "Opportunity.ExchangeRateCode"
                                          };
         BindingSource.OnCurrentEntitySet += new EventHandler(dtsProducts_OnCurrentEntitySet);
     }

    protected void cmdAdd_ClickAction(object sender, EventArgs e)
    {
        if (DialogService != null)
        {
            DialogService.SetSpecs(550, 1260, "AddOpportunityProduct");
            DialogService.ShowDialog();
        }
    }


    protected override void OnWireEventHandlers()
    {
        base.OnWireEventHandlers();
        if (_roleSecurityService != null)
            if (_roleSecurityService.HasAccess("ENTITIES/CONTACT/EDIT"))
                cmdAdd.Click += new ImageClickEventHandler(cmdAdd_ClickAction);
            else
                cmdAdd.Visible = false;
    }

    protected override void OnFormBound()
    {
        object sender = this;
        EventArgs e = EventArgs.Empty;
        dtsProducts.Bind();

        SystemInformation si = SystemInformationRules.GetSystemInfo();
        DelphiStreamReader stream = new DelphiStreamReader(si.Data);
        TValueType type;
        if (stream.FindProperty("MultiCurrency", out type))
        {
            if (type.Equals(TValueType.vaTrue))
            {
                //grdProducts.Columns[7].Visible = true;
            }
            else
            {
                //grdProducts.Columns[7].Visible = false;
            }
        }

        string user = BusinessRuleHelper.GetCurrentUser().Id.ToString();
        grdProducts.Columns[10].Visible = (_roleSecurityService.HasAccess("Entities/Opportunity/Edit"));
        int team =0;
			using (NHibernate.ISession session = new Sage.Platform.Orm.SessionScopeWrapper())
    		{
        		string sql = "select count(*) from seccodejoins sj join seccode s on s.seccodeid=sj.parentseccodeid where sj.childseccodeid in (select defaultseccodeid from usersecurity where userid='"+user.ToString()+"') and s.seccodetype='G' and s.seccodedesc='Training'";
				team = session.CreateSQLQuery(sql).UniqueResult<int>();			
			}


            if (team > 0 || user.ToString().Trim() == "ADMIN")
            {
                grdProducts.Columns[12].Visible = true;
            }
            else
            {
                grdProducts.Columns[12].Visible = false;
            }
        grdProducts.Columns[13].Visible = (_roleSecurityService.HasAccess("Entities/Opportunity/Edit"));

        base.OnFormBound();
    }

    /// <summary>
    /// Gets the smart part info.
    /// </summary>
    /// <param name="smartPartInfoType">Type of the smart part info.</param>
    /// <returns></returns>
    public override Sage.Platform.Application.UI.ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
    {
        ToolsSmartPartInfo tinfo = new ToolsSmartPartInfo();
        foreach (Control c in pnlOpportunityProducts_LTools.Controls)
        {
            tinfo.LeftTools.Add(c);
        }
        foreach (Control c in pnlOpportunityProducts_CTools.Controls)
        {
            tinfo.CenterTools.Add(c);
        }
        foreach (Control c in pnlOpportunityProducts_RTools.Controls)
        {
            tinfo.RightTools.Add(c);
        }
        return tinfo;
    }

    private int _grdOppProductsdeleteColumnIndex = -2;
    protected int grdOppProductsDeleteColumnIndex
    {
        get
        {
            if (_grdOppProductsdeleteColumnIndex == -2)
            {
                int bias = (grdProducts.ExpandableRows) ? 1 : 0;
                _grdOppProductsdeleteColumnIndex = -1;
                int colcount = 0;
                foreach (DataControlField col in grdProducts.Columns)
                {
                    ButtonField btn = col as ButtonField;
                    if (btn != null)
                    {
                        if (btn.CommandName == "Delete")
                        {
                            _grdOppProductsdeleteColumnIndex = colcount + bias;
                            break;
                        }
                    }
                    colcount++;
                }
            }
            return _grdOppProductsdeleteColumnIndex;
        }
    }

    protected void grdProducts_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            IOpportunity entity = (IOpportunity)EntityContext.GetEntity();

            //Calculated (Opportunity Currency)
			//Sage.SalesLogix.Web.Controls.Currency curr = (Sage.SalesLogix.Web.Controls.Currency) e.Row.Cells[7].Controls[1];
            //curr.ExchangeRate = entity.ExchangeRate.GetValueOrDefault(1);
            //curr.CurrentCode = entity.ExchangeRateCode;

            //Extended Price
			//curr = (Sage.SalesLogix.Web.Controls.Currency) e.Row.Cells[9].Controls[1];
            //curr.ExchangeRate = entity.ExchangeRate.GetValueOrDefault(1);
            //curr.CurrentCode = entity.ExchangeRateCode;
        }
    }

    protected void grdProducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((grdOppProductsDeleteColumnIndex >= 0) && (grdOppProductsDeleteColumnIndex < e.Row.Cells.Count))
            {
                TableCell cell = e.Row.Cells[grdOppProductsDeleteColumnIndex];
                foreach (Control c in cell.Controls)
                {
                    LinkButton btn = c as LinkButton;
                    if (btn != null)
					{
                        btn.Attributes.Add("onclick", "javascript: return confirm('" + GetLocalResourceObject("grdProductsConfrmation.ConfirmationMessage").ToString() + "');");
                        return;
                    }
                }
            }
        }
    }

    protected void grdProducts_Sorting(object sender, GridViewSortEventArgs e)
    {
    }
}