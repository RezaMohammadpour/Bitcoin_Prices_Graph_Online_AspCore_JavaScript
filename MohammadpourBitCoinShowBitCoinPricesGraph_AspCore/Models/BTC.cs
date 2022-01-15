using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MohammadpourBitCoinShowBitCoinPricesGraph_AspCore.Models
{
    public class BTC
    {
        public double USD { get; set; }
    }

    public class Result
    {
        public BTC BTC { get; set; }
    }

    public class GraphData
    {
        public GraphData()
        {
            x = new List<string>();
            y = new List<double>();
            type = "scatter";
        }
        public string name { get; set; }
        public string type { get; set; }
        public List<string> x { get; set; }
        public List<double> y { get; set; }
    }
}
