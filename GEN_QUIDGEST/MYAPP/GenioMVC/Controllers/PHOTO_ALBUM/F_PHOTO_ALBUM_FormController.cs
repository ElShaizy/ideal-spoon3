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
using GenioMVC.ViewModels.Photo_album;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL TRA INCLUDE_CONTROLLER PHOTO_ALBUM]/

namespace GenioMVC.Controllers
{
	public partial class Photo_albumController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_PHOTO_ALBUM_CANCEL = new("PHOTO_ALBUM31847", "F_photo_album_Cancel", "Photo_album") { vueRouteName = "form-F_PHOTO_ALBUM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_PHOTO_ALBUM_SHOW = new("PHOTO_ALBUM31847", "F_photo_album_Show", "Photo_album") { vueRouteName = "form-F_PHOTO_ALBUM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_PHOTO_ALBUM_NEW = new("PHOTO_ALBUM31847", "F_photo_album_New", "Photo_album") { vueRouteName = "form-F_PHOTO_ALBUM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_PHOTO_ALBUM_EDIT = new("PHOTO_ALBUM31847", "F_photo_album_Edit", "Photo_album") { vueRouteName = "form-F_PHOTO_ALBUM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_PHOTO_ALBUM_DUPLICATE = new("PHOTO_ALBUM31847", "F_photo_album_Duplicate", "Photo_album") { vueRouteName = "form-F_PHOTO_ALBUM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_PHOTO_ALBUM_DELETE = new("PHOTO_ALBUM31847", "F_photo_album_Delete", "Photo_album") { vueRouteName = "form-F_PHOTO_ALBUM", mode = "DELETE" };

		#endregion

		#region F_photo_album private

		private void FormHistoryLimits_F_photo_album()
		{

		}

		#endregion

		#region F_photo_album_Show

// USE /[MANUAL TRA CONTROLLER_SHOW F_PHOTO_ALBUM]/

		[HttpPost]
		public ActionResult F_photo_album_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_photo_album_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_photo_album_Show_GET",
				AreaName = "photo_album",
				Location = ACTION_F_PHOTO_ALBUM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_photo_album();
// USE /[MANUAL TRA BEFORE_LOAD_SHOW F_PHOTO_ALBUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_SHOW F_PHOTO_ALBUM]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region F_photo_album_New

// USE /[MANUAL TRA CONTROLLER_NEW_GET F_PHOTO_ALBUM]/
		[HttpPost]
		public ActionResult F_photo_album_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			F_photo_album_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_photo_album_New_GET",
				AreaName = "photo_album",
				FormName = "F_PHOTO_ALBUM",
				Location = ACTION_F_PHOTO_ALBUM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_photo_album();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_NEW F_PHOTO_ALBUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_NEW F_PHOTO_ALBUM]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Photo_album/F_photo_album_New
// USE /[MANUAL TRA CONTROLLER_NEW_POST F_PHOTO_ALBUM]/
		[HttpPost]
		public ActionResult F_photo_album_New([FromBody]F_photo_album_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_photo_album_New",
				ViewName = "F_photo_album",
				AreaName = "photo_album",
				Location = ACTION_F_PHOTO_ALBUM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_NEW F_PHOTO_ALBUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_NEW F_PHOTO_ALBUM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_NEW_EX F_PHOTO_ALBUM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_NEW_EX F_PHOTO_ALBUM]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region F_photo_album_Edit

// USE /[MANUAL TRA CONTROLLER_EDIT_GET F_PHOTO_ALBUM]/
		[HttpPost]
		public ActionResult F_photo_album_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_photo_album_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_photo_album_Edit_GET",
				AreaName = "photo_album",
				FormName = "F_PHOTO_ALBUM",
				Location = ACTION_F_PHOTO_ALBUM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_photo_album();
// USE /[MANUAL TRA BEFORE_LOAD_EDIT F_PHOTO_ALBUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_EDIT F_PHOTO_ALBUM]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Photo_album/F_photo_album_Edit
// USE /[MANUAL TRA CONTROLLER_EDIT_POST F_PHOTO_ALBUM]/
		[HttpPost]
		public ActionResult F_photo_album_Edit([FromBody]F_photo_album_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_photo_album_Edit",
				ViewName = "F_photo_album",
				AreaName = "photo_album",
				Location = ACTION_F_PHOTO_ALBUM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_EDIT F_PHOTO_ALBUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_EDIT F_PHOTO_ALBUM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_EDIT_EX F_PHOTO_ALBUM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_EDIT_EX F_PHOTO_ALBUM]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region F_photo_album_Delete

// USE /[MANUAL TRA CONTROLLER_DELETE_GET F_PHOTO_ALBUM]/
		[HttpPost]
		public ActionResult F_photo_album_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_photo_album_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_photo_album_Delete_GET",
				AreaName = "photo_album",
				FormName = "F_PHOTO_ALBUM",
				Location = ACTION_F_PHOTO_ALBUM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_photo_album();
// USE /[MANUAL TRA BEFORE_LOAD_DELETE F_PHOTO_ALBUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DELETE F_PHOTO_ALBUM]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Photo_album/F_photo_album_Delete
// USE /[MANUAL TRA CONTROLLER_DELETE_POST F_PHOTO_ALBUM]/
		[HttpPost]
		public ActionResult F_photo_album_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			F_photo_album_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "F_photo_album_Delete",
				ViewName = "F_photo_album",
				AreaName = "photo_album",
				Location = ACTION_F_PHOTO_ALBUM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_DESTROY_DELETE F_PHOTO_ALBUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_DESTROY_DELETE F_PHOTO_ALBUM]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult F_photo_album_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_PHOTO_ALBUM");
		}

