using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class OrderRepository : IOrderRepository
    {

        public IConfiguration Configuration { get; set; }
        public string connectionString;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(IConfiguration configuration, ILogger<OrderRepository> logger)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings: DefaultConnection"];
        }

        //end step 9
        public Order AddOrder(Order order)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try   //exception handling
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spInsertIntoOrder]", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();  //make connection
                    
                    cmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                    cmd.Parameters.AddWithValue("@Description", order.Description);
                    cmd.Parameters.AddWithValue("@OrderCost", order.OrderCost);
                    
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error at AddOrder():(");
                    order = null;
                }
            }

            return order;
        }

        public void DeleteOrder(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try   //exception handling
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spDeleteOrder", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();  //make connection
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error at DeleteOrder():(");
                }
            }
        }

        public IEnumerable<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try   //exception handling
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spSelectOrder]", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();  //make connection
                    SqlDataReader rdr = cmd.ExecuteReader();  //initializing data reader class, CONNECTION ORIENTED
                    while (rdr.Read())  //while loop
                    {
                        Order order = new Order(); //initialize order object
                        order.Id = Convert.ToInt32(rdr["Id"]);
                        order.CustomerId = Convert.ToInt32(rdr["CustomerId"]);
                        order.Description= rdr["Description"].ToString();
                        order.OrderCost = Convert.ToDecimal(rdr["OrderCost"]);
                        orders.Add(order);
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error at GetAllOrders():(");
                    orders = null;
                }
            }

            return orders;
        }

        public Order GetOrderById(int Id)
        {
            {
                Order order = new Order();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try   //exception handling
                    {
                        SqlCommand cmd = new SqlCommand("[dbo].[spSelectOrderById]", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();  //make connection
                        cmd.Parameters.AddWithValue("@Id", Id);  //for parameter
                        SqlDataReader rdr = cmd.ExecuteReader();  //initializing data reader class, CONNECTION ORIENTED
                        while (rdr.Read())  //while loop, returns a boolean true
                        {
                            order.Id = Id;
                            order.CustomerId = Convert.ToInt32(rdr["CustomerId"]);
                            order.Description = rdr["Description"].ToString();
                            order.OrderCost = Convert.ToDecimal(rdr["OrderCost"]);

                        }
                        rdr.Close();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error at GetOrderById():(");
                        order = null;
                    }
                }

                return order;
            }

        }

        public Order UpdateOrder(Order order)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try   //exception handling
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spUpdateOrder", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();  //make connection

                    cmd.Parameters.AddWithValue("@Id", order.Id);
                    cmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                    cmd.Parameters.AddWithValue("@Description", order.Description);
                    cmd.Parameters.AddWithValue("@OrderCost", order.OrderCost);
                  
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error at UpdateCustomer():(");
                    order = null;
                }
            }

            return order;
        }
    }
}
