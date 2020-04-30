using BadGangMinton.DAL;
using BadGangMinton.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace BadGangMinton.Session
{
    public class SessionManager
    {

        public Security UserSession
        {
            get
            {
                return (Security)HttpContext.Current.Session["Security"];
            }
            set
            {
                HttpContext.Current.Session["Security"] = value;

            }
        }

    }


}