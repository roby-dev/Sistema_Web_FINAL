using InfoCodiv19.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InfoCodiv19.Controllers
{
    public class MapaCovidController : Controller
    {
        // GET: MapaCovid
        public ActionResult Index()
        {
            return View();
        }

        //https://disease.sh/v3/covid-19/countries/?fbclid=IwAR2-XmKH-LarYzqUoYSv12scKFb09HR3sPbHUABDkM3y8phu1qHCqK4gurU

        public async Task<ActionResult> Get_Paises()
        {
            HttpClient client = new HttpClient();
            String URL2 = "https://disease.sh/v3/covid-19/countries/?fbclid=IwAR2-XmKH-LarYzqUoYSv12scKFb09HR3sPbHUABDkM3y8phu1qHCqK4gurU";
                      
            HttpResponseMessage response = await client.GetAsync(URL2);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<ClsMapaCovid>(data);
                return Json(product, JsonRequestBehavior.AllowGet);
            }

            return Json("sin Datos", JsonRequestBehavior.AllowGet);

        }
    }
}