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
using GenioMVC.ViewModels.Properties;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL TRA INCLUDE_CONTROLLER PROPERTIES]/

namespace GenioMVC.Controllers
{
	public partial class PropertiesController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_PROPERTY_CANCEL = new("PROPERTY43977", "F_property_Cancel", "Properties") { vueRouteName = "form-F_PROPERTY", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_PROPERTY_SHOW = new("PROPERTY43977", "F_property_Show", "Properties") { vueRouteName = "form-F_PROPERTY", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_PROPERTY_NEW = new("PROPERTY43977", "F_property_New", "Properties") { vueRouteName = "form-F_PROPERTY", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_PROPERTY_EDIT = new("PROPERTY43977", "F_property_Edit", "Properties") { vueRouteName = "form-F_PROPERTY", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_PROPERTY_DUPLICATE = new("PROPERTY43977", "F_property_Duplicate", "Properties") { vueRouteName = "form-F_PROPERTY", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_PROPERTY_DELETE = new("PROPERTY43977", "F_property_Delete", "Properties") { vueRouteName = "form-F_PROPERTY", mode = "DELETE" };

		#endregion

		#region F_property private

		private void FormHistoryLimits_F_property()
		{

		}

		#endregion

		#region F_property_Show

// USE /[MANUAL TRA CONTROLLER_SHOW F_PROPERTY]/

		[HttpPost]
		public ActionResult F_property_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_property_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_property_Show_GET",
				AreaName = "properties",
				Location = ACTION_F_PROPERTY_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_property();
// USE /[MANUAL TRA BEFORE_LOAD_SHOW F_PROPERTY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_SHOW F_PROPERTY]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region F_property_New

// USE /[MANUAL TRA CONTROLLER_NEW_GET F_PROPERTY]/
		[HttpPost]
		public ActionResult F_property_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			F_property_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_property_New_GET",
				AreaName = "properties",
				FormName = "F_PROPERTY",
				Location = ACTION_F_PROPERTY_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_property();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_NEW F_PROPERTY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_NEW F_PROPERTY]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Properties/F_property_New
// USE /[MANUAL TRA CONTROLLER_NEW_POST F_PROPERTY]/
		[HttpPost]
		public ActionResult F_property_New([FromBody]F_property_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_property_New",
				ViewName = "F_property",
				AreaName = "properties",
				Location = ACTION_F_PROPERTY_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_NEW F_PROPERTY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_NEW F_PROPERTY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_NEW_EX F_PROPERTY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_NEW_EX F_PROPERTY]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region F_property_Edit

// USE /[MANUAL TRA CONTROLLER_EDIT_GET F_PROPERTY]/
		[HttpPost]
		public ActionResult F_property_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_property_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_property_Edit_GET",
				AreaName = "properties",
				FormName = "F_PROPERTY",
				Location = ACTION_F_PROPERTY_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_property();
// USE /[MANUAL TRA BEFORE_LOAD_EDIT F_PROPERTY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_EDIT F_PROPERTY]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Properties/F_property_Edit
// USE /[MANUAL TRA CONTROLLER_EDIT_POST F_PROPERTY]/
		[HttpPost]
		public ActionResult F_property_Edit([FromBody]F_property_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_property_Edit",
				ViewName = "F_property",
				AreaName = "properties",
				Location = ACTION_F_PROPERTY_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_EDIT F_PROPERTY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_EDIT F_PROPERTY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_EDIT_EX F_PROPERTY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_EDIT_EX F_PROPERTY]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region F_property_Delete

// USE /[MANUAL TRA CONTROLLER_DELETE_GET F_PROPERTY]/
		[HttpPost]
		public ActionResult F_property_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_property_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_property_Delete_GET",
				AreaName = "properties",
				FormName = "F_PROPERTY",
				Location = ACTION_F_PROPERTY_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_property();
// USE /[MANUAL TRA BEFORE_LOAD_DELETE F_PROPERTY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DELETE F_PROPERTY]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Properties/F_property_Delete
// USE /[MANUAL TRA CONTROLLER_DELETE_POST F_PROPERTY]/
		[HttpPost]
		public ActionResult F_property_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_property_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "F_property_Delete",
				ViewName = "F_property",
				AreaName = "properties",
				Location = ACTION_F_PROPERTY_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_DESTROY_DELETE F_PROPERTY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_DESTROY_DELETE F_PROPERTY]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult F_property_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_PROPERTY");
		}

		#endregion

		#region F_property_Duplicate

// USE /[MANUAL TRA CONTROLLER_DUPLICATE_GET F_PROPERTY]/

		[HttpPost]
		public ActionResult F_property_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			F_property_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_property_Duplicate_GET",
				AreaName = "properties",
				FormName = "F_PROPERTY",
				Location = ACTION_F_PROPERTY_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_DUPLICATE F_PROPERTY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DUPLICATE F_PROPERTY]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Properties/F_property_Duplicate
// USE /[MANUAL TRA CONTROLLER_DUPLICATE_POST F_PROPERTY]/
		[HttpPost]
		public ActionResult F_property_Duplicate([FromBody]F_property_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_property_Duplicate",
				ViewName = "F_property",
				AreaName = "properties",
				Location = ACTION_F_PROPERTY_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_DUPLICATE F_PROPERTY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_DUPLICATE F_PROPERTY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_DUPLICATE_EX F_PROPERTY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DUPLICATE_EX F_PROPERTY]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region F_property_Cancel

		//
		// GET: /Properties/F_property_Cancel
// USE /[MANUAL TRA CONTROLLER_CANCEL_GET F_PROPERTY]/
		public ActionResult F_property_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Properties model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("properties");

// USE /[MANUAL TRA BEFORE_CANCEL F_PROPERTY]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL TRA AFTER_CANCEL F_PROPERTY]/

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

				Navigation.SetValue("ForcePrimaryRead_properties", "true", true);
			}

			Navigation.ClearValue("properties");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Properties/F_property_SaveEdit
		[HttpPost]
		public ActionResult F_property_SaveEdit([FromBody] F_property_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_property_SaveEdit",
				ViewName = "F_property",
				AreaName = "properties",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_APPLY_EDIT F_PROPERTY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_APPLY_EDIT F_PROPERTY]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_propertyDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_property_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_property([FromBody] F_propertyDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
