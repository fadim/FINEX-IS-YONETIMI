using System;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Entity;

namespace Common
{
    public class SessionManager
    {
        public static string pcClientIp
        {
            get
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
        }

        public static enPersonel Admin
        {
            get
            {
                return HttpContext.Current.Session["admin"] as enPersonel;
            }
            set
            {
                HttpContext.Current.Session["admin"] = value;
            }
        }
    }
}
