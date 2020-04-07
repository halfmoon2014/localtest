using System;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
using nrWebClass;

public partial class _Default : System.Web.UI.Page
{
    private string connect = "Data Source=.,12742;Initial Catalog=test;User ID=sa;Password=Hello123456!;";
    protected void Page_Load(object sender, EventArgs e)
    {
        bid.Value = ThreadOne().Tables[0].Rows[0]["value"].ToString();
        string s = "<input type=\"text\" value=" + ThreadOne().Tables[0].Rows[0]["value"].ToString() + "  />";
        join.InnerHtml = s;
        using (LiLanzDALForXLM dal = new LiLanzDALForXLM(1))
        {
            string mysql = @" exec yf_cx_xljx {0},{1},{2}";
            DataSet ds;
            string errInfo = dal.ExecuteQuery(string.Format(mysql, 1, "TEST", "test"), out ds);
        }
    }
    public DataSet ThreadOne()
    {
        DataSet ds = new DataSet();
        using (SqlConnection conn = new SqlConnection(connect))
        {
            SqlCommand cmd = new SqlCommand("SELECT value FROM mytesttable where id=1", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
        }
        return ds;
    }

}