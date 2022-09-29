using CLIENT.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CLIENT.Controllers
{
    public class AccountController : Controller
    {
        string address;
        HttpClient HttpClient;
        public AccountController()
        {
            this.address = "https://localhost:44351/api/Account/";
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(Login login)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                return (RedirectToAction("Index", "Home"));
            }

            return View("Index","Account");
        }
    }
}
