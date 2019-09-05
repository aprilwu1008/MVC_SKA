using MVC_SKA.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC_SKA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult MoneyTemplate()
        {
            Random gen = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            var dateTime = start.AddDays(gen.Next(range));

            var moneyPartialViewModel = new MoneyPartialViewModel();
            moneyPartialViewModel.List = new List<Money>();

            for (var i = 1; i <= 50; i++)
            {
                moneyPartialViewModel.List.Add(
                    new Money
                    {
                        Seq = i,
                        MoneyType = gen.Next(0, 2) == 1 ? "支出" : "收入",
                        DateTime = start.AddDays(gen.Next(range)).ToString("yyyy-MM-dd"),
                        Count = gen.Next(1000)
                    });
            }

            return View(moneyPartialViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}