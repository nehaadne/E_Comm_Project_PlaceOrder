using PlaceOrder.Models;
using System;
using System.Data.SqlClient;

namespace PlaceOrder.DAL
{
    public class UsersDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public UsersDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public int UserSignUp(Users users)
        {
            string qry = "insert into Users(Name,Emailid,Password) values(@name,@emailid,@password)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", users.Name);
            cmd.Parameters.AddWithValue("@emailid", users.Emailid);
            cmd.Parameters.AddWithValue("@password", users.Password);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public Users UserLogin(Users users)
        {
            Users user = new Users();
            string qry = "select * from Users where Emailid=@emailid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("emailid", users.Emailid);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    user.Id = Convert.ToInt32(dr["Id"]);
                    user.Name = dr["Name"].ToString();
                    user.Emailid = dr["Emailid"].ToString();
                    user.Password = dr["Password"].ToString();
                  // user.RoleId = Convert.ToInt32(dr["RoleId"]);

                }
                con.Close();
                return user;

            }
            else
            {
                return user;
            }
        }
    }
}
