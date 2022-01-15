using Microsoft.AspNetCore.Mvc;
using MohammadpourBitCoinShowBitCoinPricesGraph_AspCore.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MohammadpourBitCoinShowBitCoinPricesGraph_AspCore.Controllers
{
    //Developed By Dr.R.Mohammadpour
    //Reza.Mohammadpour@gmail.com  0098-9177117407

    public class HomeController : Controller
    {
        static GraphData graphData = new GraphData();
        static List<GraphData> listGraphData = new List<GraphData> { graphData};

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCurrencyGraphData()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://min-api.cryptocompare.com/data/pricemulti?fsyms=BTC&tsyms=USD");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                Result result = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(jsonResponse);
                graphData.name = "BTC Prices";
                graphData.x.Add(DateTime.Now.ToLongTimeString().Replace(" PM","").Replace(" AM",""));
                graphData.y.Add(result.BTC.USD);
            }
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(listGraphData));
        }

    }
}
