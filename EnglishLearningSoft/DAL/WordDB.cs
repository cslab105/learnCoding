using System.Configuration;
using Model;
using System.Data.SqlClient;
using System;

namespace DAL
{
    class WordDB
    {
        string tt = "";
        private string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
        public int AddUser(UserInfo userInfo)
        {
            //对数据库进添加一个用户操作  
            string commandText = "insert into UserInfo (userName,Password)values(@userName,@Password)";
            SqlParameter[] paras = new SqlParameter[]
            {
           new SqlParameter ("@userName",userInfo.userName ),
           new SqlParameter ("@Password",userInfo.passWord )
            };
            return 5;
            //return SqlHelper.ExecuteNonQuery(connString, CommandType.Text, commandText, paras);
        }
    }
}
