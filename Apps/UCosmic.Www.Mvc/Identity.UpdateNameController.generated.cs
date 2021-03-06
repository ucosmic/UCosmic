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
    public partial class UpdateNameController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected UpdateNameController(Dummy d) { }

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
        public System.Web.Mvc.ActionResult Put() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Put);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public UpdateNameController Actions { get { return MVC.Identity.UpdateName; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Identity";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "UpdateName";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "UpdateName";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Get = "update-name";
            public readonly string Put = "update-name";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants {
            public const string Get = "update-name";
            public const string Put = "update-name";
        }


        static readonly ActionParamsClass_Put s_params_Put = new ActionParamsClass_Put();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Put PutParams { get { return s_params_Put; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Put {
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
    public class T4MVC_UpdateNameController: UCosmic.Www.Mvc.Areas.Identity.Controllers.UpdateNameController {
        public T4MVC_UpdateNameController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Get() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Get);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Put(UCosmic.Www.Mvc.Areas.Identity.Models.UpdateNameForm model) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Put);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
