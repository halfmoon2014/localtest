using System;
using System.Threading;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    private string connect = "Data Source=.;Initial Catalog=test;User ID=sa;Password=Hello123456!;";
    protected void Page_Load(object sender, EventArgs e)
    {
        bid.Value = ThreadOne().Tables[0].Rows[0]["value"].ToString();
        string s = "<input type=\"text\" value=" + ThreadOne().Tables[0].Rows[0]["value"].ToString() + "  />";
        join.InnerHtml = s;
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