using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using CSGenio.core.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels.Country;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// USE /[MANUAL TRA INCLUDE_CONTROLLER COUNTRY]/

namespace GenioMVC.Controllers
{
	public partial class CountryController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_TRA_MENU_411 = new NavigationLocation("COUNTRIES64527", "TRA_Menu_411", "Country") { vueRouteName = "menu-TRA_411" };


		//
		// GET: /Country/TRA_Menu_411
		[ActionName("TRA_Menu_411")]
		[HttpPost]
		public ActionResult TRA_Menu_411([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			TRA_Menu_411_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "TRA_Menu_411");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_country")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_country");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_TRA_MENU_411.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_TRA_MENU_411.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_TRA_MENU_411.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL TRA MENU_GET 411]/

			try
			{
				model.Load(tableConfig, querystring, Request.IsAjaxRequest());
			}
			catch (Exception e)
			{
				return JsonERROR(HandleException(e), model);
			}


			return JsonOK(model);
		}



	}
}
