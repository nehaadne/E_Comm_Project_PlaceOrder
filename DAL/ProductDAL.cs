using PlaceOrder.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceOrder.DAL

{
    public class ProductDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public ProductDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public List<Product> GetProducts()
        {
            List<Product> plist = new List<Product>();
            string qry = "select * from Product";
            cmd = new SqlCommand(qry, con);
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
                    p.CompanyName = dr["CompanyName"].ToString();
                    plist.Add(p);
                }
            }
            con.Close();
            return plist;
        }
        public Product GetProductById(int id)
        {
            Product p = new Product();
            string qry = "select * from Product where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    p.Id = Convert.ToInt32(dr["Id"]);
                    p.Name = dr["Name"].ToString();
                    p.Price = Convert.ToDouble(dr["Price"]);
                    p.CompanyName = dr["CompanyName"].ToString();
                }
            }
            con.Close();
            return p;
        }

        public int AddProduct(Product prod)
        {
            string qry = "insert into Product values(@name,@price,@companyname)";
            cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@name", prod.Name);
            cmd.Parameters.AddWithValue("@price", prod.Price);
            cmd.Parameters.AddWithValue("@companyname", prod.CompanyName);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateProduct(Product prod)
        {
            string qry = "update Product set Name=@name , Price=@price, CompanyName=@companyname where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", prod.Id);
            cmd.Parameters.AddWithValue("@name", prod.Name);
            cmd.Parameters.AddWithValue("@price", prod.Price);
            cmd.Parameters.AddWithValue("@Companyname", prod.CompanyName);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteProduct(int id)
        {
            string qry = "delete from Product where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}

