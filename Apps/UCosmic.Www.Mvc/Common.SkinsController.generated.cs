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
namespace UCosmic.Www.Mvc.Areas.Common.Controllers {
    public partial class SkinsController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected SkinsController(Dummy d) { }

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
        public System.Web.Mvc.RedirectResult Change() {
            return new T4MVC_RedirectResult(Area, Name, ActionNames.Change);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.PartialViewResult Apply() {
            return new T4MVC_PartialViewResult(Area, Name, ActionNames.Apply);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public SkinsController Actions { get { return MVC.Common.Skins; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Common";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Skins";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Skins";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Change = "Change";
            public readonly string Apply = "apply";
            public readonly string Logo = "logo";
            public readonly string Sample = "sample";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants {
            public const string Change = "Change";
            public const string Apply = "apply";
            public const string Logo = "logo";
            public const string Sample = "sample";
        }


        static readonly ActionParamsClass_Change s_params_Change = new ActionParamsClass_Change();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Change ChangeParams { get { return s_params_Change; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Change {
            public readonly string skinContext = "skinContext";
            public readonly string returnUrl = "returnUrl";
        }
        static readonly ActionParamsClass_Apply s_params_Apply = new ActionParamsClass_Apply();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Apply ApplyParams { get { return s_params_Apply; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Apply {
            public readonly string skinFile = "skinFile";
        }
        static readonly ActionParamsClass_Sample s_params_Sample = new ActionParamsClass_Sample();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Sample SampleParams { get { return s_params_Sample; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Sample {
            public readonly string content = "content";
        }
        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string apply = "~/Areas/Common/Views/Skins/apply.cshtml";
            public readonly string logo = "~/Areas/Common/Views/Skins/logo.cshtml";
            public readonly string sample_nav = "~/Areas/Common/Views/Skins/sample-nav.cshtml";
            public readonly string sample_right_column_a = "~/Areas/Common/Views/Skins/sample-right-column-a.cshtml";
            public readonly string sample = "~/Areas/Common/Views/Skins/sample.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_SkinsController: UCosmic.Www.Mvc.Areas.Common.Controllers.SkinsController {
        public T4MVC_SkinsController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.RedirectResult Change(string skinContext, string returnUrl) {
            var callInfo = new T4MVC_RedirectResult(Area, Name, ActionNames.Change);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "skinContext", skinContext);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            return callInfo;
        }

        public override System.Web.Mvc.PartialViewResult Apply(string skinFile) {
            var callInfo = new T4MVC_PartialViewResult(Area, Name, ActionNames.Apply);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "skinFile", skinFile);
            return callInfo;
        }

        public override System.Web.Mvc.PartialViewResult Logo() {
            var callInfo = new T4MVC_PartialViewResult(Area, Name, ActionNames.Logo);
            return callInfo;
        }

        public override System.Web.Mvc.ViewResult Sample(string content) {
            var callInfo = new T4MVC_ViewResult(Area, Name, ActionNames.Sample);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "content", content);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
