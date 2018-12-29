using System;
using System.Collections.Generic;

namespace EvalSys
{
    public class SysRoleModule
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }//end of class SysRole

    public class UserModule
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string ContractPerson { get; set; }
        public string ContractTelPhone { get; set; }
        public string CompanyAddress { get; set; }
        public string Update { get => "修改"; }
        public string Delete { get => "删除"; }
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
        public int BasicScore { get; set; }
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
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LatestCommitTime { get; set; }
        public int State { get; set; }
        public string UserName { get; set; }
    }//end of class TimeCycle

    public class EvalutationDataModule
    {
        public int ID { get; set; }
        public int TimeCycle { get; set; }                
        public int IndicatorFour { get; set; }
        public string[] DataSource { get; set; }
        public string Description { get; set; }
        public int Grade { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string BasicRule { get; set; }
        public string BasicSub { get; set; }
        public string BasicAdd { get; set; }
        public CalModule[] CalModules { get; set; }
        public string StrCalModules { get; set; }
        public string Operate { get => "编辑"; }
    }//end of class EvalutationDataModule

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
