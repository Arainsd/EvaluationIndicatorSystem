using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationIndicatorSystem
{
    public enum TableName
    {
        User = 0,
        BasicData = 1,
        BasicFour = 2,
        TimeCycle = 3
    }//end of enum TableName

    public enum TabName
    {
        BasicIndicatorOne = 1,
        BasicIndicatorTwo = 2,
        BasicIndicatorThree = 3,
        BasicIndicatorFour = 4,
        EvalutationData = 5
    }//end of enum TabName

    public enum CalModule
    {
        Switch = 1,//开关型
        SingleComparison = 2,//单一比较型
        MulComparison = 3,//多重比较型
        SegmentCounting = 4,//分段计数型
        SingleScaleComparison = 5//单一比例比较型
    }//end of enum CalModule
}
