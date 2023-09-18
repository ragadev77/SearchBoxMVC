
using CCWebApp.Repositories;
using CCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;

namespace CCWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICardRepository repository;

        //private readonly ILogger<HomeController> _logger;

        public HomeController(ICardRepository iccRepository)
        {
            this.repository = iccRepository;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Search()
        {
            return View();
        }
        
        /// <summary>
        /// Search By Account Number
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public IActionResult DoSearch(string accountNumber)
        {
            List<Account> searchResults = new List<Account>();
            if (!string.IsNullOrWhiteSpace(accountNumber) && accountNumber.Length >= 5)
            {
                searchResults = (List<Account>)repository.GetByAccountNo(accountNumber);
            }

            return PartialView("_SearchResults", searchResults);
        }

        /// <summary>
        /// List Account
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            List<Account> datas = new List<Account>();
            try
            {
                datas = repository.List_Account().Result.ToList();

            }
            catch (Exception ex)
            {
            }

            return View(datas);
        }

        public async Task<IActionResult> Customer()
        {
            List<Customer> datas = new List<Customer>();
            try
            {
                datas = repository.List_Customer().Result.ToList();

            }
            catch (Exception ex)
            {
            }

            return View(datas);
        }

        public async Task<IActionResult> Bank()
        {
            List<Bank> datas = new List<Bank>();
            try
            {
                datas = repository.List_Bank().Result.ToList();

            }
            catch (Exception ex)
            {
            }

            return View(datas);
        }
        //public IActionResult Index()
        //{
        //    return View();
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