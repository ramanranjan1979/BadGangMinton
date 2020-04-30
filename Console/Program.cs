using BadGangMinton.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BGO.Member;
using System.Configuration;

namespace Mailouts
{
    class Program
    {
        protected static LookupDal lookupDal = new LookupDal();
        protected static ContactDal cDal = new ContactDal();
        protected static SecurityDal sDal = new SecurityDal();
        protected static MemberDal mDal = new MemberDal();
        protected static TransactionDal txDAL = new TransactionDal();
        protected static MxDal mxDAL = new MxDal();
        protected static BadGangMinton.Helpers.BGService bgService = new BadGangMinton.Helpers.BGService();
        protected static BadGangMinton.Helpers.EmailService emailService = new BadGangMinton.Helpers.EmailService(bool.Parse(ConfigurationManager.AppSettings["TESTMODE"]), System.Web.HttpContext.Current);

        static void Main(string[] args)
        {

            var data = mDal.GetMember(2).Where(x => x.Person.IsActive).Where(m => m.IsActive && !m.Person.GroupId.HasValue && m.IsMembershipActive);

            foreach (var player in data)
            {
                bool flag = true;

                var lastEmail = mxDAL.GetAllMailouts(player.PersonId).Where(x => x.MailoutTypeId == 7).OrderByDescending(x => x.CreatedOn).FirstOrDefault();

                if (lastEmail != null)
                {
                    if ((DateTime.Now - lastEmail.CreatedOn).TotalDays < 6)
                    {
                        flag = false;
                    }
                }

                if (flag)
                {
                    Notify_Account_Balance(player);
                }
            }


        }

        private static void Notify_Account_Balance(Member player)
        {
            Console.WriteLine($"Sending notification to {player.Person.Name}");

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("NAME", player.Person.Name);
            param.Add("Balance", txDAL.GetAccountBalance(player.PersonId).ToString());

            string html = bgService.GetHtml(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["mxTemplatePath"] + "tmpInvoice.html", param);

            var mxType = lookupDal.GetAllMailoutType().Where(x => x.Id == 7).FirstOrDefault();

            string toEmail = cDal.GetPersonEmailByPersonId(player.PersonId).Where(x => x.Type.Id == 1).FirstOrDefault().Value;

            var q = mxDAL.PushNotification(player.Person, param, mxType.Id, toEmail, html);

            var res = emailService.EmailBySMTP(toEmail, ConfigurationManager.AppSettings["SMTP_FROM"], html, mxType.Subject);

            if (res.HasError)
            {
                sDal.LogMe("EMAILEXCEPTION", $"EMAIL EXCEPTION: {res.ErrorMessage}", player.PersonId);

                mxDAL.UpdateNotification(q.Id);
            }
        }
    }
}
