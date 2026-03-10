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
using GenioMVC.ViewModels.Country;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL TRA INCLUDE_CONTROLLER COUNTRY]/

namespace GenioMVC.Controllers
{
	public partial class CountryController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_COUNTRY_CANCEL = new("COUNTRY64133", "F_country_Cancel", "Country") { vueRouteName = "form-F_COUNTRY", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_COUNTRY_SHOW = new("COUNTRY64133", "F_country_Show", "Country") { vueRouteName = "form-F_COUNTRY", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_COUNTRY_NEW = new("COUNTRY64133", "F_country_New", "Country") { vueRouteName = "form-F_COUNTRY", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_COUNTRY_EDIT = new("COUNTRY64133", "F_country_Edit", "Country") { vueRouteName = "form-F_COUNTRY", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_COUNTRY_DUPLICATE = new("COUNTRY64133", "F_country_Duplicate", "Country") { vueRouteName = "form-F_COUNTRY", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_COUNTRY_DELETE = new("COUNTRY64133", "F_country_Delete", "Country") { vueRouteName = "form-F_COUNTRY", mode = "DELETE" };

		#endregion

		#region F_country private

		private void FormHistoryLimits_F_country()
		{

		}

		#endregion

		#region F_country_Show

// USE /[MANUAL TRA CONTROLLER_SHOW F_COUNTRY]/

		[HttpPost]
		public ActionResult F_country_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_country_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_country_Show_GET",
				AreaName = "country",
				Location = ACTION_F_COUNTRY_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_country();
// USE /[MANUAL TRA BEFORE_LOAD_SHOW F_COUNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_SHOW F_COUNTRY]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region F_country_New

// USE /[MANUAL TRA CONTROLLER_NEW_GET F_COUNTRY]/
		[HttpPost]
		public ActionResult F_country_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			F_country_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_country_New_GET",
				AreaName = "country",
				FormName = "F_COUNTRY",
				Location = ACTION_F_COUNTRY_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_country();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_NEW F_COUNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_NEW F_COUNTRY]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Country/F_country_New
// USE /[MANUAL TRA CONTROLLER_NEW_POST F_COUNTRY]/
		[HttpPost]
		public ActionResult F_country_New([FromBody]F_country_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_country_New",
				ViewName = "F_country",
				AreaName = "country",
				Location = ACTION_F_COUNTRY_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_NEW F_COUNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_NEW F_COUNTRY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_NEW_EX F_COUNTRY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_NEW_EX F_COUNTRY]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region F_country_Edit

// USE /[MANUAL TRA CONTROLLER_EDIT_GET F_COUNTRY]/
		[HttpPost]
		public ActionResult F_country_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_country_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_country_Edit_GET",
				AreaName = "country",
				FormName = "F_COUNTRY",
				Location = ACTION_F_COUNTRY_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_country();
// USE /[MANUAL TRA BEFORE_LOAD_EDIT F_COUNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_EDIT F_COUNTRY]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Country/F_country_Edit
// USE /[MANUAL TRA CONTROLLER_EDIT_POST F_COUNTRY]/
		[HttpPost]
		public ActionResult F_country_Edit([FromBody]F_country_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_country_Edit",
				ViewName = "F_country",
				AreaName = "country",
				Location = ACTION_F_COUNTRY_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_EDIT F_COUNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_EDIT F_COUNTRY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_EDIT_EX F_COUNTRY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_EDIT_EX F_COUNTRY]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region F_country_Delete

// USE /[MANUAL TRA CONTROLLER_DELETE_GET F_COUNTRY]/
		[HttpPost]
		public ActionResult F_country_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_country_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_country_Delete_GET",
				AreaName = "country",
				FormName = "F_COUNTRY",
				Location = ACTION_F_COUNTRY_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_country();
// USE /[MANUAL TRA BEFORE_LOAD_DELETE F_COUNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DELETE F_COUNTRY]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Country/F_country_Delete
// USE /[MANUAL TRA CONTROLLER_DELETE_POST F_COUNTRY]/
		[HttpPost]
		public ActionResult F_country_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_country_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "F_country_Delete",
				ViewName = "F_country",
				AreaName = "country",
				Location = ACTION_F_COUNTRY_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_DESTROY_DELETE F_COUNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_DESTROY_DELETE F_COUNTRY]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult F_country_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_COUNTRY");
		}

		#endregion

		#region F_country_Duplicate

// USE /[MANUAL TRA CONTROLLER_DUPLICATE_GET F_COUNTRY]/

		[HttpPost]
		public ActionResult F_country_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			F_country_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_country_Duplicate_GET",
				AreaName = "country",
				FormName = "F_COUNTRY",
				Location = ACTION_F_COUNTRY_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_DUPLICATE F_COUNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DUPLICATE F_COUNTRY]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Country/F_country_Duplicate
// USE /[MANUAL TRA CONTROLLER_DUPLICATE_POST F_COUNTRY]/
		[HttpPost]
		public ActionResult F_country_Duplicate([FromBody]F_country_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_country_Duplicate",
				ViewName = "F_country",
				AreaName = "country",
				Location = ACTION_F_COUNTRY_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_DUPLICATE F_COUNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_DUPLICATE F_COUNTRY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_DUPLICATE_EX F_COUNTRY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DUPLICATE_EX F_COUNTRY]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region F_country_Cancel

		//
		// GET: /Country/F_country_Cancel
// USE /[MANUAL TRA CONTROLLER_CANCEL_GET F_COUNTRY]/
		public ActionResult F_country_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Country model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("country");

// USE /[MANUAL TRA BEFORE_CANCEL F_COUNTRY]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL TRA AFTER_CANCEL F_COUNTRY]/

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

				Navigation.SetValue("ForcePrimaryRead_country", "true", true);
			}

			Navigation.ClearValue("country");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Country/F_country_SaveEdit
		[HttpPost]
		public ActionResult F_country_SaveEdit([FromBody] F_country_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_country_SaveEdit",
				ViewName = "F_country",
				AreaName = "country",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_APPLY_EDIT F_COUNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_APPLY_EDIT F_COUNTRY]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_countryDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_country_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_country([FromBody] F_countryDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
