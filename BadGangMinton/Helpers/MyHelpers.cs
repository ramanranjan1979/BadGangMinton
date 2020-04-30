using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace BadGangMinton.Helpers
{
    public static class BGHelper
    {
        public static string ComputeHash(string str)
        {
            SHA1Managed sha1m = new SHA1Managed();
            var temp = sha1m.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str));
            string passwordHash = "";
            foreach (var _byte in temp)
            {
                passwordHash = passwordHash + _byte.ToString("X2");
            }

            return passwordHash;
        }
    }

    public static class TimeZoneHelper
    {
        public static DateTime ToTimeZoneTime(this DateTime time, string timezoneId = "Indian Standard Time")
        {
            return TimeZoneInfo.ConvertTimeFromUtc(time, TimeZoneInfo.FindSystemTimeZoneById(timezoneId));
        }
    }

    public static class MyHelpers
    {
        // Render BootStrap menu item with active class
        public static MvcHtmlString MenuItem(this HtmlHelper htmlHelper,
                                             string text, string action,
                                             string controller,
                                             object routeValues = null,
                                             object htmlAttributes = null)
        {
            var li = new TagBuilder("li");
            var routeData = htmlHelper.ViewContext.RouteData;
            var currentAction = routeData.GetRequiredString("action");
            var currentController = routeData.GetRequiredString("controller");
            if (string.Equals(currentAction,
                              action,
                              StringComparison.OrdinalIgnoreCase) &&
                string.Equals(currentController,
                              controller,
                              StringComparison.OrdinalIgnoreCase))
            {
                li.AddCssClass("active");
            }
            if (routeValues != null)
            {
                li.InnerHtml = (htmlAttributes != null)
                    ? htmlHelper.ActionLink(text,
                                            action,
                                            controller,
                                            routeValues,
                                            htmlAttributes).ToHtmlString()
                    : htmlHelper.ActionLink(text,
                                            action,
                                            controller,
                                            routeValues).ToHtmlString();
            }
            else
            {
                li.InnerHtml = (htmlAttributes != null)
                    ? htmlHelper.ActionLink(text,
                                            action,
                                            controller,
                                            null,
                                            htmlAttributes).ToHtmlString()
                    : htmlHelper.ActionLink(text,
                                            action,
                                            controller).ToHtmlString();
            }
            return MvcHtmlString.Create(li.ToString());
        }


        // As the text the: "<span class='glyphicon glyphicon-plus'></span>" can be entered
        public static MvcHtmlString NoEncodeActionLink(this HtmlHelper htmlHelper,
                                             string text, string title, string action,
                                             string controller,
                                             object routeValues = null,
                                             object htmlAttributes = null)
        {
            UrlHelper urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            TagBuilder  builder = new TagBuilder("a");
            builder.InnerHtml = text;
            builder.Attributes["title"] = title;
            builder.Attributes["href"] = urlHelper.Action(action, controller, routeValues);
            builder.MergeAttributes(new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));

            return MvcHtmlString.Create(builder.ToString());
        }


        public static bool ValidateFileBeforeUpload(HttpPostedFileBase file, int maxFileLengthInMB, string fileExtensions)
        {
            bool okToUpload = true;
            if (file == null)
            {
                okToUpload = false;
            }

            if (file.ContentLength > 0)
            {
                string[] AllowedFileExtensions = fileExtensions.Split(',');
                if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                {
                    okToUpload = false;
                }

                else if (file.ContentLength > maxFileLengthInMB)
                {
                    okToUpload = false;
                }
                else
                {
                    okToUpload = true;
                }
            }
            else
            {
                okToUpload = false;
            }

            return okToUpload;
        }

    }

    /// <summary>
    /// JQuery UI DatePicker helper.
    /// </summary>
    public static class JQueryUIDatePickerHelper
    {
        /// <summary>
        /// Converts the .net supported date format current culture 
        /// format into JQuery Datepicker format.
        /// </summary>
        /// <param name="html">HtmlHelper object.</param>
        /// <returns>Format string that supported in JQuery Datepicker.</returns>
        public static string ConvertDateFormat(this HtmlHelper html)
        {
            return ConvertDateFormat(html,Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern);
        }

        /// <summary>
        /// Converts the .net supported date format current culture 
        /// format into JQuery Datepicker format.
        /// </summary>
        /// <param name="html">HtmlHelper object.</param>
        /// <param name="format">Date format supported by .NET.</param>
        /// <returns>Format string that supported in JQuery Datepicker.</returns>
        public static string ConvertDateFormat(this HtmlHelper html, string format)
        {
            /*
             *  Date used in this comment : 5th - Nov - 2009 (Thursday)
             *
             *  .NET    JQueryUI        Output      Comment
             *  --------------------------------------------------------------
             *  d       d               5           day of month(No leading zero)
             *  dd      dd              05          day of month(two digit)
             *  ddd     D               Thu         day short name
             *  dddd    DD              Thursday    day long name
             *  M       m               11          month of year(No leading zero)
             *  MM      mm              11          month of year(two digit)
             *  MMM     M               Nov         month name short
             *  MMMM    MM              November    month name long.
             *  yy      y               09          Year(two digit)
             *  yyyy    yy              2009        Year(four digit)             *
             */

            string currentFormat = format;

            // Convert the date
            currentFormat = currentFormat.Replace("dddd", "DD");
            currentFormat = currentFormat.Replace("ddd", "D");

            // Convert month
            if (currentFormat.Contains("MMMM"))
            {
                currentFormat = currentFormat.Replace("MMMM", "MM");
            }
            else if (currentFormat.Contains("MMM"))
            {
                currentFormat = currentFormat.Replace("MMM", "M");
            }
            else if (currentFormat.Contains("MM"))
            {
                currentFormat = currentFormat.Replace("MM", "mm");
            }
            else
            {
                currentFormat = currentFormat.Replace("M", "m");
            }

            // Convert year
            currentFormat = currentFormat.Contains("yyyy") ?currentFormat.Replace("yyyy", "yy") : currentFormat.Replace("yy", "y");

            return currentFormat;
        }
    }
}