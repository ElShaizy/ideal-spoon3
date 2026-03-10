using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Dynamic;

using CSGenio.business;
using CSGenio.core.persistence;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels;
using GenioMVC.ViewModels.City;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL TRA INCLUDE_CONTROLLER CITY]/

namespace GenioMVC.Controllers
{
	public partial class CityController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_CITY_CANCEL = new("CITY42505", "F_city_Cancel", "City") { vueRouteName = "form-F_CITY", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_CITY_SHOW = new("CITY42505", "F_city_Show", "City") { vueRouteName = "form-F_CITY", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_CITY_NEW = new("CITY42505", "F_city_New", "City") { vueRouteName = "form-F_CITY", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_CITY_EDIT = new("CITY42505", "F_city_Edit", "City") { vueRouteName = "form-F_CITY", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_CITY_DUPLICATE = new("CITY42505", "F_city_Duplicate", "City") { vueRouteName = "form-F_CITY", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_CITY_DELETE = new("CITY42505", "F_city_Delete", "City") { vueRouteName = "form-F_CITY", mode = "DELETE" };

		#endregion

		#region F_city private

		private void FormHistoryLimits_F_city()
		{

		}

		#endregion

		#region F_city_Show

// USE /[MANUAL TRA CONTROLLER_SHOW F_CITY]/

		[HttpPost]
		public ActionResult F_city_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_city_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_city_Show_GET",
				AreaName = "city",
				Location = ACTION_F_CITY_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_city();
// USE /[MANUAL TRA BEFORE_LOAD_SHOW F_CITY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_SHOW F_CITY]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region F_city_New

// USE /[MANUAL TRA CONTROLLER_NEW_GET F_CITY]/
		[HttpPost]
		public ActionResult F_city_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			F_city_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_city_New_GET",
				AreaName = "city",
				FormName = "F_CITY",
				Location = ACTION_F_CITY_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_city();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_NEW F_CITY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_NEW F_CITY]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /City/F_city_New
// USE /[MANUAL TRA CONTROLLER_NEW_POST F_CITY]/
		[HttpPost]
		public ActionResult F_city_New([FromBody]F_city_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_city_New",
				ViewName = "F_city",
				AreaName = "city",
				Location = ACTION_F_CITY_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_NEW F_CITY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_NEW F_CITY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_NEW_EX F_CITY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_NEW_EX F_CITY]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region F_city_Edit

// USE /[MANUAL TRA CONTROLLER_EDIT_GET F_CITY]/
		[HttpPost]
		public ActionResult F_city_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_city_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_city_Edit_GET",
				AreaName = "city",
				FormName = "F_CITY",
				Location = ACTION_F_CITY_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_city();
// USE /[MANUAL TRA BEFORE_LOAD_EDIT F_CITY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_EDIT F_CITY]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /City/F_city_Edit
// USE /[MANUAL TRA CONTROLLER_EDIT_POST F_CITY]/
		[HttpPost]
		public ActionResult F_city_Edit([FromBody]F_city_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_city_Edit",
				ViewName = "F_city",
				AreaName = "city",
				Location = ACTION_F_CITY_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_EDIT F_CITY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_EDIT F_CITY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_EDIT_EX F_CITY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_EDIT_EX F_CITY]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region F_city_Delete

// USE /[MANUAL TRA CONTROLLER_DELETE_GET F_CITY]/
		[HttpPost]
		public ActionResult F_city_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_city_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_city_Delete_GET",
				AreaName = "city",
				FormName = "F_CITY",
				Location = ACTION_F_CITY_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_city();
// USE /[MANUAL TRA BEFORE_LOAD_DELETE F_CITY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DELETE F_CITY]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /City/F_city_Delete
// USE /[MANUAL TRA CONTROLLER_DELETE_POST F_CITY]/
		[HttpPost]
		public ActionResult F_city_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_city_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "F_city_Delete",
				ViewName = "F_city",
				AreaName = "city",
				Location = ACTION_F_CITY_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_DESTROY_DELETE F_CITY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_DESTROY_DELETE F_CITY]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult F_city_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_CITY");
		}

		#endregion

		#region F_city_Duplicate

// USE /[MANUAL TRA CONTROLLER_DUPLICATE_GET F_CITY]/

		[HttpPost]
		public ActionResult F_city_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			F_city_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_city_Duplicate_GET",
				AreaName = "city",
				FormName = "F_CITY",
				Location = ACTION_F_CITY_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_DUPLICATE F_CITY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DUPLICATE F_CITY]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /City/F_city_Duplicate
// USE /[MANUAL TRA CONTROLLER_DUPLICATE_POST F_CITY]/
		[HttpPost]
		public ActionResult F_city_Duplicate([FromBody]F_city_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_city_Duplicate",
				ViewName = "F_city",
				AreaName = "city",
				Location = ACTION_F_CITY_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_DUPLICATE F_CITY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_DUPLICATE F_CITY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_DUPLICATE_EX F_CITY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DUPLICATE_EX F_CITY]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region F_city_Cancel

		//
		// GET: /City/F_city_Cancel
// USE /[MANUAL TRA CONTROLLER_CANCEL_GET F_CITY]/
		public ActionResult F_city_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.City model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("city");

// USE /[MANUAL TRA BEFORE_CANCEL F_CITY]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL TRA AFTER_CANCEL F_CITY]/

				}
				catch (Exception e)
				{
					sp.rollbackTransaction();
					sp.closeConnection();

					var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
					if (e is GenioException && (e as GenioException).UserMessage != null)
						exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);
					return JsonERROR(exceptionUserMessage);
				}

				Navigation.SetValue("ForcePrimaryRead_city", "true", true);
			}

			Navigation.ClearValue("city");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class F_city_CountryValCountryModel : RequestLookupModel
		{
			public F_city_ViewModel Model { get; set; }
		}

		//
		// GET: /City/F_city_CountryValCountry
		// POST: /City/F_city_CountryValCountry
		[ActionName("F_city_CountryValCountry")]
		public ActionResult F_city_CountryValCountry([FromBody] F_city_CountryValCountryModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_country")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_country");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.City parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			F_city_CountryValCountry_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /City/F_city_SaveEdit
		[HttpPost]
		public ActionResult F_city_SaveEdit([FromBody] F_city_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_city_SaveEdit",
				ViewName = "F_city",
				AreaName = "city",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_APPLY_EDIT F_CITY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_APPLY_EDIT F_CITY]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_cityDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_city_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_city([FromBody] F_cityDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
