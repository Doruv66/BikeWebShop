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

                    string insertOrder = "INSERT INTO Orders (Status, Accid, Shipping, Date) VALUES (@Status, @Accid, @Shipping, @Date); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(insertOrder, conn);
                    cmd.Parameters.AddWithValue("@Status", order.GetStatus());
                    cmd.Parameters.AddWithValue("@Accid", order.GetAccid());
                    cmd.Parameters.AddWithValue("@Shipping", order.GetShipping().GetId());
                    cmd.Parameters.AddWithValue("@Date", order.GetOrderDate());
                    int orderid = Convert.ToInt32(cmd.ExecuteScalar());

                    foreach(var item in order.GetItems())
                    {
                        SqlCommand insertItems = new SqlCommand("Insert into OrderItems (OrderId, BikeId, Quantity, status) Values (@OrderId, @BikeId, @Quantity, @status)", conn);
                        insertItems.Parameters.AddWithValue("@OrderId", orderid);
                        insertItems.Parameters.AddWithValue("@BikeId", item.bikeid);
                        insertItems.Parameters.AddWithValue("@Quantity", item.quantity);
                        insertItems.Parameters.AddWithValue("@status", "ordered");
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
            string sql = "SELECT o.*, s.FirstName, s.Addrress, s.LastName, s.PostalCode, oi.BikeId, oi.Quantity, oi.status FROM Orders o left JOIN OrderItems oi ON o.Id = oi.OrderId left join ShippingInfo s on o.Shipping = s.id";

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
                        DateTime date = (DateTime)reader["Date"];
                        string status = (string)reader["Status"];
                        int accid = (int)reader["Accid"];
                        int bikeId = (int)reader["BikeId"];
                        int quantity = (int)reader["Quantity"];
                        string itemstatus = (string)reader["status"];
                        string FirstName = (string)reader["FirstName"];
                        string LastName = (string)reader["LastName"];
                        string Addrress = (string)reader["Addrress"];
                        string PostalCode = (string)reader["PostalCode"];
                        Order order = orders.FirstOrDefault(o => o.GetId() == id);
                        if (order == null)
                        {
                            order = new Order(id, status, accid, new List<Item>(), date, new ShippingInfo(FirstName, LastName, PostalCode, Addrress));
                            orders.Add(order);
                        }
                        Item item = new Item(bikeId, quantity, itemstatus);
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
            string sql = "SELECT o.*, s.FirstName, s.Addrress, s.LastName, s.PostalCode, oi.BikeId, oi.Quantity, oi.status FROM Orders o left JOIN OrderItems oi ON o.Id = oi.OrderId left join ShippingInfo s on o.Shipping = s.id where o.Id = @id";
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
                        DateTime date = (DateTime)reader["Date"];
                        int accid = (int)reader["Accid"];
                        int bikeId = (int)reader["BikeId"];
                        int quantity = (int)reader["Quantity"];
                        string itemstatus = (string)reader["status"];
                        string FirstName = (string)reader["FirstName"];
                        string LastName = (string)reader["LastName"];
                        string Addrress = (string)reader["Addrress"];
                        string PostalCode = (string)reader["PostalCode"];
                        order = new Order(id, status, accid, new List<Item>(), date, new ShippingInfo(FirstName, LastName, PostalCode,Addrress));
                        Item item = new Item(bikeId, quantity, itemstatus);
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

		public void UpdateStatus(int id, string status)
		{
            try
            {
                using(SqlConnection conn = new SqlConnection(connStr))
                {

                    string sql = "UPDATE Orders Set Status = @Status where id = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("Status", status);
					cmd.Parameters.AddWithValue("id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
				}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
		}

        public List<Order> GetUserOrders(int accid)
        {
            List<Order> orders = new List<Order>();
            string sql = "SELECT o.*, s.FirstName, s.Addrress, s.LastName, s.PostalCode, oi.BikeId, oi.Quantity, oi.status FROM Orders o left JOIN OrderItems oi ON o.Id = oi.OrderId left join ShippingInfo s on o.Shipping = s.id where o.Accid = @accid Order By o.Date desc";

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@accid", accid);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        string status = (string)reader["Status"];
                        DateTime date = (DateTime)reader["Date"];
                        int bikeId = (int)reader["BikeId"];
                        int quantity = (int)reader["Quantity"];
                        string itemstatus = (string)reader["status"];
                        string FirstName = (string)reader["FirstName"];
                        string LastName = (string)reader["LastName"];
                        string Addrress = (string)reader["Addrress"];
                        string PostalCode = (string)reader["PostalCode"];
                        Order order = orders.FirstOrDefault(o => o.GetId() == id);
                        if (order == null)
                        {
                            order = new Order(id, status, accid, new List<Item>(), date, new ShippingInfo(FirstName, LastName, PostalCode, Addrress));
                            orders.Add(order);
                        }
                        Item item = new Item(bikeId, quantity, itemstatus);
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

        public List<Order> GetOrdersByStatus(string status)
        {
            List<Order> orders = new List<Order>();
            string sql = "SELECT o.*, s.FirstName, s.Addrress, s.LastName, s.PostalCode, oi.BikeId, oi.Quantity, oi.status FROM Orders o left JOIN OrderItems oi ON o.Id = oi.OrderId left join ShippingInfo s on o.Shipping = s.id where o.status = @status";

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@status", status);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        DateTime date = (DateTime)reader["Date"];
                        int bikeId = (int)reader["BikeId"];
                        int quantity = (int)reader["Quantity"];
                        string itemstatus = (string)reader["status"];
                        int accid = (int)reader["Accid"];
                        string FirstName = (string)reader["FirstName"];
                        string LastName = (string)reader["LastName"];
                        string Addrress = (string)reader["Addrress"];
                        string PostalCode = (string)reader["PostalCode"];
                        Order order = orders.FirstOrDefault(o => o.GetId() == id);
                        if (order == null)
                        {
                            order = new Order(id, status, accid, new List<Item>(), date, new ShippingInfo(FirstName, LastName, PostalCode, Addrress));
                            orders.Add(order);
                        }
                        Item item = new Item(bikeId, quantity, itemstatus);
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
    }
}
