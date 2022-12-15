using System;

using System.Data;

using System.Configuration;

using System.Data.SqlClient;

using System.Collections;

/// <summary>

/// Summary description for datamanager

/// </summary>

public class datamanager

{

    
    public static string Con = ConfigurationManager.ConnectionStrings["toy"].ConnectionString.ToString();

    public static SqlParameter createparameter(string name, SqlDbType type, object value)

    {

        SqlParameter prm = new SqlParameter(name, type);

        prm.Value = value;

        return prm;

    }


    public static SqlParameter createparameter(string name, SqlDbType type, ParameterDirection dir)

    {

        SqlParameter prm = new SqlParameter(name, type);

        prm.Direction = dir;

        return prm;

    }


    public static DataSet getdataset(string query, string tablename)

    {

        using (SqlConnection con = new SqlConnection(Con))

        {

            using (SqlCommand cmd = new SqlCommand(query, con))

            {

                using (DataSet ds = new DataSet())

                {

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {

                        da.Fill(ds, tablename);

                        return ds;

                    }

                }

            }

        }

    }


    public static DataSet getdatasetstored(string Stored, string TableName, params SqlParameter[] Parameters)

    {

        using (SqlConnection con = new SqlConnection(Con))

        {

            using (SqlCommand cmd = new SqlCommand(Stored, con))

            {

                cmd.CommandType = CommandType.StoredProcedure;

                using (DataSet ds = new DataSet())

                {

                    foreach (SqlParameter prm in Parameters)

                        cmd.Parameters.Add(prm);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(ds, TableName);

                    return ds;

                }

            }

        }

    }


    public static void savedataset(string query, DataSet ds)

    {

        if (ds.HasChanges())

        {

            SqlConnection con = new SqlConnection(Con);

            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            SqlCommandBuilder cmb = new SqlCommandBuilder(da);

            da.Update(ds, ds.Tables[0].TableName);

        }

    }


    public static SqlDataReader getdatareader(string query, out SqlConnection outcon)

    {

        SqlConnection con = new SqlConnection(Con);

        SqlCommand cmd = new SqlCommand(query, con);

        con.Open();

        outcon = con;

        return cmd.ExecuteReader();


    }


    public static void executenonoquery(string query)

    {

        SqlConnection con = new SqlConnection(Con);

        SqlCommand cmd = new SqlCommand(query, con);

        con.Open();

        cmd.ExecuteNonQuery();

        con.Close();

    }


    public static SqlDataReader getdatareaderstored(string stored, out SqlConnection conout, params SqlParameter[] prmarr)

    {

        SqlConnection con = new SqlConnection(Con);

        SqlCommand cmd = new SqlCommand(stored, con);

        cmd.CommandType = CommandType.StoredProcedure;

        foreach (SqlParameter prm in prmarr)

        {

            cmd.Parameters.Add(prm);

        }

        con.Open();

        conout = con;

        return cmd.ExecuteReader();


    }


    public static void ExecuteNonQueryStored(string stored, params SqlParameter[] prmarr)

    {

        SqlConnection con = new SqlConnection(Con);

        SqlCommand cmd = new SqlCommand(stored, con);

        cmd.CommandType = CommandType.StoredProcedure;

        foreach (SqlParameter prm in prmarr)

        {

            cmd.Parameters.Add(prm);

        }

        con.Open();

        cmd.ExecuteNonQuery();

        con.Close();

    }


    public static int ExecuteNonQueryStoredReturn(string stored, params SqlParameter[] prmarr)

    {

        SqlConnection con = new SqlConnection(Con);

        SqlCommand cmd = new SqlCommand(stored, con);

        cmd.CommandType = CommandType.StoredProcedure;

        foreach (SqlParameter prm in prmarr)

        {

            cmd.Parameters.Add(prm);

        }

        con.Open();

        int rowaff = cmd.ExecuteNonQuery();

        con.Close();

        return rowaff;

    }


    public static object executescalar(string stored, params SqlParameter[] prmarr)

    {

        SqlConnection con = new SqlConnection(Con);

        SqlCommand cmd = new SqlCommand(stored, con);

        cmd.CommandType = CommandType.StoredProcedure;

        foreach (SqlParameter prm in prmarr)

        {

            cmd.Parameters.Add(prm);

        }

        con.Open();

        object o = cmd.ExecuteScalar();

        con.Close();

        return o;

    }


    public static Hashtable executenonqueryoutput(string stored, params SqlParameter[] prmarr)

    {

        SqlConnection con = new SqlConnection(Con);

        SqlCommand cmd = new SqlCommand(stored, con);

        cmd.CommandType = CommandType.StoredProcedure;

        foreach (SqlParameter prm in prmarr)

        {

            cmd.Parameters.Add(prm);

        }

        con.Open();

        cmd.ExecuteNonQuery();

        Hashtable ht = new Hashtable();

        foreach (SqlParameter prm in prmarr)

        {

            if (prm.Direction == ParameterDirection.Output)

                ht.Add(prm.ParameterName, prm.Value);

        }

        con.Close();

        return ht;

    }


    public static DataTable getdatareaderstored(string stored, params SqlParameter[] prmarr)

    {

        using (SqlConnection con = new SqlConnection(Con))

        {

            SqlCommand cmd = new SqlCommand(stored, con);

            cmd.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter prm in prmarr)

            {

                cmd.Parameters.Add(prm);

            }

            if (con.State != ConnectionState.Open)

                con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            DataTable table = new DataTable();

            table.Load(reader);

            return table;

        }

    }

    public static DataSet GetDataSetStored(string Stored, string TableName, params SqlParameter[] Parameters)

    {

        using (SqlConnection con = new SqlConnection(Con))

        {

            using (SqlCommand cmd = new SqlCommand(Stored, con))

            {

                cmd.CommandType = CommandType.StoredProcedure;

                using (DataSet ds = new DataSet())

                {

                    foreach (SqlParameter prm in Parameters)

                        cmd.Parameters.Add(prm);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(ds, TableName);

                    return ds;

                }

            }

        }

    }



    public static DataTable ExecuteSelectCommand(SqlCommand command)

    {


        DataTable table;


        command.Connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        table = new DataTable();

        table.Load(reader);

        reader.Close();



        return table;

    }

    public static object ExecuteScalar(string stored, params SqlParameter[] prmarr)

    {

        SqlConnection con = new SqlConnection(Con);

        SqlCommand cmd = new SqlCommand(stored, con);

        cmd.CommandType = CommandType.StoredProcedure;

        foreach (SqlParameter prm in prmarr)

            cmd.Parameters.Add(prm);

        con.Open();

        object o = cmd.ExecuteScalar();

        con.Close();

        return o;

    }

}