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
using GenioMVC.ViewModels.Contact;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL TRA INCLUDE_CONTROLLER CONTACT]/

namespace GenioMVC.Controllers
{
	public partial class ContactController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_CONTACT_CANCEL = new("CONTACT59247", "F_contact_Cancel", "Contact") { vueRouteName = "form-F_CONTACT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_CONTACT_SHOW = new("CONTACT59247", "F_contact_Show", "Contact") { vueRouteName = "form-F_CONTACT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_CONTACT_NEW = new("CONTACT59247", "F_contact_New", "Contact") { vueRouteName = "form-F_CONTACT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_CONTACT_EDIT = new("CONTACT59247", "F_contact_Edit", "Contact") { vueRouteName = "form-F_CONTACT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_CONTACT_DUPLICATE = new("CONTACT59247", "F_contact_Duplicate", "Contact") { vueRouteName = "form-F_CONTACT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_CONTACT_DELETE = new("CONTACT59247", "F_contact_Delete", "Contact") { vueRouteName = "form-F_CONTACT", mode = "DELETE" };

		#endregion

		#region F_contact private

		private void FormHistoryLimits_F_contact()
		{

		}

		#endregion

		#region F_contact_Show

// USE /[MANUAL TRA CONTROLLER_SHOW F_CONTACT]/

		[HttpPost]
		public ActionResult F_contact_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_contact_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_contact_Show_GET",
				AreaName = "contact",
				Location = ACTION_F_CONTACT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_contact();
// USE /[MANUAL TRA BEFORE_LOAD_SHOW F_CONTACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_SHOW F_CONTACT]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region F_contact_New

// USE /[MANUAL TRA CONTROLLER_NEW_GET F_CONTACT]/
		[HttpPost]
		public ActionResult F_contact_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			F_contact_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_contact_New_GET",
				AreaName = "contact",
				FormName = "F_CONTACT",
				Location = ACTION_F_CONTACT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_contact();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_NEW F_CONTACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_NEW F_CONTACT]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Contact/F_contact_New
// USE /[MANUAL TRA CONTROLLER_NEW_POST F_CONTACT]/
		[HttpPost]
		public ActionResult F_contact_New([FromBody]F_contact_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_contact_New",
				ViewName = "F_contact",
				AreaName = "contact",
				Location = ACTION_F_CONTACT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_NEW F_CONTACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_NEW F_CONTACT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_NEW_EX F_CONTACT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_NEW_EX F_CONTACT]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region F_contact_Edit

// USE /[MANUAL TRA CONTROLLER_EDIT_GET F_CONTACT]/
		[HttpPost]
		public ActionResult F_contact_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_contact_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_contact_Edit_GET",
				AreaName = "contact",
				FormName = "F_CONTACT",
				Location = ACTION_F_CONTACT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_contact();
// USE /[MANUAL TRA BEFORE_LOAD_EDIT F_CONTACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_EDIT F_CONTACT]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Contact/F_contact_Edit
// USE /[MANUAL TRA CONTROLLER_EDIT_POST F_CONTACT]/
		[HttpPost]
		public ActionResult F_contact_Edit([FromBody]F_contact_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_contact_Edit",
				ViewName = "F_contact",
				AreaName = "contact",
				Location = ACTION_F_CONTACT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_EDIT F_CONTACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_EDIT F_CONTACT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_EDIT_EX F_CONTACT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_EDIT_EX F_CONTACT]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region F_contact_Delete

// USE /[MANUAL TRA CONTROLLER_DELETE_GET F_CONTACT]/
		[HttpPost]
		public ActionResult F_contact_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_contact_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_contact_Delete_GET",
				AreaName = "contact",
				FormName = "F_CONTACT",
				Location = ACTION_F_CONTACT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_contact();
// USE /[MANUAL TRA BEFORE_LOAD_DELETE F_CONTACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DELETE F_CONTACT]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Contact/F_contact_Delete
// USE /[MANUAL TRA CONTROLLER_DELETE_POST F_CONTACT]/
		[HttpPost]
		public ActionResult F_contact_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_contact_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "F_contact_Delete",
				ViewName = "F_contact",
				AreaName = "contact",
				Location = ACTION_F_CONTACT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_DESTROY_DELETE F_CONTACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_DESTROY_DELETE F_CONTACT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult F_contact_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_CONTACT");
		}

		#endregion

		#region F_contact_Duplicate

// USE /[MANUAL TRA CONTROLLER_DUPLICATE_GET F_CONTACT]/

		[HttpPost]
		public ActionResult F_contact_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			F_contact_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_contact_Duplicate_GET",
				AreaName = "contact",
				FormName = "F_CONTACT",
				Location = ACTION_F_CONTACT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_DUPLICATE F_CONTACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DUPLICATE F_CONTACT]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Contact/F_contact_Duplicate
// USE /[MANUAL TRA CONTROLLER_DUPLICATE_POST F_CONTACT]/
		[HttpPost]
		public ActionResult F_contact_Duplicate([FromBody]F_contact_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_contact_Duplicate",
				ViewName = "F_contact",
				AreaName = "contact",
				Location = ACTION_F_CONTACT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_DUPLICATE F_CONTACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_DUPLICATE F_CONTACT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_DUPLICATE_EX F_CONTACT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DUPLICATE_EX F_CONTACT]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region F_contact_Cancel

		//
		// GET: /Contact/F_contact_Cancel
// USE /[MANUAL TRA CONTROLLER_CANCEL_GET F_CONTACT]/
		public ActionResult F_contact_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Contact model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("contact");

// USE /[MANUAL TRA BEFORE_CANCEL F_CONTACT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL TRA AFTER_CANCEL F_CONTACT]/

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

				Navigation.SetValue("ForcePrimaryRead_contact", "true", true);
			}

			Navigation.ClearValue("contact");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class F_contact_PropertiesValTitleModel : RequestLookupModel
		{
			public F_contact_ViewModel Model { get; set; }
		}

		//
		// GET: /Contact/F_contact_PropertiesValTitle
		// POST: /Contact/F_contact_PropertiesValTitle
		[ActionName("F_contact_PropertiesValTitle")]
		public ActionResult F_contact_PropertiesValTitle([FromBody] F_contact_PropertiesValTitleModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_properties")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_properties");
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

			Models.Contact parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			F_contact_PropertiesValTitle_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Contact/F_contact_SaveEdit
		[HttpPost]
		public ActionResult F_contact_SaveEdit([FromBody] F_contact_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_contact_SaveEdit",
				ViewName = "F_contact",
				AreaName = "contact",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_APPLY_EDIT F_CONTACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_APPLY_EDIT F_CONTACT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_contactDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_contact_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_contact([FromBody] F_contactDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
