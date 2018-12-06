namespace EvaluationIndicatorSystem
{
    public enum TableName
    {
        User = 0,
        BasicData = 1,
        BasicFour = 2,
        TimeCycle = 3,
        EvalutationData = 4
    }//end of enum TableName

    public enum TabName
    {
        BasicIndicatorOne = 1,
        BasicIndicatorTwo = 2,
        BasicIndicatorThree = 3,
        BasicIndicatorFour = 4,
        EvalutationData = 5,
        HistoryEvalutation = 6
    }//end of enum TabName

    public enum CalModule
    {
        Switch = 1,//开关型
        SingleComparison = 2,//单一比较型
        MulComparison = 3,//多重比较型
        SegmentCounting = 4,//分段计数型
        SingleScaleComparison = 5//单一比例比较型
    }//end of enum CalModule

    public enum TimeCycleState
    {
        Local = 0,
        Commit = 1
    }
}
