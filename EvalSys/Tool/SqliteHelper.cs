using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data.SQLite;

namespace EvalSys
{
    public static class SqliteHelper
    {
        static string path = string.Empty;
        static SQLiteConnection conn = null;
        static SQLiteCommand cmd = null;
        static string[] calModule = { "开关型", "单一比较型", "多重比较型", "分段计数型", "单一比例比较型" };

        /// <summary>
        /// initialze db file
        /// </summary>
        public static void InitDBFile(out string msg)
        {
            msg = string.Empty;
            path = AppDomain.CurrentDomain.BaseDirectory;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += @"\data.sqlite";
            if (!File.Exists(path))
            {
                msg = "数据库文件不存在";
                return;
                //SQLiteConnection.CreateFile(path);
            }
            conn = new SQLiteConnection("data source=" + path);
            cmd = new SQLiteCommand(conn);
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
        }

        /// <summary>
        /// valid user password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool ValidUser(string userName, string password)
        {
            cmd.CommandText = $"SELECT password from User WHERE name = '{userName}'";
            string pw = Convert.ToString(cmd.ExecuteScalar());
            if (string.Equals(pw, password))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// insert data to table
        /// </summary>
        /// <param name="tableName">table name</param>
        /// <param name="data">data</param>
        /// <returns></returns>
        public static void Insert(TableName tableName, object data, out string msg)
        {
            msg = string.Empty;
            switch (tableName)
            {
                case TableName.User:
                    UserModule user = (UserModule)data;
                    if (CheckRowData(tableName.ToString(), user.UserName))
                    {
                        msg = "单位已存在";
                    }
                    else
                    {
                        cmd.CommandText = $"INSERT INTO '{tableName.ToString()}' VALUES('{user.UserName}','{user.PassWord}',{user.RoleId},'{user.ContractPerson}','{user.ContractTelPhone}','{user.CompanyAddress}')";
                        if (cmd.ExecuteNonQuery() <= 0)
                        {
                            msg = "新增单位失败";
                        }
                    }
                    break;
                case TableName.BasicData:
                    BasicDataModule basicData = (BasicDataModule)data;
                    if (CheckRowData(tableName.ToString(), basicData.Name))
                    {
                        msg = "指标已存在";
                    }
                    else
                    {
                        cmd.CommandText = $"INSERT INTO {tableName.ToString()} (name, level, grade, parent_id) VALUES('{basicData.Name}', {basicData.Level}, {basicData.Grade}, {basicData.ParentId})";
                        if (cmd.ExecuteNonQuery() <= 0)
                        {
                            msg = "数据写入失败";
                        }
                    }
                    break;
                case TableName.BasicFour:
                    BasicFourModule fourData = (BasicFourModule)data;
                    if (CheckRowData(tableName.ToString(), fourData.Name))
                    {
                        msg = "指标已存在";
                    }
                    else
                    {
                        string strCalModule = string.Empty;
                        for (int i = 0; i < fourData.CalModules.Length; i++)
                        {
                            if (i == 0)
                            {
                                strCalModule += (int)fourData.CalModules[i];
                            }
                            else
                            {
                                strCalModule += "," + (int)fourData.CalModules[i];
                            }
                        }
                        cmd.CommandText = $"INSERT INTO {tableName.ToString()} (name, level, parent_id, basic_score, basic_rule, basic_sub, basic_add, cal_module) VALUES('{fourData.Name}', {fourData.Level}, {fourData.ParentId}, {fourData.BasicScore}, '{fourData.BasicRule}', '{fourData.BasicSub}', '{fourData.BasicAdd}', '{strCalModule}')";
                        if (cmd.ExecuteNonQuery() <= 0)
                        {
                            msg = "数据写入失败";
                        }
                    }
                    break;
                case TableName.TimeCycle:
                    TimeCycleModule timeData = (TimeCycleModule)data;
                    if (CheckTimeData(tableName.ToString(), timeData, -1))
                    {
                        msg = "评价阶段已存在";
                    }
                    else
                    {
                        cmd.CommandText = $"INSERT INTO {tableName.ToString()} (name, start_time, end_time, create_time, latest_commit_time, state, user_name) VALUES('{timeData.Name}', '{timeData.StartTime}','{timeData.EndTime}','{timeData.CreateTime}','{timeData.LatestCommitTime}', {timeData.State}, '{timeData.UserName}')";
                        if (cmd.ExecuteNonQuery() <= 0)
                        {
                            msg = "数据写入失败";
                        }
                    }
                    break;
                case TableName.EvalutationData:
                    List<EvalutationDataModule> evalutationDatas = (List<EvalutationDataModule>)data;
                    using (SQLiteTransaction transaction = conn.BeginTransaction())
                    {
                        foreach (var item in evalutationDatas)
                        {
                            string dataSource = string.Empty;
                            if (item.DataSource != null)
                            {
                                dataSource = string.Join("|", item.DataSource);
                            }
                            cmd.CommandText = $"INSERT INTO {tableName.ToString()} (time_cycle, indicator_four, data_source, description, grade) VALUES({item.TimeCycle}, {item.IndicatorFour},'{dataSource}','{item.Description}',{item.Grade})";
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    break;
                default:
                    msg = "table is not exist";
                    break;
            }
        }

        /// <summary>
        /// update data
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static void Update(TableName tableName, int id, object data, out string msg)
        {
            msg = string.Empty;
            switch (tableName)
            {
                case TableName.User:
                    UserModule user = (UserModule)data;
                    if (CheckRowDataUpdate(tableName, user.UserName, id))
                    {
                        msg = "单位名称已存在";
                    }
                    else
                    {
                        cmd.CommandText = $"UPDATE {tableName.ToString()} SET password='{user.PassWord}',Role_Id={user.RoleId},Contract_Person='{user.ContractPerson}',Contract_TelPhone='{user.ContractTelPhone}',Company_Address='{user.CompanyAddress}' WHERE name='{user.UserName}'";
                        if (cmd.ExecuteNonQuery() <= 0)
                        {
                            msg = "更新失败";
                        }
                    }
                    break;
                case TableName.BasicData:
                    BasicDataModule basicData = (BasicDataModule)data;
                    if (CheckRowDataUpdate(tableName, basicData.Name, id))
                    {
                        msg = "指标已存在";
                    }
                    else
                    {
                        cmd.CommandText = $"UPDATE {tableName.ToString()} SET name='{basicData.Name}', grade={basicData.Grade}, parent_id={basicData.ParentId} WHERE id={id}";
                        if (cmd.ExecuteNonQuery() <= 0)
                        {
                            msg = "更新失败";
                        }
                    }
                    break;
                case TableName.BasicFour:
                    BasicFourModule fourData = (BasicFourModule)data;
                    if (CheckRowDataUpdate(tableName, fourData.Name, id))
                    {
                        msg = "指标已存在";
                    }
                    else
                    {
                        string strCalModule = string.Empty;
                        for (int i = 0; i < fourData.CalModules.Length; i++)
                        {
                            if (i == 0)
                            {
                                strCalModule += (int)fourData.CalModules[i];
                            }
                            else
                            {
                                strCalModule += "," + (int)fourData.CalModules[i];
                            }
                        }
                        cmd.CommandText = $"UPDATE {tableName.ToString()} SET name='{fourData.Name}', basic_score={fourData.BasicScore}, basic_rule='{fourData.BasicRule}', basic_sub='{fourData.BasicSub}', basic_add='{fourData.BasicAdd}', cal_module='{strCalModule}' WHERE id={id}";
                        if (cmd.ExecuteNonQuery() <= 0)
                        {
                            msg = "更新失败";
                        }
                    }
                    break;
                case TableName.TimeCycle:
                    TimeCycleModule timeData = (TimeCycleModule)data;
                    if (CheckTimeData(tableName.ToString(), timeData, id))
                    {
                        msg = "评价阶段已存在";
                    }
                    else
                    {
                        cmd.CommandText = $"UPDATE {tableName.ToString()} SET name='{timeData.Name}', start_time='{timeData.StartTime}', end_time='{timeData.EndTime}', state={timeData.State} WHERE id={id}";
                        if (cmd.ExecuteNonQuery() <= 0)
                        {
                            msg = "更新失败";
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="data"></param>
        public static void Update(TableName tableName, object data)
        {
            switch (tableName)
            {
                case TableName.EvalutationData:
                    using (SQLiteTransaction transaction = conn.BeginTransaction())
                    {
                        Dictionary<int, EvalutationDataModule> datas = (Dictionary<int, EvalutationDataModule>)data;
                        foreach (var item in datas)
                        {
                            string dataSource = string.Empty;
                            if (item.Value.DataSource != null)
                            {
                                dataSource = string.Join("|", item.Value.DataSource);
                            }
                            cmd.CommandText = $"UPDATE {tableName.ToString()} SET data_source='{dataSource}', description='{item.Value.Description}', grade={item.Value.Grade} WHERE id={item.Key}";
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    break;
            }
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static void Delete(TableName tableName, List<int> ids)
        {
            try
            {
                using (SQLiteTransaction transaction = conn.BeginTransaction())
                {
                    foreach (var item in ids)
                    {
                        cmd.CommandText = $"DELETE FROM {tableName.ToString()} WHERE id={item}";
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// delete data
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public static bool Delete(TableName tableName, object para)
        {
            bool result = false;
            try
            {
                switch (tableName)
                {
                    case TableName.User:
                        cmd.CommandText = $"DELETE FROM {tableName.ToString()} WHERE name={(string)para}";
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            result = true;
                        }
                        break;
                    case TableName.EvalutationData:
                        cmd.CommandText = $"DELETE FROM {tableName.ToString()} WHERE time_cycle={(int)para}";
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            result = true;
                        }
                        break;
                    default:
                        cmd.CommandText = $"DELETE FROM {tableName.ToString()} WHERE id={(int)para}";
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            result = true;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        /// <summary>
        /// check data exit
        /// </summary>
        /// <param name="tableName">table name</param>
        /// <param name="colData">column check data</param>
        /// <returns>true:exist, false:not exist</returns>
        private static bool CheckRowData(string tableName, string colData)
        {
            cmd.CommandText = $"SELECT count(*) FROM '{tableName}' WHERE name = '{colData}'";
            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// check timecycle exit
        /// </summary>
        /// <param name="tableName">table name</param>
        /// <param name="colData">column check data</param>
        /// <returns>true:exist, false:not exist</returns>
        private static bool CheckTimeData(string tableName, TimeCycleModule data, int id)
        {
            cmd.CommandText = $"SELECT count(*) FROM '{tableName}' WHERE name='{data.Name}' AND start_time='{data.StartTime}' AND end_time='{data.EndTime}' AND user_name='{data.UserName}'";
            if (id != -1)
            {
                cmd.CommandText += $" AND id!={id}";
            }
            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// check data exit
        /// </summary>
        /// <param name="tableName">table name</param>
        /// <param name="colData">column check data</param>
        /// <returns>true:exist, false:not exist</returns>
        private static bool CheckRowDataUpdate(TableName tableName, string colData, int id)
        {
            if (tableName == TableName.User)
            {
                cmd.CommandText = $"SELECT count(*) FROM '{tableName.ToString()}' WHERE name = '{colData}'";
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 1)
                {
                    return true;
                }
                return false;
            }
            cmd.CommandText = $"SELECT count(*) FROM '{tableName.ToString()}' WHERE name = '{colData}' and id != {id}";
            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static object Select(TableName tableName, params object[] para)
        {
            try
            {
                switch (tableName)
                {
                    case TableName.SysRole:
                        cmd.CommandText = $"SELECT * FROM {tableName.ToString()}";
                        List<SysRoleModule> sysRoles = new List<SysRoleModule>();
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SysRoleModule sysRole = new SysRoleModule();
                                sysRole.RoleId = int.Parse(reader["Role_Id"].ToString());
                                sysRole.RoleName = reader["Role_Name"].ToString();
                                sysRoles.Add(sysRole);
                            }
                            reader.Close();
                        }
                        return sysRoles;
                    case TableName.User:
                        cmd.CommandText = $"SELECT * FROM User left join SysRole on User.Role_Id = SysRole.Role_Id";
                        if (para.Length == 1)
                        {
                            cmd.CommandText += $" WHERE User.name='{para[0].ToString()}'";
                        }
                        List<UserModule> users = new List<UserModule>();
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserModule user = new UserModule();
                                user.UserName = reader["name"].ToString();
                                user.RoleId = int.Parse(reader["Role_Id"].ToString());
                                user.RoleName = reader["Role_Name"].ToString();
                                user.ContractPerson = reader["Contract_Person"].ToString();
                                user.ContractTelPhone = reader["Contract_TelPhone"].ToString();
                                user.CompanyAddress = reader["Company_Address"].ToString();
                                users.Add(user);
                            }
                            reader.Close();
                        }
                        return users;
                    case TableName.BasicData:
                        cmd.CommandText = $"SELECT * FROM {tableName.ToString()} WHERE 1=1";
                        if (para.Length > 0)
                        {
                            cmd.CommandText += $" AND level={(int)para[0]}";
                        }
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            List<BasicDataModule> modules = new List<BasicDataModule>();
                            while (reader.Read())
                            {
                                BasicDataModule module = new BasicDataModule();
                                module.ID = int.Parse(reader["id"].ToString());
                                module.Name = reader["name"].ToString();
                                module.Level = int.Parse(reader["level"].ToString());
                                module.Grade = int.Parse(reader["grade"].ToString());
                                module.ParentId = int.Parse(reader["parent_id"].ToString());
                                modules.Add(module);
                            }
                            reader.Close();
                            return modules;
                        }
                    case TableName.BasicFour:
                        cmd.CommandText = $"SELECT * FROM {tableName.ToString()}";
                        if (para.Length == 1) cmd.CommandText += $" WHERE name='{para[0]}'";
                        using (SQLiteDataReader fourReader = cmd.ExecuteReader())
                        {
                            List<BasicFourModule> fourModules = new List<BasicFourModule>();
                            while (fourReader.Read())
                            {
                                BasicFourModule fourModule = new BasicFourModule();
                                fourModule.ID = int.Parse(fourReader["id"].ToString());
                                fourModule.Name = fourReader["name"].ToString();
                                fourModule.Level = int.Parse(fourReader["level"].ToString());
                                fourModule.ParentId = int.Parse(fourReader["parent_id"].ToString());
                                fourModule.BasicScore = int.Parse(fourReader["basic_score"].ToString());
                                fourModule.BasicRule = fourReader["basic_rule"].ToString();
                                fourModule.BasicAdd = fourReader["basic_sub"].ToString();
                                fourModule.BasicSub = fourReader["basic_add"].ToString();
                                string cals = fourReader["cal_module"].ToString();
                                string[] arrCals = cals.Split(",".ToArray());
                                fourModule.CalModules = new CalModule[arrCals.Length];
                                for (int i = 0; i < arrCals.Length; i++)
                                {
                                    fourModule.CalModules[i] = (CalModule)int.Parse(arrCals[i]);
                                }
                                fourModule.StrCalModules = GetCalModuleStr(fourModule.CalModules);
                                fourModules.Add(fourModule);
                            }
                            fourReader.Close();
                            return fourModules;
                        }
                    case TableName.TimeCycle:
                        cmd.CommandText = $"SELECT * FROM {tableName.ToString()} WHERE state={(int)para[0]}";
                        if (para.Length == 2)
                        {
                            cmd.CommandText += $" AND name='{(string)para[1]}'";
                        }
                        else if (para.Length == 3)
                        {
                            if (para[1] != null) cmd.CommandText += $" AND name='{(string)para[1]}'";
                            cmd.CommandText += $" AND user_name='{(string)para[2]}'";
                        }
                        using (SQLiteDataReader timeReader = cmd.ExecuteReader())
                        {
                            List<TimeCycleModule> timeModules = new List<TimeCycleModule>();
                            while (timeReader.Read())
                            {
                                TimeCycleModule timeModule = new TimeCycleModule();
                                timeModule.ID = int.Parse(timeReader["id"].ToString());
                                timeModule.Name = timeReader["name"].ToString();
                                timeModule.StartTime = DateTime.Parse(timeReader["start_time"].ToString());
                                timeModule.EndTime = DateTime.Parse(timeReader["end_time"].ToString());
                                timeModule.CreateTime = DateTime.Parse(timeReader["create_time"].ToString());
                                timeModule.LatestCommitTime = DateTime.Parse(timeReader["latest_commit_time"].ToString());
                                timeModule.State = int.Parse(timeReader["state"].ToString());
                                timeModule.UserName = timeReader["user_name"].ToString();
                                timeModules.Add(timeModule);
                            }
                            timeReader.Close();
                            return timeModules.OrderByDescending(p => p.StartTime).ToList();
                        }
                    case TableName.EvalutationData:
                        if ((int)para[0] == -1)
                        {
                            TimeCycleModule timeCycle = (TimeCycleModule)para[2];
                            cmd.CommandText = $"SELECT a.id, a.time_cycle, a.indicator_four, a.data_source, a.description, a.grade, b.name, b.parent_id, b.basic_score, b.basic_rule, b.basic_sub, b.basic_add, b.cal_module FROM EvalutationData as a left outer join BasicFour as b on a.indicator_four = b.id WHERE b.parent_id={(int)para[1]} AND a.time_cycle in (SELECT id FROM TimeCycle WHERE name='{timeCycle.Name}' AND start_time='{timeCycle.StartTime}' AND end_time='{timeCycle.EndTime}' AND state=1)";
                        }
                        else if ((int)para[0] == -2)
                        {
                            cmd.CommandText = $"SELECT a.id, a.time_cycle, a.indicator_four, a.data_source, a.description, a.grade, b.name, b.parent_id, b.basic_score, b.basic_rule, b.basic_sub, b.basic_add, b.cal_module FROM EvalutationData as a left outer join BasicFour as b on a.indicator_four = b.id WHERE b.parent_id={(int)para[1]} AND a.time_cycle={(int)para[2]}";
                        }
                        else
                        {
                            cmd.CommandText = $"SELECT a.id, a.time_cycle, a.indicator_four, a.data_source, a.description, a.grade, b.name, b.parent_id, b.basic_score, b.basic_rule, b.basic_sub, b.basic_add, b.cal_module FROM EvalutationData as a left outer join BasicFour as b on a.indicator_four = b.id WHERE time_cycle={(int)para[0]}";
                        }

                        using (SQLiteDataReader evalutationReader = cmd.ExecuteReader())//reader is active exception
                        {
                            List<EvalutationDataModule> evalutationModules = new List<EvalutationDataModule>();
                            while (evalutationReader.Read())
                            {
                                EvalutationDataModule evalutationModule = new EvalutationDataModule();
                                evalutationModule.ID = int.Parse(evalutationReader["id"].ToString());
                                evalutationModule.TimeCycle = int.Parse(evalutationReader["time_cycle"].ToString());
                                evalutationModule.IndicatorFour = int.Parse(evalutationReader["indicator_four"].ToString());
                                evalutationModule.DataSource = evalutationReader["data_source"].ToString().Split("|".ToArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                                evalutationModule.Description = evalutationReader["description"].ToString();
                                evalutationModule.Grade = int.Parse(evalutationReader["grade"].ToString());
                                evalutationModule.Name = evalutationReader["name"].ToString();
                                evalutationModule.ParentId = int.Parse(evalutationReader["parent_id"].ToString());
                                evalutationModule.BasicScore = int.Parse(evalutationReader["basic_score"].ToString());
                                evalutationModule.BasicRule = evalutationReader["basic_rule"].ToString();
                                evalutationModule.BasicAdd = evalutationReader["basic_sub"].ToString();
                                evalutationModule.BasicSub = evalutationReader["basic_add"].ToString();
                                string cals = evalutationReader["cal_module"].ToString();
                                string[] arrCals = cals.Split(",".ToArray());
                                evalutationModule.CalModules = new CalModule[arrCals.Length];
                                for (int i = 0; i < arrCals.Length; i++)
                                {
                                    evalutationModule.CalModules[i] = (CalModule)int.Parse(arrCals[i]);
                                }
                                evalutationModule.StrCalModules = GetCalModuleStr(evalutationModule.CalModules);
                                evalutationModules.Add(evalutationModule);
                            }
                            evalutationReader.Close();
                            return evalutationModules;
                        }
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        private static string GetCalModuleStr(CalModule[] data)
        {
            string str = string.Empty;
            for (int i = 0; i < data.Length; i++)
            {
                if (i == 0)
                {
                    str += calModule[(int)data[i] - 1];
                }
                else
                {
                    str += "," + calModule[(int)data[i] - 1];
                }
            }
            return str;
        }

        /// <summary>
        /// close db file and connection
        /// </summary>
        public static void CloseDBFile()
        {
            conn?.Close();
            cmd?.Dispose();
            conn?.Dispose();
        }
    }//end of class
     ///// <summary>
     ///// create table
     ///// </summary>
     //private static void CreateTable()
     //{
     //    //create user table
     //    if(!CheckTable("User"))
     //    {
     //        cmd.CommandText = "CREATE TABLE User(name varchar, password varchar)";
     //        cmd.ExecuteNonQuery();
     //    }            
     //}

    ///// <summary>
    ///// check table exit
    ///// </summary>
    ///// <param name="tableName"></param>
    ///// <returns></returns>
    //private static bool CheckTable(string tableName) {
    //    cmd.CommandText = $"SELECT count(*) FROM sqlite_master WHERE type = 'table' AND name = '{tableName}'";
    //    if(Convert.ToInt32(cmd.ExecuteScalar())>0)
    //    {
    //        return true;
    //    }
    //    return false;
    //}
}