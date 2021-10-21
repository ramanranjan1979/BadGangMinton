using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace BadGangMinton.Helpers
{
    public class BGService
    {
        public  string GetHtml(string templatePath, Dictionary<string, string> Parameters)
        {
            var rawString = System.IO.File.ReadAllText(templatePath);
            foreach (var parameter in Parameters)
            {
                if (rawString.Contains("{#" + parameter.Key.ToUpper() + "#}"))
                {
                    rawString = rawString.Replace("{#" + parameter.Key.ToUpper() + "#}", parameter.Value);
                }
            }

            return rawString;
        }
    }

    public class EmailResponse
    {
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
    }


    public class EmailService
    {
        private bool _testMode;
        private HttpContext _currentContext;

        public EmailService(bool TestMode, HttpContext Context)
        {
            _testMode = TestMode;
            _currentContext = Context;
        }

        public EmailResponse EmailBySMTP(string toEmailAddress, string fromAddress, string body, string subject)
        {
            EmailResponse res = new EmailResponse() { HasError = false, ErrorMessage = string.Empty };

            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();
            m.From = new MailAddress(fromAddress);
            m.To.Add(_testMode ? ConfigurationManager.AppSettings["SMTP_TO"] : toEmailAddress);
            m.Subject = subject;
            m.Body = body;
            sc.Host = ConfigurationManager.AppSettings["SMTP_HOST"];
            //string str1 = "gmail.com";
            //if (fromAddress.ToLower().Contains(str1))
            //{
                try
                {
                    sc.Port = 25;
                    sc.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTP_UserName"], ConfigurationManager.AppSettings["SMTP_Password"]);
                    sc.EnableSsl = true;
                    m.IsBodyHtml = true;

                    if (!_testMode)
                        sc.Send(m);
                }
                catch (Exception ex)
                {
                    res.HasError = true;
                    res.ErrorMessage = ex.Message;
                }
            //}
            //else
            //{
            //    try
            //    {
            //        sc.Port = 25;
            //        sc.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTP_UserName"], ConfigurationManager.AppSettings["SMTP_Password"]);
            //        sc.EnableSsl = false;
            //        m.IsBodyHtml = true;
            //        if (!_testMode)
            //            sc.Send(m);

            //    }
            //    catch (Exception ex)
            //    {
            //        res.HasError = true;
            //        res.ErrorMessage = ex.Message;
            //    }
            //}

            return res;
        }

      
    }
}