// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace UCosmic.Www.Mvc.Areas.Identity.Controllers {
    public partial class UpdatePasswordController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected UpdatePasswordController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.JsonResult ValidateCurrentPassword() {
            return new T4MVC_JsonResult(Area, Name, ActionNames.ValidateCurrentPassword);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.JsonResult ValidateNewPasswordConfirmation() {
            return new T4MVC_JsonResult(Area, Name, ActionNames.ValidateNewPasswordConfirmation);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Post() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Post);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public UpdatePasswordController Actions { get { return MVC.Identity.UpdatePassword; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Identity";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "UpdatePassword";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "UpdatePassword";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Get = "update-password";
            public readonly string ValidateCurrentPassword = "ValidateCurrentPassword";
            public readonly string ValidateNewPasswordConfirmation = "ValidateNewPasswordConfirmation";
            public readonly string Post = "update-password";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants {
            public const string Get = "update-password";
            public const string ValidateCurrentPassword = "ValidateCurrentPassword";
            public const string ValidateNewPasswordConfirmation = "ValidateNewPasswordConfirmation";
            public const string Post = "update-password";
        }


        static readonly ActionParamsClass_ValidateCurrentPassword s_params_ValidateCurrentPassword = new ActionParamsClass_ValidateCurrentPassword();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ValidateCurrentPassword ValidateCurrentPasswordParams { get { return s_params_ValidateCurrentPassword; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ValidateCurrentPassword {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_ValidateNewPasswordConfirmation s_params_ValidateNewPasswordConfirmation = new ActionParamsClass_ValidateNewPasswordConfirmation();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ValidateNewPasswordConfirmation ValidateNewPasswordConfirmationParams { get { return s_params_ValidateNewPasswordConfirmation; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ValidateNewPasswordConfirmation {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_Post s_params_Post = new ActionParamsClass_Post();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Post PostParams { get { return s_params_Post; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Post {
            public readonly string model = "model";
        }
        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_UpdatePasswordController: UCosmic.Www.Mvc.Areas.Identity.Controllers.UpdatePasswordController {
        public T4MVC_UpdatePasswordController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Get() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Get);
            return callInfo;
        }

        public override System.Web.Mvc.JsonResult ValidateCurrentPassword(UCosmic.Www.Mvc.Areas.Identity.Models.UpdatePasswordForm model) {
            var callInfo = new T4MVC_JsonResult(Area, Name, ActionNames.ValidateCurrentPassword);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            return callInfo;
        }

        public override System.Web.Mvc.JsonResult ValidateNewPasswordConfirmation(UCosmic.Www.Mvc.Areas.Identity.Models.UpdatePasswordForm model) {
            var callInfo = new T4MVC_JsonResult(Area, Name, ActionNames.ValidateNewPasswordConfirmation);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Post(UCosmic.Www.Mvc.Areas.Identity.Models.UpdatePasswordForm model) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Post);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
