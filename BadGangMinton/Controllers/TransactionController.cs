using BadGangMinton.View.Model;
using BGO.Common;
using BGO.Contact;
using BGO.Member;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BadGangMinton.Controllers
{
    public class TransactionController : AdminController
    {

        public ActionResult AddTransaction()
        {
            TransactionViewModel txVM = new TransactionViewModel();
            List<Person> Member = new List<Person>();

            var data = mDal.GetMember(2).Where(x => x.Person.GroupId.HasValue == false && x.IsMembershipActive);
            foreach (var item in data)
            {
                Member.Add(cDal.GetPersonByPersonId(item.PersonId));
            }

            txVM.People = new SelectList(Member.OrderBy(o => o.Name), "Id", "Name");

            List<TransactionType> txTypes = new List<TransactionType>();
            txTypes = lookupDal.GetAllTransactionType().Where(x => x.Id != 2).ToList();
            txVM.TransactionTypes = new SelectList(txTypes, "Id", "Desc");

            return View(txVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveTransaction(TransactionViewModel txVM)
        {
            if (ModelState.IsValid)
            {
                var txTypeId = lookupDal.GetAllTransactionType().Where(x => x.Id == int.Parse(txVM.TransactionTypeId)).FirstOrDefault();
                string remarks = string.Empty;
                decimal amt = txVM.Amount;
                switch (txVM.TransactionTypeId)
                {
                    case "1":
                        remarks = $"Hey buddy, Thanks for your deposit of £ {amt} on {txVM.TransactionDate.Value.ToShortDateString()}";
                        break;

                    case "2":
                        remarks = $"Well done buddy! You played well today on {txVM.TransactionDate.Value.ToShortDateString()} and you have been charged {2.5M} for today's game. Keep it up!";
                        break;

                    case "3":
                        amt = Math.Round(amt / txVM.PersonId.Count(), 4);
                        remarks = $"Hey buddy, You have shared the expense of £ {amt} on {txVM.TransactionDate.Value.ToShortDateString()}";
                        break;

                    case "4":
                        amt = Math.Round(amt / txVM.PersonId.Count(), 4);
                        remarks = $"Hey buddy, You have shared the expense type 2 of £ {amt} on {txVM.TransactionDate.Value.ToShortDateString()}";
                        break;
                }

                foreach (var item in txVM.PersonId)
                {
                    txDAL.saveTransaction(int.Parse(item), txTypeId.Id, amt * txTypeId.Multiplier, txVM.TransactionDate, remarks);

                    #region EMail
                    var person = cDal.GetPersonByPersonId(int.Parse(item));
                    Dictionary<string, string> param = new Dictionary<string, string>();
                    param.Add("NAME", $"{person.Name}");
                    param.Add("MESSAGE", $"{remarks}");
                    string html = bgService.GetHtml(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["mxTemplatePath"] + "tmpPayment.html", param);

                    person.PersonEmail = cDal.GetPersonEmailByPersonId(person.Id);
                    var mxType = lookupDal.GetAllMailoutType().Where(x => x.Id == 9).FirstOrDefault();

                    var q = mxDAL.PushNotification(person, param, mxType.Id, person.PersonEmail.Where(t => t.Type.Id == 1).FirstOrDefault().Value, html);

                    var res = emailService.EmailBySMTP(person.PersonEmail.Where(t => t.Type.Id == 1).FirstOrDefault().Value, ConfigurationManager.AppSettings["SMTP_FROM"], html, mxType.Subject);

                    if (res.HasError)
                    {
                        sDal.LogMe("EMAILEXCEPTION", $"EMAIL EXCEPTION: {res.ErrorMessage}", person.Id);

                        mxDAL.UpdateNotification(q.Id);
                    }



                    #endregion
                }

                return RedirectToAction("TransactionList", new { txTypeId = 2 });
            }
            return View(txVM);
        }

        public ActionResult TransactionList(int txTypeId, int personId)
        {
            var tx = txDAL.GetTransactionList(txTypeId,personId);

            //if (personId.HasValue)
            //{
            //    tx = txDAL.GetTransaction(personId.Value).Where(x => x.TransactionTypeId == txTypeId);
            //}

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
            return View(txVM);
        }

        public ActionResult DeleteTx(int? id)
        {
            txDAL.DeleteTransaction(id.Value);
            return RedirectToAction("TransactionList", "Transaction", new { txTypeId = 2 });
        }

        public ActionResult TransactionFilter()
        {
            TxFilterViewModel vm = new TxFilterViewModel();

            List<Member> players = new List<Member>();
            List<TransactionType> txTypes = new List<TransactionType>();

            players = mDal.GetMember(2).OrderBy(o=>o.Person.Fname).ToList();
            txTypes = lookupDal.GetAllTransactionType();

            vm.Players = new SelectList(players, "Person.Id", "Person.Name");
            vm.TxTypes = new SelectList(txTypes, "Id", "Name");

            return PartialView("_TransactionFilter", vm);
        }
    }
}