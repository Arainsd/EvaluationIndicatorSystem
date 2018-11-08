using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationIndicatorSystem
{
    public class UserModule
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }//end of class

    public class IndicatorOne
    {
        public string name { get; set; }
        public List<IndicatorTwo> indicatorTwos { get; set; }

    }//end of class

    public class IndicatorTwo
    {
        public string name { get; set; }
        public List<IndicatorThree> indicatorThrees { get; set; }
    }//end of class

    public class IndicatorThree
    {
        public string name { get; set; }
        public string value { get; set; }        
    }//end of class

    public class IndicatorFour
    {

    }//end of classs
}
