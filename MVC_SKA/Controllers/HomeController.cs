using MVC_SKA.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC_SKA.Controllers
{
    public class HomeController : Controller
    {
        private Random _random = new Random();
        private MoneyPartialViewModel _moneyPartialViewModel = new MoneyPartialViewModel();
        private List<Money> _monies = new List<Money>();

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult MoneyTemplate()
        {
            _moneyPartialViewModel.List = _monies;

            for (var i = 1; i <= 50; i++)
            {
                _moneyPartialViewModel.List.Add(
                    new Money
                    {
                        Seq = i,
                        MoneyType = IsMoneyType(),
                        DateTime = new DateTime(1995, 1, 1).AddDays(
                            _random.Next((DateTime.Today - new DateTime(1995, 1, 1)).Days))
                            .ToString("yyyy-MM-dd"),
                        Count = _random.Next(1000)
                    });
            }

            return View(_moneyPartialViewModel);
        }

        private string IsMoneyType()
        {
            return _random.Next(0, 2) == 1 ? "支出" : "收入";
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