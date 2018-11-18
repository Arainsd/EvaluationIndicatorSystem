using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

namespace EvaluationIndicatorSystem
{
    public static class SqliteHelper
    {
        static string path = string.Empty;
        static SQLiteConnection conn = null;
        static SQLiteCommand cmd = null;

        /// <summary>
        /// initialze db file
        /// </summary>
        public static void InitDBFile()
        {
            path = AppDomain.CurrentDomain.BaseDirectory + "Data";
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += "/data.sqlite";
            if(!File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
            }
            conn = new SQLiteConnection("data source=" + path);
            cmd = new SQLiteCommand(conn);
            if(conn.State != System.Data.ConnectionState.Open)
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
            else
            {
                return false;
            }            
        }

        /// <summary>
        /// insert data to table
        /// </summary>
        /// <param name="tableName">table name</param>
        /// <param name="data">data</param>
        /// <returns></returns>
        public static bool Insert(TableName tableName, object data, out string msg)
        {
            bool result = false;
            msg = string.Empty;
            switch (tableName)
            {
                case TableName.User:                    
                    UserModule user = (UserModule)data;
                    if (CheckRowData(tableName.ToString(), user.UserName))
                    {
                        result = false;
                        msg = "用户名已存在";
                    }
                    else
                    {
                        cmd.CommandText = $"INSERT INTO '{tableName.ToString()}' VALUES('{user.UserName}', '{user.PassWord}')";
                        if(cmd.ExecuteNonQuery()>0)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                            msg = "数据写入失败";
                        }
                    }                        
                    break;
                case TableName.BasicData:
                    BasicDataModule basicData = (BasicDataModule)data;
                    if (CheckRowData(tableName.ToString(), basicData.Name))
                    {
                        result = false;
                        msg = "指标已存在";
                    }
                    else
                    {
                        cmd.CommandText = $"INSERT INTO {tableName.ToString()} (name, level, grade, parent_id) VALUES('{basicData.Name}', {basicData.Level}, {basicData.Grade}, {basicData.ParentId})";
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                            msg = "数据写入失败";
                        }
                    }
                    break;
                case TableName.BasicFour:
                    BasicFourModule fourData = (BasicFourModule)data;
                    if (CheckRowData(tableName.ToString(), fourData.Name))
                    {
                        result = false;
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
                        cmd.CommandText = $"INSERT INTO {tableName.ToString()} (name, level, parent_id, basic_rule, basic_sub, basic_add, cal_module) VALUES('{fourData.Name}', {fourData.Level}, {fourData.ParentId}, '{fourData.BasicRule}', '{fourData.BasicSub}', '{fourData.BasicAdd}', '{strCalModule}')";
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                            msg = "数据写入失败";
                        }
                    }
                    break;
                default:
                    msg = "table is not exist";
                    break;
            }
            return result;
        }

        /// <summary>
        /// update data
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool Update(TableName tableName,int id, object data)
        {
            bool result = false;
            switch (tableName)
            {
                case TableName.User:
                    break;
                case TableName.BasicData:
                    BasicDataModule basicData = (BasicDataModule)data;
                    cmd.CommandText = $"UPDATE {tableName.ToString()} SET name='{basicData.Name}', grade={basicData.Grade}, parent_id={basicData.ParentId} WHERE id={id}";
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }

        /// <summary>
        /// delete data
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(TableName tableName, int id)
        {
            bool result = false;
            switch (tableName)
            {
                case TableName.User:
                    break;
                case TableName.BasicData:                    
                    cmd.CommandText = $"DELETE FROM {tableName.ToString()} WHERE id={id}";
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                    break;
                default:
                    break;
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
            else
            {
                return false;
            }
        }
        
        public static object Select(TableName tableName)
        {
            switch(tableName)
            {
                case TableName.BasicData:
                    cmd.CommandText = $"SELECT * FROM '{tableName.ToString()}'";
                    SQLiteDataReader reader = cmd.ExecuteReader();
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
                case TableName.BasicFour:
                    cmd.CommandText = $"SELECT * FROM '{tableName.ToString()}'";
                    SQLiteDataReader fourReader = cmd.ExecuteReader();
                    List<BasicFourModule> fourModules = new List<BasicFourModule>();
                    while (fourReader.Read())
                    {
                        BasicFourModule fourModule = new BasicFourModule();
                        fourModule.ID = int.Parse(fourReader["id"].ToString());
                        fourModule.Name = fourReader["name"].ToString();
                        fourModule.Level = int.Parse(fourReader["level"].ToString());
                        fourModule.ParentId = int.Parse(fourReader["parent_id"].ToString());
                        fourModule.BasicRule = fourReader["basic_rule"].ToString();
                        fourModule.BasicAdd = fourReader["basic_sub"].ToString();
                        fourModule.BasicSub = fourReader["basic_add"].ToString();
                        string cals = fourReader["cal_module"].ToString();
                        string[] arrCals = cals.Split(",".ToArray());
                        fourModule.CalModules = new CalModule[arrCals.Length];
                        for (int i = 0;i <arrCals.Length;i++)
                        {
                            fourModule.CalModules[i] = (CalModule)int.Parse(arrCals[i]);
                        }
                        fourModules.Add(fourModule);
                    }
                    fourReader.Close();
                    return fourModules;
            }
            return null;
        }

        public static int ImportBasicData()
        {
            int result = 0;
            return result;
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
