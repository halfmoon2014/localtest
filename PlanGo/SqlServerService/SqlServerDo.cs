using PlanGo.DTO;
using PlanGo.Tools;
using System.Data;

namespace PlanGo.SqlServerService
{
    class SqlServerDo
    {
        public static DataSet Login(LoginDto dot)
        {
            string name = dot.Name;
            string pwd = dot.Pwd;
            return MySqlHelper.ExecuteSQL("select * from users where userid='" + name + "' and pwd='" + EncryptUtil.Md532(pwd) + "' ");
        }
    }
}
