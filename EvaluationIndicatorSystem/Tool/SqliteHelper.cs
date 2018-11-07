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
            CreateTable();            
        }

        /// <summary>
        /// create table
        /// </summary>
        private static void CreateTable()
        {
            //create user table
            if(!CheckTable("User"))
            {
                cmd.CommandText = "CREATE TABLE User(name varchar, password varchar)";
                cmd.ExecuteNonQuery();
            }            
        }

        /// <summary>
        /// check table exit
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private static bool CheckTable(string tableName) {
            cmd.CommandText = $"SELECT count(*) FROM sqlite_master WHERE type = 'table' AND name = '{tableName}'";
            if(Convert.ToInt32(cmd.ExecuteScalar())>0)
            {
                return true;
            }
            return false;
        }

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
                default:
                    msg = "table is not exist";
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
}
