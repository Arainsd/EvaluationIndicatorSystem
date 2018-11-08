using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace EvaluationIndicatorSystem
{
    public static class JsonHelper
    {
        private static List<IndicatorOne> indicators = null;
        public static List<IndicatorOne> Indicators { get => indicators; set => indicators = value; }

        public static List<IndicatorOne> ReadIndicator()
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "/Indicators.json";
                if (!File.Exists(path)) return null;
                string content = File.ReadAllText(path, Encoding.Default);
                JObject obj = (JObject)JsonConvert.DeserializeObject(content);
                var indicators = obj["indicators"];
                JsonHelper.indicators = new List<IndicatorOne>(indicators.Select(p1 => {
                    IndicatorOne one = new IndicatorOne();
                    one.name = p1["name"].ToString();                    
                    var q1 = p1["indicatorTwo"];
                    one.indicatorTwos = new List<IndicatorTwo>(q1.Select(p2 => {
                        IndicatorTwo two = new IndicatorTwo();
                        two.name = p2["name"].ToString();                        
                        var q2 = p2["indicatorThree"];
                        two.indicatorThrees = new List<IndicatorThree>(q2.Select(p3 => {
                            IndicatorThree three = new IndicatorThree();
                            three.name = p3["name"].ToString();
                            three.value = p3["value"].ToString();                            
                            return three;
                        }));
                        return two;
                    }));
                    return one;
                }));
            }
            catch (Exception ex)
            {
                indicators = null;
            }            
            return indicators;
        }
    }
}
