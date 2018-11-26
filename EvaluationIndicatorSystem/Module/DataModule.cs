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
    }//end of class UserModule

    public class BasicDataModule
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Grade { get; set; }
        public int ParentId { get; set; }
    }//end of class BasicDataModule

    public class BasicFourModule
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int ParentId { get; set; }
        public string BasicRule { get; set; }
        public string BasicSub { get; set; }
        public string BasicAdd { get; set; }
        public CalModule[] CalModules { get; set; }
        public string StrCalModules { get; set; }
        public string Update { get => "修改"; }
        public string Delete { get => "删除"; }
    }//end of class BasicFourModule

    public class TimeCycleModule
    {
        public int ID { get; set; }             
        public string Name { get; set; }
    }//end of class TimeCycle

    public class EvalutationDataModule
    {
        public int ID { get; set; }
        public int TimeCycle { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int IndicatorOne { get; set; }
        public int IndicatorTwo { get; set; }
        public int IndicatorThree { get; set; }
        public List<EvalutationFourModule> EvalutationDataObj { get; set; }
        public int IsCommit { get; set; }
    }//end of class EvalutationDataModule

    public class EvalutationFourModule
    {
        public int ID { get; set; }
        public List<string> DataSource { get; set; }
        public string Remark { get; set; }
    }//end of class EvalutationFourModule

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
        public CalModule[] calModule { get; set; } = new CalModule[0];
        public List<IndicatorFour> indicatorFours { get; set; }
    }//end of class

    public class IndicatorFour
    {
        public string name { get; set; }       
    }//end of classs
}
