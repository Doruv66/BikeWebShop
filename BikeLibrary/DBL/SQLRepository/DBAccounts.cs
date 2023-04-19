﻿using BikeLibrary.BLL;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BikeClassLibrary;

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

        public Account GetAccountById(int id)
        {
            Account account;
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = "Select * from Accounts where id=@id;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        byte[] password = reader.GetSqlBytes(reader.GetOrdinal("password")).Buffer;
                        byte[] salt = reader.GetSqlBytes(reader.GetOrdinal("salt")).Buffer;
                        string email = (string)reader["email"];

                        account = new Account(id, password, salt, email);
                        return account;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
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

        public void SetShippingInformation(Account acc)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = "INSERT INTO ShippingInfo (AccId, FirstName, LastName, Addrress, PostalCode) VALUES (@AccId, @FirstName, @LastName, @Addrress, @PostalCode)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@AccId", acc.id);
                        cmd.Parameters.AddWithValue("@FirstName", acc.GetShippingInfo().Name);
                        cmd.Parameters.AddWithValue("@LastName", acc.GetShippingInfo().LastName);
                        cmd.Parameters.AddWithValue("@Addrress", acc.GetShippingInfo().Address);
                        cmd.Parameters.AddWithValue("@PostalCode", acc.GetShippingInfo().PostalCode);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Account GetShippingInformation(Account acc)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = "select * from ShippingInfo where AccId = @AccId";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.Parameters.AddWithValue("@AccId", acc.id);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string FirstName = (string)reader["FirstName"];
                            string LastName = (string)reader["LastName"];
                            string Addrress = (string)reader["Addrress"];
                            string PostalCode = (string)reader["PostalCode"];

                            acc.SetShippingInfo(new ShippingInfo(FirstName, LastName, PostalCode, Addrress));
                            return acc;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return acc;
        }

        public Account GetAccountByEmail(string email)
        {
            Account account;
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = "Select * from Accounts where email=@email;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@email", email);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        byte[] password = reader.GetSqlBytes(reader.GetOrdinal("password")).Buffer;
                        byte[] salt = reader.GetSqlBytes(reader.GetOrdinal("salt")).Buffer;

                        account = new Account(id, password, salt, email);
                        return account;
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