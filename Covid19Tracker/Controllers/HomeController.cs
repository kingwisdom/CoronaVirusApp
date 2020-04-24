using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Covid19Tracker.Models;
using Covid19Tracker.Web.ViewModels;
using System.Net.Http;
using Newtonsoft.Json;
using Covid19Tracker.Data.DataContext;
using Covid19Tracker.Service.Services;

namespace Covid19Tracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICovid19CaseManagerService _covic;

        //private readonly Covid19TrackerDBContext _covic;



        public HomeController(ILogger<HomeController> logger, ICovid19CaseManagerService covic)
        //public HomeController(ILogger<HomeController> logger, Covid19TrackerDBContext covic)
        {
            _logger = logger;
            _covic = covic;

            //_covic = covic;
        }

        //var response = await httpClient.GetAsync("https://api.apify.com/v2/key-value-stores/Eb694wt67UxjdSGbc/records/LATEST?disableRedirect=true");


              
        public IActionResult Index()
        {

            // var model = _covic.RealCase.All(RealCase);
            var model = _covic.GetCases();

            var all = Convert.ToDouble(model.Sum(e=>e.Cases));
            var recov = Convert.ToDouble(model.Sum(e => e.Recorvered));
            var sicki = Convert.ToDouble(model.Sum(e => e.Sick));
            var deathy = Convert.ToDouble(model.Sum(e => e.Death));

            double a = recov / all;
            double Getrecoverbar = Math.Round(a * 100);
            double b = sicki / all;
            double Getsickbar = Math.Round(b * 100);
            double c = deathy / all;
            double Getdeathbar = Math.Round(c * 100);

            CasesViewModel cases = new CasesViewModel
            {
                AllCases = model,
                getrecoverbar = (Getrecoverbar),
                 getsickbar = (Getsickbar),
                getdeathbar = (Getdeathbar)

            };
            //var model =  _covid19CaseManager.GetAllCasesCount();

            return View(cases);
        }

        //public IActionResult Index()
        //{
        //    var all = Convert.ToDouble(_covid19CaseManager.GetAllCasesCount());
        //    var recov = Convert.ToDouble(_covid19CaseManager.GetAllRecoveriesCount());
        //    var sicki = Convert.ToDouble(_covid19CaseManager.GetAllSickCount());
        //    var deathy = Convert.ToDouble(_covid19CaseManager.GetAllDeathCount());
        //    double a = recov / all;
        //    double Getrecoverbar = Math.Round(a * 100);
        //    double b = sicki / all;
        //    double Getsickbar = Math.Round(b * 100);
        //    double c = deathy / all;
        //    double Getdeathbar = Math.Round(c * 100);
        //    CasesViewModel cases = new CasesViewModel
        //    {

        //        All = _covid19CaseManager.GetAllCasesCount(),
        //        Death = _covid19CaseManager.GetAllDeathCount(),
        //        Recorverd = _covid19CaseManager.GetAllRecoveriesCount(),
        //        Sick = _covid19CaseManager.GetAllSickCount(),
        //        getrecoverbar = (Getrecoverbar),
        //        getsickbar = (Getsickbar),
        //        getdeathbar = (Getdeathbar)
        //    };
        //    //var model = _covid19CaseManager.GetAllCasesCount();

        //    return View(cases);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
