using Core_WebAPP.Data;
using Core_WebAPP.Data.Repository;
using Core_WebAPP.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core_WebAPP.controllers
{
    public class AppController : Controller
    {
        private readonly IRepository _dbcontext;
        private readonly ILogger<AppController> _log;

        public AppController(IRepository dbcontext,ILogger<AppController> log)
        {
            _dbcontext = dbcontext;
            _log = log;
        }
        public async Task<IActionResult> Index()
        {
            var contacts = new List<Contact>();

            using(var request=new HttpClient())
            {
                using(var response = await request.GetAsync("http://localhost:54457/api/contact"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    contacts = JsonConvert.DeserializeObject<List<Contact>>(apiResponse);
                }
            }
            return View(contacts);
        }
        [Authorize]
        public IActionResult Contact()
        {
            //throw new InvalidOperationException("Something is wrong in code...");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(Contact model)
        {
            if (ModelState.IsValid)
            {
                using (var request = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    using (var response = await request.PostAsync("http://localhost:54457/api/contact", content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.Created)
                        {
                            return RedirectToAction("Index", "App");
                        }
                    }
                }
            }
            else
            {
                return View(model);
            }
            return View(model);
        }
        [HttpGet("About")]
        public IActionResult About()
        {
            return View();
        }
        public IActionResult ContactList()
        {
            var contactList = _dbcontext.AllContact();               
            return View(contactList);
        }
    }
}
