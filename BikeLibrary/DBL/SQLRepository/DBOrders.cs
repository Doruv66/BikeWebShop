using BikeClassLibrary;
using BikeLibrary.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeLibrary.DBL
{
    public class DBOrders : IOrderRepository
    {
        private readonly string connStr;

        public DBOrders(string conn)
        {
            connStr = conn;
        }

        public bool AddOrder(Order order)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string insertOrder = "INSERT INTO Orders (Status, Accid) VALUES (@Status, @Accid); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(insertOrder, conn);
                    cmd.Parameters.AddWithValue("@Status", order.GetStatus());
                    cmd.Parameters.AddWithValue("@Accid", order.GetAccid());
                    int orderid = Convert.ToInt32(cmd.ExecuteScalar());


                    foreach(var item in order.GetItems())
                    {
                        SqlCommand insertItems = new SqlCommand("Insert into OrderItems (OrderId, BikeId, Quantity) Values (@OrderId, @BikeId, @Quantity)", conn);
                        insertItems.Parameters.AddWithValue("@OrderId", orderid);
                        insertItems.Parameters.AddWithValue("@BikeId", item.bikeid);
                        insertItems.Parameters.AddWithValue("@Quantity", item.quantity);
                        insertItems.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public List<Order> GetAll()
        {
            List<Order> orders = new List<Order>();
            string sql = "SELECT o.*, oi.BikeId, oi.Quantity FROM Orders o JOIN OrderItems oi ON o.Id = oi.OrderId";

			try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
					conn.Open();
					SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        string status = (string)reader["Status"];
                        int accid = (int)reader["Accid"];
                        int bikeId = (int)reader["BikeId"];
                        int quantity = (int)reader["Quantity"];
                        // Check if we've already processed this order
                        Order order = orders.FirstOrDefault(o => o.GetId() == id);
                        if (order == null)
                        {
                            order = new Order(id, status, accid, new List<Item>());
                            orders.Add(order);
                        }
                        Item item = new Item(bikeId, quantity);
                        order.AddItem(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return orders;
        }

		public Order GetOrder(int id)
		{
            Order order;
            string sql = "SELECT o.*, oi.BikeId, oi.Quantity FROM Orders o JOIN OrderItems oi ON o.Id = oi.OrderId where o.Id = @id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string status = (string)reader["Status"];
                        int accid = (int)reader["Accid"];
                        int bikeId = (int)reader["BikeId"];
                        int quantity = (int)reader["Quantity"];
                        order = new Order(id, status, accid, new List<Item>());
                        Item item = new Item(bikeId, quantity);
                        order.AddItem(item);
                        return order;
                    }
                    
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
		}

		public void UpdateStatus(Order order)
		{
            try
            {
                using(SqlConnection conn = new SqlConnection(connStr))
                {

                    string sql = "UPDATE Orders Set Status =@Status where id=@id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("Status", order.GetStatus());
					cmd.Parameters.AddWithValue("id", order.GetId());

                    conn.Open();
                    cmd.ExecuteNonQuery();
				}
            }
            catch (Exception ex)
            {
                //check in browser if it works
                Console.WriteLine(ex.Message);
            }
		}
	}
}
