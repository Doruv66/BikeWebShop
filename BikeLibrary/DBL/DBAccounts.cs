using BikeLibrary.BLL;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BikeLibrary.DBL
{
    public class DBAccounts : IAccountRepository
    {
        private readonly string connStr;

        public DBAccounts(string conn)
        {
            connStr = conn;
        }

        public void AddAccount(Account account)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = "INSERT INTO Accounts (password, salt, email) VALUES (@password, @salt, @email)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("password", account.password);
                        cmd.Parameters.AddWithValue("salt", account.salt);
                        cmd.Parameters.AddWithValue("email", account.email);
                        cmd.ExecuteNonQuery();
                    }
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);  
            }
        }

        public List<Account> GetAll()
        {
            List<Account> accounts = new List<Account>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = "Select * from Accounts;";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        byte[] password = reader.GetSqlBytes(reader.GetOrdinal("password")).Buffer;
                        byte[] salt = reader.GetSqlBytes(reader.GetOrdinal("salt")).Buffer;
                        string email = (string)reader["email"];
                        
                        accounts.Add(new Account(id, password, salt, email));
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return accounts;
        }
    }
}
