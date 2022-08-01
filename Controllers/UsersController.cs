using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using PlaceOrder.DAL;
using PlaceOrder.Models;

namespace PlaceOrder.Controllers
{
    public class UsersController : Controller
    {
        UsersDAL db = new UsersDAL();
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(Users users)
        {
            try
            {
                int res = db.UserSignUp(users);
                if (res == 1)
                {
                    return RedirectToAction("SignIn", "Users");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }

        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(Users users)
        {
            Users user = db.UserLogin(users);
            if (user.Password == users.Password)
            {
                HttpContext.Session.SetString("username", user.Name.ToString()+ " " + user.Emailid+" "+user.Password);
                HttpContext.Session.SetString("userid", user.Id.ToString());
                if (user.RoleId == Roles.Customer)
                {
                    return RedirectToAction("ViewProduct", "Product");
                }
                else if (user.RoleId == Roles.Admin)
                {
                    return RedirectToAction("Index", "Product");
                }

                else

                    return RedirectToAction("ViewProduct", "Product");
            }
            else
                return View();


        }




        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn");
        }
    }
}


