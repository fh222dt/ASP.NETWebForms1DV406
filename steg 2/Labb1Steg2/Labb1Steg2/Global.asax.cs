using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Labb1Steg2.App_Code;
using System.Web.UI;

namespace Labb1Steg2
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Gallery.PhysicalApplicationPath = Server.MapPath("~/img/");

            var jQuery = new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-2.0.3.min.js",
                DebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.0.3.min.js",
                CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.0.3.min.js"
            };

            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", jQuery);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}