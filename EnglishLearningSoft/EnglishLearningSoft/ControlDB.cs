using System.Data.SqlClient;
namespace EnglishLearningSoftware
{
    internal class ControlDB

    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader dr;
        private string conStr;

        public ControlDB(string str)
        {
            conStr = str;
        }
        //打开数据库
        public void Open()
        {
            if (con == null)
            {
                con = new SqlConnection(conStr);
                con.Open();
            }
            else
            {
                Close();
                Open();
            }
        }
        //关闭数据库
        public void Close()
        {
            if (con != null)
            {
                con.Close();
                con.Dispose();
            }
        }
        //增加数据
        public void add() { }
        //删除数据
        public void del() { }
        //更改数据
        public void change() { }
        //查询单行数据
        public void sel() { }
        //查询多行数据
        public void sels() { }
    }
}