		#endregion

		#region F_photo_album_Duplicate

// USE /[MANUAL TRA CONTROLLER_DUPLICATE_GET F_PHOTO_ALBUM]/

		[HttpPost]
		public ActionResult F_photo_album_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			F_photo_album_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "F_photo_album_Duplicate_GET",
				AreaName = "photo_album",
				FormName = "F_PHOTO_ALBUM",
				Location = ACTION_F_PHOTO_ALBUM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_DUPLICATE F_PHOTO_ALBUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DUPLICATE F_PHOTO_ALBUM]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Photo_album/F_photo_album_Duplicate
// USE /[MANUAL TRA CONTROLLER_DUPLICATE_POST F_PHOTO_ALBUM]/
		[HttpPost]
		public ActionResult F_photo_album_Duplicate([FromBody]F_photo_album_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_photo_album_Duplicate",
				ViewName = "F_photo_album",
				AreaName = "photo_album",
				Location = ACTION_F_PHOTO_ALBUM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_DUPLICATE F_PHOTO_ALBUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_DUPLICATE F_PHOTO_ALBUM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_DUPLICATE_EX F_PHOTO_ALBUM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DUPLICATE_EX F_PHOTO_ALBUM]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region F_photo_album_Cancel

		//
		// GET: /Photo_album/F_photo_album_Cancel
// USE /[MANUAL TRA CONTROLLER_CANCEL_GET F_PHOTO_ALBUM]/
		public ActionResult F_photo_album_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Photo_album model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("photo_album");

// USE /[MANUAL TRA BEFORE_CANCEL F_PHOTO_ALBUM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL TRA AFTER_CANCEL F_PHOTO_ALBUM]/

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

				Navigation.SetValue("ForcePrimaryRead_photo_album", "true", true);
			}

			Navigation.ClearValue("photo_album");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class F_photo_album_PropertiesValTitleModel : RequestLookupModel
		{
			public F_photo_album_ViewModel Model { get; set; }
		}

		//
		// GET: /Photo_album/F_photo_album_PropertiesValTitle
		// POST: /Photo_album/F_photo_album_PropertiesValTitle
		[ActionName("F_photo_album_PropertiesValTitle")]
		public ActionResult F_photo_album_PropertiesValTitle([FromBody] F_photo_album_PropertiesValTitleModel requestModel)
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

			Models.Photo_album parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			F_photo_album_PropertiesValTitle_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Photo_album/F_photo_album_SaveEdit
		[HttpPost]
		public ActionResult F_photo_album_SaveEdit([FromBody] F_photo_album_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_photo_album_SaveEdit",
				ViewName = "F_photo_album",
				AreaName = "photo_album",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_APPLY_EDIT F_PHOTO_ALBUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_APPLY_EDIT F_PHOTO_ALBUM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_photo_albumDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_photo_album_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_photo_album([FromBody] F_photo_albumDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
