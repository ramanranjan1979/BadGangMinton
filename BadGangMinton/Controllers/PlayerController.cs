using BadGangMinton.View.Model;
using BGO.Contact;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BadGangMinton.Controllers
{
    public class PlayerController : AdminController
    {
        public ActionResult PlayerList()
        {
            var data = mDal.GetMember(2).Where(x => x.Person.IsActive).Where(m => m.IsActive);
            return View(data);
        }

        public ActionResult AddPlayer()
        {
            MemberViewModel model = new MemberViewModel();
            model.PotentialMember = mDal.GetPotentialMember(2);
            if (model.PotentialMember.Count == 0)
            {
                return RedirectToAction("Add", "Contact");
            }
            return View(model);
        }

        public ActionResult Attendance()
        {
            AttendanceViewModel attVM = new AttendanceViewModel();
            List<Person> Member = new List<Person>();
            var data = mDal.GetMember(2).Where(x => x.Person.IsActive).Where(m => m.IsActive && m.IsMembershipActive);
            foreach (var item in data)
            {
                Member.Add(cDal.GetPersonByPersonId(item.PersonId));
            }
            attVM.Members = new SelectList(Member.OrderBy(o => o.Name), "Id", "Name");
            return View(attVM);
        }

        public ActionResult AttendanceNew(DateTime? attdate)
        {
            AttendanceViewModel attVM = new AttendanceViewModel();
            List<Person> Member = new List<Person>();
            var data = mDal.GetMember(2).Where(x => x.Person.IsActive).Where(m => m.IsActive && m.IsMembershipActive);
            foreach (var item in data)
            {
                Member.Add(cDal.GetPersonByPersonId(item.PersonId));
            }
            attVM.Members = new SelectList(Member.OrderBy(o => o.Name), "Id", "Name");

            if (attdate.HasValue)
            {
                attVM.AttDate = attdate.Value;
            }


            return View("AttendanceNew", attVM);
        }


        public JsonResult SaveAttendance(string[] Playervalue, DateTime attendanceDate)
        {
            if (Playervalue != null)
            {
                List<int> CurrentAttendant = new List<int>();
                foreach (var item in Playervalue)
                {
                    txDAL.saveAttendance(int.Parse(item), attendanceDate.Date);

                    var tx = lookupDal.GetAllTransactionType().Where(x => x.Id == 2).FirstOrDefault();

                    var p = cDal.GetPersonByPersonId(int.Parse(item));

                    if (p.GroupId.HasValue)
                    {
                        //txDAL.saveTransaction(p.Group.Id, tx.Id, 2.5M * tx.Multiplier, attendanceDate, $"Bravo! Your buddy { p.Name} has played well on {attendanceDate.Date.ToShortDateString()} and you have been charged £ {2.5M} for today's game. Keep it up!", true);
                        txDAL.saveTransaction(p.Id, tx.Id, 2.5M * tx.Multiplier, attendanceDate, $"Bravo! Your buddy { p.Name} has played well on {attendanceDate.Date.ToShortDateString()} and you have been charged £ {2.5M} for today's game. Keep it up!", true);
                    }
                    else
                    {

                        txDAL.saveTransaction(int.Parse(item), tx.Id, 2.5M * tx.Multiplier, attendanceDate, $"Well done buddy! You played well today on {attendanceDate.Date.ToShortDateString()} and you have been charged £ {2.5M} for today's game. Keep it up!");
                    }

                    CurrentAttendant.Add(int.Parse(item));
                }

                var OldData = txDAL.GetAttendanceByDate(attendanceDate);

                foreach (var d in OldData)
                {
                    if (!CurrentAttendant.Contains(d.Person.Id))
                    {
                        txDAL.MapAttendance(d.Person.Id, attendanceDate);
                    }
                }

            }
            return Json("OK");
        }

        public JsonResult SaveAttendanceNew(string[] Playervalue, DateTime attendanceDate, string unit)
        {
            if (Playervalue != null)
            {
                List<int> CurrentAttendant = new List<int>();
                decimal qty = 1M;
                string unitWording = string.Empty;
                foreach (var item in Playervalue)
                {
                    txDAL.saveAttendance(int.Parse(item), attendanceDate.Date);

                    var tx = lookupDal.GetAllTransactionType().Where(x => x.Id == 2).FirstOrDefault();

                    var p = cDal.GetPersonByPersonId(int.Parse(item));

                    switch (unit.ToLower())
                    {
                        case "halfunit":
                            qty = 0.5M;
                            unitWording = "30 minutes";
                            break;

                        case "oneunit":
                            qty = 1.0M;
                            unitWording = "1 hour";
                            break;

                        case "oneandhalfunit":
                            qty = 1.5M;
                            unitWording = "1 hour 30 minutes";
                            break;

                        case "twounit":
                            qty = 2.0M;
                            unitWording = "02 hours";
                            break;
                    }

                    if (p.GroupId.HasValue)
                    {
                        //txDAL.saveTransaction(p.Group.Id, tx.Id, 2.5M * tx.Multiplier, attendanceDate, $"Bravo! Your buddy { p.Name} has played well on {attendanceDate.Date.ToShortDateString()} and you have been charged £ {2.5M} for today's game. Keep it up!", true);
                        txDAL.saveTransaction(p.Id, tx.Id, qty * 2.5M * tx.Multiplier, attendanceDate, $"Bravo! Your buddy { p.Name} has played well on {attendanceDate.Date.ToShortDateString()} and you have been charged £ {qty * 2.5M} for today's game. Keep it up!", true);
                    }
                    else
                    {

                        txDAL.saveTransaction(int.Parse(item), tx.Id, qty * 2.5M * tx.Multiplier, attendanceDate, $"Well done buddy! You played well today on {attendanceDate.Date.ToShortDateString()} and you have been charged £ {qty * 2.5M} for today's game. Keep it up!");
                    }

                    try
                    {
                        Dictionary<string, string> param = new Dictionary<string, string>();
                        param.Add("NAME", p.Name);
                        param.Add("AMOUNT", "£" + (-1 * qty * 2.5M * tx.Multiplier).ToString("0.00"));
                        param.Add("UNITS", unitWording);

                        string html = bgService.GetHtml(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["mxTemplatePath"] + "tmpAttendance.html", param);

                        var mxType = lookupDal.GetAllMailoutType().Where(x => x.Id == 8).FirstOrDefault();

                        string toEmail = cDal.GetPersonEmailByPersonId(p.Id).Where(x => x.Type.Id == 1).FirstOrDefault().Value;

                        var q = mxDAL.PushNotification(p, param, mxType.Id, toEmail, html);

                        var res = emailService.EmailBySMTP(toEmail, ConfigurationManager.AppSettings["SMTP_FROM"], html, mxType.Subject);

                        if (res.HasError)
                        {
                            sDal.LogMe("EMAILEXCEPTION", $"EMAIL EXCEPTION: {res.ErrorMessage}", p.Id);

                            mxDAL.UpdateNotification(q.Id);
                        }
                    }
                    catch (Exception ex)
                    {
                        sDal.LogMe("EMAILEXCEPTION", $"EMAIL EXCEPTION: {ex.Message}", p.Id);
                    }
                }

            }
            return Json("OK");
        }

        public JsonResult DeleteAttendance(string[] Playervalue, DateTime attendanceDate)
        {
            if (Playervalue != null)
            {
                foreach (var item in Playervalue)
                {
                    txDAL.MapAttendance(int.Parse(item), attendanceDate);
                }
            }
            return Json("OK");
        }

        public JsonResult AddNewPlayer(int PersonId, DateTime DOJ)
        {
            mDal.CreateMember(PersonId, DOJ, 2);
            return Json("OK");
        }

        public JsonResult GetPlayerAttendance(DateTime attendanceDate)
        {
            var players = txDAL.GetAttendanceByDate(attendanceDate);
            return Json(players);
        }

        public ActionResult GetPlayerAccountBalanceDetails(int personId)
        {
            var tx = txDAL.GetTransaction(personId).OrderByDescending(o => o.TransactionDate);
            List<TransactionListViewModel> txVM = new List<TransactionListViewModel>();
            foreach (var t in tx)
            {
                txVM.Add(new TransactionListViewModel()
                {
                    Amount = t.Amount,
                    TransactionTypes = new SelectList(lookupDal.GetAllTransactionType(), "Id", "Name"),
                    Person = t.Person,
                    TransactionDate = t.TransactionDate,
                    TransactionType = lookupDal.GetAllTransactionType().Where(x => x.Id == t.TransactionTypeId).FirstOrDefault(),
                    TransactionId = t.Id,
                    Remarks = string.IsNullOrEmpty(t.Remarks) ? "N/A" : t.Remarks
                });
            }
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(txVM), "application/json");
        }

        public ActionResult Suspend(int? id)
        {
            sDal.LogMe("TRACKING", "Membership has been suspend", id.Value);
            return RedirectToAction("PlayerList");
        }

        public ActionResult Activate(int? id)
        {
            sDal.DeleteLog(2, "Membership has been suspend", id.Value);
            return RedirectToAction("PlayerList");
        }
    }
}