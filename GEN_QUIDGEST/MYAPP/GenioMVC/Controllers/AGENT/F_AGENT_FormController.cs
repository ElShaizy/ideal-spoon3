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
using GenioMVC.ViewModels.Agent;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL TRA INCLUDE_CONTROLLER AGENT]/

namespace GenioMVC.Controllers
{
	public partial class AgentController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_AGENT_CANCEL = new("AGENT00994", "F_agent_Cancel", "Agent") { vueRouteName = "form-F_AGENT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_AGENT_SHOW = new("AGENT00994", "F_agent_Show", "Agent") { vueRouteName = "form-F_AGENT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_AGENT_NEW = new("AGENT00994", "F_agent_New", "Agent") { vueRouteName = "form-F_AGENT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_AGENT_EDIT = new("AGENT00994", "F_agent_Edit", "Agent") { vueRouteName = "form-F_AGENT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_AGENT_DUPLICATE = new("AGENT00994", "F_agent_Duplicate", "Agent") { vueRouteName = "form-F_AGENT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_AGENT_DELETE = new("AGENT00994", "F_agent_Delete", "Agent") { vueRouteName = "form-F_AGENT", mode = "DELETE" };

		#endregion

		#region F_agent private

		private void FormHistoryLimits_F_agent()
		{

		}

		#endregion

		#region F_agent_Show

// USE /[MANUAL TRA CONTROLLER_SHOW F_AGENT]/

		[HttpPost]
		public ActionResult F_agent_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_agent_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_agent_Show_GET",
				AreaName = "agent",
				Location = ACTION_F_AGENT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_agent();
// USE /[MANUAL TRA BEFORE_LOAD_SHOW F_AGENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_SHOW F_AGENT]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region F_agent_New

// USE /[MANUAL TRA CONTROLLER_NEW_GET F_AGENT]/
		[HttpPost]
		public ActionResult F_agent_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			F_agent_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_agent_New_GET",
				AreaName = "agent",
				FormName = "F_AGENT",
				Location = ACTION_F_AGENT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_agent();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_NEW F_AGENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_NEW F_AGENT]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Agent/F_agent_New
// USE /[MANUAL TRA CONTROLLER_NEW_POST F_AGENT]/
		[HttpPost]
		public ActionResult F_agent_New([FromBody]F_agent_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_agent_New",
				ViewName = "F_agent",
				AreaName = "agent",
				Location = ACTION_F_AGENT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_NEW F_AGENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_NEW F_AGENT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_NEW_EX F_AGENT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_NEW_EX F_AGENT]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region F_agent_Edit

// USE /[MANUAL TRA CONTROLLER_EDIT_GET F_AGENT]/
		[HttpPost]
		public ActionResult F_agent_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_agent_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_agent_Edit_GET",
				AreaName = "agent",
				FormName = "F_AGENT",
				Location = ACTION_F_AGENT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_agent();
// USE /[MANUAL TRA BEFORE_LOAD_EDIT F_AGENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_EDIT F_AGENT]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Agent/F_agent_Edit
// USE /[MANUAL TRA CONTROLLER_EDIT_POST F_AGENT]/
		[HttpPost]
		public ActionResult F_agent_Edit([FromBody]F_agent_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_agent_Edit",
				ViewName = "F_agent",
				AreaName = "agent",
				Location = ACTION_F_AGENT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_EDIT F_AGENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_EDIT F_AGENT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_EDIT_EX F_AGENT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_EDIT_EX F_AGENT]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region F_agent_Delete

// USE /[MANUAL TRA CONTROLLER_DELETE_GET F_AGENT]/
		[HttpPost]
		public ActionResult F_agent_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_agent_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_agent_Delete_GET",
				AreaName = "agent",
				FormName = "F_AGENT",
				Location = ACTION_F_AGENT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_agent();
// USE /[MANUAL TRA BEFORE_LOAD_DELETE F_AGENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DELETE F_AGENT]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Agent/F_agent_Delete
// USE /[MANUAL TRA CONTROLLER_DELETE_POST F_AGENT]/
		[HttpPost]
		public ActionResult F_agent_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_agent_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "F_agent_Delete",
				ViewName = "F_agent",
				AreaName = "agent",
				Location = ACTION_F_AGENT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_DESTROY_DELETE F_AGENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_DESTROY_DELETE F_AGENT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult F_agent_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_AGENT");
		}

		#endregion

		#region F_agent_Duplicate

// USE /[MANUAL TRA CONTROLLER_DUPLICATE_GET F_AGENT]/

		[HttpPost]
		public ActionResult F_agent_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			F_agent_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_agent_Duplicate_GET",
				AreaName = "agent",
				FormName = "F_AGENT",
				Location = ACTION_F_AGENT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_DUPLICATE F_AGENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DUPLICATE F_AGENT]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Agent/F_agent_Duplicate
// USE /[MANUAL TRA CONTROLLER_DUPLICATE_POST F_AGENT]/
		[HttpPost]
		public ActionResult F_agent_Duplicate([FromBody]F_agent_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_agent_Duplicate",
				ViewName = "F_agent",
				AreaName = "agent",
				Location = ACTION_F_AGENT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_DUPLICATE F_AGENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_DUPLICATE F_AGENT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_DUPLICATE_EX F_AGENT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DUPLICATE_EX F_AGENT]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region F_agent_Cancel

		//
		// GET: /Agent/F_agent_Cancel
// USE /[MANUAL TRA CONTROLLER_CANCEL_GET F_AGENT]/
		public ActionResult F_agent_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Agent model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("agent");

// USE /[MANUAL TRA BEFORE_CANCEL F_AGENT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL TRA AFTER_CANCEL F_AGENT]/

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

				Navigation.SetValue("ForcePrimaryRead_agent", "true", true);
			}

			Navigation.ClearValue("agent");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Agent/F_agent_SaveEdit
		[HttpPost]
		public ActionResult F_agent_SaveEdit([FromBody] F_agent_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_agent_SaveEdit",
				ViewName = "F_agent",
				AreaName = "agent",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_APPLY_EDIT F_AGENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_APPLY_EDIT F_AGENT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_agentDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_agent_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_agent([FromBody] F_agentDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
