using BikeLibrary.BLL;
using BikeLibrary.DBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.DBL.SQLRepository
{
    public class DBReturns : IReturnRepository
    {

        private readonly string connStr;

        public DBReturns(string conn)
        {
            connStr = conn;
        }


        public void AddReturn(Return Return)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = "INSERT INTO Returns (reason, comment, bikeid, orderid) VALUES (@reason, @comment, @bikeid, @orderid)";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@reason", Return.GetReason());
                        cmd.Parameters.AddWithValue("@comment", Return.GetComment());
                        cmd.Parameters.AddWithValue("@bikeid", Return.GetBikeId());
                        cmd.Parameters.AddWithValue("@orderid", Return.GetOrderId());
                        cmd.ExecuteNonQuery();
                    }
                    SqlCommand ChangeItemStatus= new SqlCommand("Update OrderItems Set status = @status where OrderId = @OrderID and BikeId = @BikeID", conn);
                    ChangeItemStatus.Parameters.AddWithValue("@status", "requested");
                    ChangeItemStatus.Parameters.AddWithValue("@OrderId", Return.GetOrderId());
                    ChangeItemStatus.Parameters.AddWithValue("@BikeId", Return.GetBikeId());
                    ChangeItemStatus.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ApproveReturn(Return Return)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = "Update OrderItems Set status = @status where OrderId = @OrderID and BikeId = @BikeID";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", "approved");
                        cmd.Parameters.AddWithValue("@OrderId", Return.GetOrderId());
                        cmd.Parameters.AddWithValue("@BikeId", Return.GetBikeId());
                        cmd.ExecuteNonQuery();
                    }   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Return> GetAllReturns()
        {
            List<Return> returns = new List<Return>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = "Select * from Returns;";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string reason = (string)reader["reason"];
                        string comment = (string)reader["comment"];
                        int bikeid = (int)reader["bikeid"];
                        int orderid = (int)reader["orderid"];


                        returns.Add(new Return(id, reason, comment, bikeid, orderid));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return returns;
        }

        public Return GetReturn(int ReturnId)
        {
            Return Return;
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = "Select * from Returns where id = @id;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", ReturnId);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string reason = (string)reader["reason"];
                        string comment = (string)reader["comment"];
                        int bikeid = (int)reader["bikeid"];
                        int orderid = (int)reader["orderid"];


                        Return = new Return(id, reason, comment, bikeid, orderid);
                        return Return;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
