using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using TwilioSmsPractice.Models;

namespace TwilioSmsPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Index()
        {
            var accountSid = _configuration["Data:Sid"];
            var authToken =_configuration["Data2:Token"];
            TwilioClient.Init(accountSid, authToken);
            var to = new PhoneNumber(_configuration["DataNumber:MyPhoneNumber"]);
            var from = new PhoneNumber("+12342184945");
            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Please you have an order, check-out: smartcode.azurewebsites.net");

            return View();
        }

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
