namespace PlanGo.DTO
{
    public class LoginDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        private string name;
        /// <summary>
        /// 密码
        /// </summary>
        private string pwd;

        /// <summary>
        /// 中文名
        /// </summary>
        private string username;


        public LoginDto(string name, string pwd)
        {
            this.name = name;
            this.pwd = pwd;
        }

        public LoginDto(string name, string pwd,string username)
        {
            this.name = name;
            this.pwd = pwd;
            this.username = username;
        }

        public string Name { get => name; set => name = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public string Username { get => username; set => username = value; }
    }    
}
