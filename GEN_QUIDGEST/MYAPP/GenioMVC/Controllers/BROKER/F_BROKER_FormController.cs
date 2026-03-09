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
using GenioMVC.ViewModels.Broker;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL TRA INCLUDE_CONTROLLER BROKER]/

namespace GenioMVC.Controllers
{
	public partial class BrokerController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_BROKER_CANCEL = new("BROKER49181", "F_broker_Cancel", "Broker") { vueRouteName = "form-F_BROKER", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_BROKER_SHOW = new("BROKER49181", "F_broker_Show", "Broker") { vueRouteName = "form-F_BROKER", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_BROKER_NEW = new("BROKER49181", "F_broker_New", "Broker") { vueRouteName = "form-F_BROKER", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_BROKER_EDIT = new("BROKER49181", "F_broker_Edit", "Broker") { vueRouteName = "form-F_BROKER", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_BROKER_DUPLICATE = new("BROKER49181", "F_broker_Duplicate", "Broker") { vueRouteName = "form-F_BROKER", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_BROKER_DELETE = new("BROKER49181", "F_broker_Delete", "Broker") { vueRouteName = "form-F_BROKER", mode = "DELETE" };

		#endregion

		#region F_broker private

		private void FormHistoryLimits_F_broker()
		{

		}

		#endregion

		#region F_broker_Show

// USE /[MANUAL TRA CONTROLLER_SHOW F_BROKER]/

		[HttpPost]
		public ActionResult F_broker_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_broker_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_broker_Show_GET",
				AreaName = "broker",
				Location = ACTION_F_BROKER_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_broker();
// USE /[MANUAL TRA BEFORE_LOAD_SHOW F_BROKER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_SHOW F_BROKER]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region F_broker_New

// USE /[MANUAL TRA CONTROLLER_NEW_GET F_BROKER]/
		[HttpPost]
		public ActionResult F_broker_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			F_broker_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_broker_New_GET",
				AreaName = "broker",
				FormName = "F_BROKER",
				Location = ACTION_F_BROKER_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_broker();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_NEW F_BROKER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_NEW F_BROKER]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Broker/F_broker_New
// USE /[MANUAL TRA CONTROLLER_NEW_POST F_BROKER]/
		[HttpPost]
		public ActionResult F_broker_New([FromBody]F_broker_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_broker_New",
				ViewName = "F_broker",
				AreaName = "broker",
				Location = ACTION_F_BROKER_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_NEW F_BROKER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_NEW F_BROKER]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_NEW_EX F_BROKER]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_NEW_EX F_BROKER]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region F_broker_Edit

// USE /[MANUAL TRA CONTROLLER_EDIT_GET F_BROKER]/
		[HttpPost]
		public ActionResult F_broker_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_broker_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_broker_Edit_GET",
				AreaName = "broker",
				FormName = "F_BROKER",
				Location = ACTION_F_BROKER_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_broker();
// USE /[MANUAL TRA BEFORE_LOAD_EDIT F_BROKER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_EDIT F_BROKER]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Broker/F_broker_Edit
// USE /[MANUAL TRA CONTROLLER_EDIT_POST F_BROKER]/
		[HttpPost]
		public ActionResult F_broker_Edit([FromBody]F_broker_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_broker_Edit",
				ViewName = "F_broker",
				AreaName = "broker",
				Location = ACTION_F_BROKER_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_EDIT F_BROKER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_EDIT F_BROKER]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_EDIT_EX F_BROKER]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_EDIT_EX F_BROKER]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region F_broker_Delete

// USE /[MANUAL TRA CONTROLLER_DELETE_GET F_BROKER]/
		[HttpPost]
		public ActionResult F_broker_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_broker_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_broker_Delete_GET",
				AreaName = "broker",
				FormName = "F_BROKER",
				Location = ACTION_F_BROKER_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_broker();
// USE /[MANUAL TRA BEFORE_LOAD_DELETE F_BROKER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DELETE F_BROKER]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Broker/F_broker_Delete
// USE /[MANUAL TRA CONTROLLER_DELETE_POST F_BROKER]/
		[HttpPost]
		public ActionResult F_broker_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_broker_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "F_broker_Delete",
				ViewName = "F_broker",
				AreaName = "broker",
				Location = ACTION_F_BROKER_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_DESTROY_DELETE F_BROKER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_DESTROY_DELETE F_BROKER]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult F_broker_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_BROKER");
		}

		#endregion

		#region F_broker_Duplicate

// USE /[MANUAL TRA CONTROLLER_DUPLICATE_GET F_BROKER]/

		[HttpPost]
		public ActionResult F_broker_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			F_broker_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_broker_Duplicate_GET",
				AreaName = "broker",
				FormName = "F_BROKER",
				Location = ACTION_F_BROKER_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_DUPLICATE F_BROKER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DUPLICATE F_BROKER]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Broker/F_broker_Duplicate
// USE /[MANUAL TRA CONTROLLER_DUPLICATE_POST F_BROKER]/
		[HttpPost]
		public ActionResult F_broker_Duplicate([FromBody]F_broker_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_broker_Duplicate",
				ViewName = "F_broker",
				AreaName = "broker",
				Location = ACTION_F_BROKER_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_DUPLICATE F_BROKER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_DUPLICATE F_BROKER]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_DUPLICATE_EX F_BROKER]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DUPLICATE_EX F_BROKER]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region F_broker_Cancel

		//
		// GET: /Broker/F_broker_Cancel
// USE /[MANUAL TRA CONTROLLER_CANCEL_GET F_BROKER]/
		public ActionResult F_broker_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Broker model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("broker");

// USE /[MANUAL TRA BEFORE_CANCEL F_BROKER]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL TRA AFTER_CANCEL F_BROKER]/

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

				Navigation.SetValue("ForcePrimaryRead_broker", "true", true);
			}

			Navigation.ClearValue("broker");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Broker/F_broker_SaveEdit
		[HttpPost]
		public ActionResult F_broker_SaveEdit([FromBody] F_broker_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_broker_SaveEdit",
				ViewName = "F_broker",
				AreaName = "broker",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_APPLY_EDIT F_BROKER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_APPLY_EDIT F_BROKER]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_brokerDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_broker_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_broker([FromBody] F_brokerDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
