using BLL;
using Model;
namespace UIL
{
    public class ui
    {
        UserInfo userInfo;
        LoginManager lm = new LoginManager();
        public void uill()
        {
            userInfo = new UserInfo()
            {
                userName = txtUserName.Text.Trim(),
                passWord = txtPassword.Text.Trim()
            };
            string messageStr = "";

            if (lm.Add(userInfo, out messageStr))
            {
                MessageBox.Show("添加成功");
            }
            else
            {
                MessageBox.Show(messageStr);
                txtUserName.Focus();
            }

        }
    }
}
