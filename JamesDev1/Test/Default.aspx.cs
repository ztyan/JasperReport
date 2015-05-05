using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ExecuteDataSet();
    }

    public static DataSet ExecuteDataSet()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"database=swmdb;server=192.168.0.27\MSSQLSERVER2012;user id=sa;password=procase2012;Connect Timeout=30";
        SqlCommand cmd = new SqlCommand();

        if (con.State != ConnectionState.Open)
        {
            con.Open();
        }

        cmd.Connection = con;
        cmd.CommandText = "swm.PortPlan_get_portfolio_plan_listSp";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter parameter = null;

        parameter = new SqlParameter("@p_tb_id", SqlDbType.BigInt);
        parameter.Value = 0;
        cmd.Parameters.Add(parameter);
        parameter = new SqlParameter("@p_dfs_id", SqlDbType.BigInt);
        parameter.Value = 0;
        cmd.Parameters.Add(parameter);

        parameter = new SqlParameter("@p_product_id", SqlDbType.BigInt);
        parameter.Value = 0;
        cmd.Parameters.Add(parameter);
        parameter = new SqlParameter("@p_test_phase_id", SqlDbType.BigInt);
        parameter.Value = 0;
        cmd.Parameters.Add(parameter);

        parameter = new SqlParameter("@p_collaborator_id", SqlDbType.BigInt);
        parameter.Value = 2;
        cmd.Parameters.Add(parameter);
        parameter = new SqlParameter("@p_start_year", SqlDbType.BigInt);
        parameter.Value = 2012;
        cmd.Parameters.Add(parameter);

        parameter = new SqlParameter("@p_start_week", SqlDbType.BigInt);
        parameter.Value = 07;
        cmd.Parameters.Add(parameter);

        parameter = new SqlParameter("@p_end_year", SqlDbType.BigInt);
        parameter.Value = 2012;
        cmd.Parameters.Add(parameter);
        parameter = new SqlParameter("@p_end_week", SqlDbType.BigInt);
        parameter.Value = 08;
        cmd.Parameters.Add(parameter);


        parameter = new SqlParameter("@p_test_team_id", SqlDbType.VarChar);
        parameter.Value = "1,2,3,4,5,11,1040,1060,1061,6,1001";
        cmd.Parameters.Add(parameter);
        parameter = new SqlParameter("@p_user_id", SqlDbType.BigInt);
        parameter.Value = 1;
        cmd.Parameters.Add(parameter);


        //cmd.Parameters.Add(new SqlParameter("@p_tb_id",SqlDbType.BigInt));
        //cmd.Parameters.Add(new SqlParameter("@p_dfs_id", 0));
        //cmd.Parameters.Add(new SqlParameter("@p_product_id", 0));
        //cmd.Parameters.Add(new SqlParameter("@p_test_phase_id", 0));
        //cmd.Parameters.Add(new SqlParameter("@p_collaborator_id", 2));
        //cmd.Parameters.Add(new SqlParameter("@p_start_year", 2012));
        //cmd.Parameters.Add(new SqlParameter("@p_start_week", 07));
        //cmd.Parameters.Add(new SqlParameter("@p_end_year", 2012));
        //cmd.Parameters.Add(new SqlParameter("@p_end_week", 08));
        //cmd.Parameters.Add(new SqlParameter("@p_user_id", 1));

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds);
        }
        catch (SqlException sqlEx)
        {
            throw sqlEx;
        }
        return ds;
    }
}