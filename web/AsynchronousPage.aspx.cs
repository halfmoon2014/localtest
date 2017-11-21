using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web;

public partial class Default2 : System.Web.UI.Page
{
    private SqlConnection _connection;
    private SqlCommand _command;
    private SqlDataReader _reader;
    protected void Page_Load(object sender, EventArgs e)
    {
        //方法2
        AddOnPreRenderCompleteAsync(
        new BeginEventHandler(BeginAsyncOperation),
            new EndEventHandler(EndAsyncOperation));

        //方法1
        //PageAsyncTask task = new PageAsyncTask(BeginAsyncOperation,
        //    EndAsyncOperation,
        //    TimeoutAsyncOperation,
        //    null);
        //RegisterAsyncTask(task);
        
    }
    IAsyncResult BeginAsyncOperation(object sender, EventArgs e,
       AsyncCallback cb, object state)
    {
        string connect = "Data Source=.\\maxsql;Initial Catalog=localtest;User ID=sa;Password=Hello123456!;Asynchronous Processing=true;";
        _connection = new SqlConnection(connect);

        _connection.Open();

        _command = new SqlCommand(
            "SELECT top 10 header_id, line_id, ordered_item FROM oe_order_lines_all", _connection);
        return _command.BeginExecuteReader(cb, state);

    }

    void EndAsyncOperation(IAsyncResult ar)
    {
        _reader = _command.EndExecuteReader(ar);
        
    }

    //异步结束后调用
    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Load(_reader);
        Output.DataSource = dt;

        Output.DataBind();
    } 
    void TimeoutAsyncOperation(IAsyncResult ar)
    {

        // Called if async operation times out (@ Page AsyncTimeout)

        Label1.Text = "Data temporarily unavailable";

    }
}