using System;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
public partial class _Default : System.Web.UI.Page
{
    private string connect = "Data Source=.\\maxsql;Initial Catalog=localtest;User ID=sa;Password=Hello123456!;";

    private DataTable threadOneResult;
    private DataTable threadTwoResult;
    private DataTable threadThreeResult;

    protected void Page_Load(object sender, EventArgs e)
    {
        AsyncCallsWithThreadPool();
    }
    public void AsyncCallsWithThreadPool()
    {
        ThreadPool.QueueUserWorkItem(ThreadOne, 1000);
        ThreadPool.QueueUserWorkItem(ThreadTwo, 5000);
        ThreadPool.QueueUserWorkItem(ThreadThree, 10000);

        while (threadOneResult == null ||
            threadTwoResult == null ||
            threadThreeResult == null)
        {
            Thread.Sleep(10000);
        }

        // continue
        threadOneResult.Merge(threadTwoResult);
        threadOneResult.Merge(threadThreeResult);
        Output.DataSource = threadOneResult;
        Output.DataBind();
    }

    private void ThreadOne(object state)
    {
        DataSet ds = new DataSet();
        using (SqlConnection conn = new SqlConnection(connect))
        {
            SqlCommand cmd = new SqlCommand("SELECT top 10 header_id, line_id, ordered_item FROM oe_order_lines_all", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
        }
        threadOneResult = ds.Tables[0];
    }

    private void ThreadTwo(object state)
    {
        DataSet ds = new DataSet();
        using (SqlConnection conn = new SqlConnection(connect))
        {
            SqlCommand cmd = new SqlCommand("SELECT top 20 header_id, line_id, ordered_item FROM oe_order_lines_all", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
        }
        threadTwoResult = ds.Tables[0];
    }

    private void ThreadThree(object state)
    {
        DataSet ds = new DataSet();
        using (SqlConnection conn = new SqlConnection(connect))
        {
            SqlCommand cmd = new SqlCommand("SELECT top 30 header_id, line_id, ordered_item FROM oe_order_lines_all", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
        }
        threadThreeResult = ds.Tables[0];
    }
}