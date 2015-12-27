using DAL;
using Model;

namespace BLL
{
    public class LoginManager
    {
        private UserDB userDB = new UserDB();
        public bool Add(UserInfo userInfo, out string messageStr)
        {
            messageStr = "";//返回界面层添加用户返回信息  
            bool isSuccess = false;
            if (userInfo.userName.Trim().Length != 0)//判断从传递来的username是否为空  
            {
                if (userDB.Equals(userInfo))//传给DALl操作判断数据库中是否有重复值  
                {
                    userDB.AddUser(userInfo);//传给DAL操作增加一个新用户  
                    isSuccess = true;
                }
                else
                    messageStr = "有相同的值";
            }
            else
            {
                messageStr = "不能为空";

            }
            return isSuccess;//返回界面层是否添加成功  
        }
    }
}