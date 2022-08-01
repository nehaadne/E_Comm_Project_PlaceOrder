using PlaceOrder.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PlaceOrder.DAL

{
    public class ViewCartDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public ViewCartDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        private bool CheckCartData(ViewCart cart)
        {

            return true;
        }
        public int AddToCart(ViewCart cart)
        {
            bool result = CheckCartData(cart);
            if (result == true)
            {
                string qry = "insert into ViewCart(ProdId,UserId) values(@prodId,@userId)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@prodId", cart.ProdId);
                cmd.Parameters.AddWithValue("@userId", cart.UserId);
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

        public List<Product> ViewProductsFromCart(string userid)
        {
            List<Product> plist = new List<Product>();
            string qry = "select p.Id,p.Name,p.Price, c.CartId,c.UserId from Product p " +
                        " inner join ViewCart c on c.ProdId = p.Id " +
                        " where c.UserId = @id";
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
                    p.CartId = Convert.ToInt32(dr["CartId"]);
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
        public int RemoveFromCart(int id)
        {

            string qry = "delete from ViewCart where CartId=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }


    }
}
