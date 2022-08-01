using PlaceOrder.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PlaceOrder.DAL

{
    public class OrdersDAL
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public OrdersDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        private bool CheckOrderData(Orders or)
        {

            return true;
        }
        public int PlaceOrder(Orders or)
        {
            bool result = CheckOrderData(or);
            if (result == true)
            {
                string qry = "insert into Orders(ProdId,UserId) values(@prodid,@userid)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@prodid", or.ProdId);
                cmd.Parameters.AddWithValue("@userId", or.UserId);

                con.Open();
                int res = cmd.ExecuteNonQuery();
                con.Close();
                return res;
            }
            else
            {
                return 2;
            }
        }

        public List<Product> ViewProductForOrder(string userid)
        {
            List<Product> plist = new List<Product>();
            string qry = "select p.Id,p.Name,p.Price, o.OrderId,O.UserId from Product p " +
                        " inner join Orders o on o.ProdId = p.Id " +
                        " where o.UserId = @id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(userid));
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.Id = Convert.ToInt32(dr["Id"]);
                    p.Name = dr["Name"].ToString();
                    p.Price = Convert.ToDouble(dr["Price"]);
                    p.OrderId = Convert.ToInt32(dr["OrderId"]);
                    p.UserId = Convert.ToInt32(dr["UserId"]);
                    plist.Add(p);
                }
                con.Close();
                return plist;
            }
            else
            {
                return plist;
            }
        }
        public int RemoveFromOrders(int id)
        {

            string qry = "delete from Orders where OrderId=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }
}
