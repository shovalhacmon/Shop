using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            Task.Run(() => FacebookAPI());
            return View();
        }

        private async Task<string> FacebookAPI()
        {
            string uri = "https://graph.facebook.com";
            string page = "1057497281124576/feed";
            string accessToken = "EAAER8aUNKcMBABZAlYFAk78VEfGA4kJJHrKbZBxPsq0nTHS6cF7M0FuDe2n0kul0MnMDnJrris0jsm2on8ommUYOAFCj1eRtGA5Gkod8I9vP6TbgCErbVUuZAojYeit5T26OucZAzZCOtbmzoTuXuhfwkek4V4KkDMpCBLvvNEwZDZD";
            string message = "New item added at " + DateTime.Now + "\nGo to our shop :)";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                var content = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>("message", message),
                        new KeyValuePair<string, string>("access_token", accessToken)
                });
                var result = await client.PostAsync(page, content);
                return await result.Content.ReadAsStringAsync();


            }
        }
    

            public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
