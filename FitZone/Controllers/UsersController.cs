using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using FitZone.Models;
using System.Web.UI;
using System.Web.Security;
using System.Net.Mail;
using System.Net;
using static System.Net.WebRequestMethods;
using Microsoft.Ajax.Utilities;
using System.Web.Optimization;

namespace FitZone.Controllers
{
    public class UsersController : Controller
    {
        string AdminEmail;
        string AdminEmailPass;
        List<string> Roles = new List<string> { "supplier", "manager", "staff" };
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;

        // GET: User
        public ActionResult Index()
        {
            try
            {
                List<User> Obj = new List<User>();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_fetch_users", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj.Add(new User
                        {
                            UserID = Convert.ToInt32(sdr[0]),
                            Name = sdr[1].ToString(),
                            Email = sdr[2].ToString(),
                            Phone = Convert.ToInt64(sdr[3]),
                            Address = sdr[4].ToString(),
                            Role = sdr[5].ToString(),
                            Password = sdr[6].ToString()
                        });
                    }
                    DbCon.Close();
                }
                return View(Obj);
            }
            catch
            {
                return RedirectToAction("../Home/Error");
            }
        }

        // GET: Login/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    User Obj = new User();
                    using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                    {
                        DbCon.Open();
                        SqlCommand SqlCmd = new SqlCommand("sp_select_users", DbCon);
                        SqlCmd.CommandType = CommandType.StoredProcedure;
                        SqlCmd.Parameters.AddWithValue("@UserID", Session["UserId"]);
                        SqlDataReader sdr = SqlCmd.ExecuteReader();

                        while (sdr.Read())
                        {
                            Obj = new User
                            {
                                UserID = Convert.ToInt32(sdr[0]),
                                Name = sdr[1].ToString(),
                                Email = sdr[2].ToString(),
                                Phone = Convert.ToInt64(sdr[3]),
                                Address = sdr[4].ToString(),
                                Role = sdr[5].ToString(),
                                Password = sdr[6].ToString()
                            };
                        }
                        DbCon.Close();
                    }
                    return View(Obj);
                }
                else
                {
                    User Obj = new User();
                    using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                    {
                        DbCon.Open();
                        SqlCommand SqlCmd = new SqlCommand("sp_select_users", DbCon);
                        SqlCmd.CommandType = CommandType.StoredProcedure;
                        SqlCmd.Parameters.AddWithValue("@UserID", id);
                        SqlDataReader sdr = SqlCmd.ExecuteReader();

                        while (sdr.Read())
                        {
                            Obj = new User
                            {
                                UserID = Convert.ToInt32(sdr[0]),
                                Name = sdr[1].ToString(),
                                Email = sdr[2].ToString(),
                                Phone = Convert.ToInt64(sdr[3]),
                                Address = sdr[4].ToString(),
                                Role = sdr[5].ToString(),
                                Password = sdr[6].ToString()
                            };
                        }
                        DbCon.Close();
                    }
                    return View(Obj);
                }
            }
            catch
            {
                return RedirectToAction("../Home/Error");
            }
        }

        public ActionResult Create()
        {
            ViewBag.RoleOptions = Roles;
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(User Obj)
        {
            try
            {
                ViewBag.RoleOptions = Roles;
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_insert_users", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@Name", Obj.Name);
                    SqlCmd.Parameters.AddWithValue("@Email", Obj.Email);
                    SqlCmd.Parameters.AddWithValue("@Phone", Obj.Phone);
                    SqlCmd.Parameters.AddWithValue("@Address", Obj.Address);
                    SqlCmd.Parameters.AddWithValue("@Role", Obj.Role);
                    SqlCmd.Parameters.AddWithValue("@Password", Obj.Password);

                    SqlCmd.ExecuteNonQuery();
                    DbCon.Close();
                }
                return RedirectToAction("Index");
            }
            catch 
            {
                return RedirectToAction("../Home/Error");
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                User Obj = new User();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_users", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@UserID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new User
                        {
                            UserID = Convert.ToInt32(sdr[0]),
                            Name = sdr[1].ToString(),
                            Email = sdr[2].ToString(),
                            Phone = Convert.ToInt64(sdr[3]),
                            Address = sdr[4].ToString(),
                            Role = sdr[5].ToString(),
                            Password = sdr[6].ToString(),
                        };
                    }
                    DbCon.Close();
                }
                return View(Obj);
            }
            catch
            {
                return RedirectToAction("../Home/Error");
            }
        }
        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_users", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@Name", Obj.Name);
                    SqlCmd.Parameters.AddWithValue("@Email", Obj.Email);
                    SqlCmd.Parameters.AddWithValue("@Phone", Obj.Phone);
                    SqlCmd.Parameters.AddWithValue("@Address", Obj.Address);
                    SqlCmd.Parameters.AddWithValue("@Role", Obj.Role);
                    SqlCmd.Parameters.AddWithValue("@Password", Obj.Password);

                    SqlCmd.ExecuteNonQuery();
                    DbCon.Close();
                }
                return RedirectToAction("Index");
            }
            catch 
            {
                return RedirectToAction("../Home/Error");
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                User Obj = new User();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_users", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@UserID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new User
                        {
                            UserID = Convert.ToInt32(sdr[0]),
                            Name = sdr[1].ToString(),
                            Email = sdr[2].ToString(),
                            Phone = Convert.ToInt64(sdr[3]),
                            Address = sdr[4].ToString(),
                            Role = sdr[5].ToString(),
                            Password = sdr[6].ToString()
                        };
                    }
                    DbCon.Close();
                }
                return View(Obj);
            }
            catch 
            {
                return RedirectToAction("../Home/Error");
            }
        }
        // POST: Delete
        [HttpPost]
        public ActionResult Delete(int id, User Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_delete_users", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@UserID", id);

                    SqlCmd.ExecuteNonQuery();
                    DbCon.Close();
                }

                return RedirectToAction("Index");
            }
            catch 
            {
                return RedirectToAction("../Home/Error");
            }
        }

        // GET: Email
        public ActionResult Email()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Email(User Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_admin", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = SqlCmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        AdminEmail = sdr[2].ToString();
                        AdminEmailPass = sdr[7].ToString();

                    }
                    DbCon.Close();
                }
                Session["RegisterEmail"] = Obj.Email;

                string from, pass, messageBody, to;
                Random random = new Random();
                Session["RegisterRandom"] = (random.Next(999999)).ToString();
                MailMessage message = new MailMessage();
                to = (Obj.Email).ToString();
                from = AdminEmail;
                pass = AdminEmailPass;
                messageBody = "Your Email Verification Code: " + Session["RegisterRandom"];
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = messageBody;
                message.Subject = "Verification Code:";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);
                try
                {
                    smtp.Send(message);
                    return RedirectToAction("Register");
                }
                catch 
                {
                    TempData["Message"] = "OTP Send Failed!";
                    return View("Email");
                }
            }
            catch 
            {
                return RedirectToAction("../Home/Error");
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(CombinedUser Obj)
        {
            try
            {
                if (Obj == null)
                {
                    TempData["Message"] = "Invalid user information.";
                    return RedirectToAction("../Home/Error");
                }

                string randomcode = Session["RegisterRandom"].ToString();

                if (Convert.ToString(Obj.UserDTOs.OTP).Trim() == randomcode.Trim())
                {
                    if (Obj.Users.Password == Obj.UserDTOs.ConfirmPassword)
                    {
                        using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                        {
                            DbCon.Open();
                            SqlCommand SqlCmd = new SqlCommand("sp_create_users", DbCon);
                            SqlCmd.CommandType = CommandType.StoredProcedure;
                            SqlCmd.Parameters.AddWithValue("@Name", Obj.Users.Name);
                            SqlCmd.Parameters.AddWithValue("@Email", Session["RegisterEmail"]);
                            SqlCmd.Parameters.AddWithValue("@Phone", Obj.Users.Phone);
                            SqlCmd.Parameters.AddWithValue("@Address", Obj.Users.Address);
                            SqlCmd.Parameters.AddWithValue("@Password", Obj.Users.Password);

                            int a = SqlCmd.ExecuteNonQuery();
                            DbCon.Close();
                            Session["RegisterEmail"] = null;
                            if (a > 0)
                            {
                                TempData["Message"] = "Successfully Registered";
                                return RedirectToAction("../Home/Index");
                            }
                            else
                            {
                                TempData["Message"] = "Error";
                                return RedirectToAction("Register");
                            }
                        }
                    }
                    else
                    {
                        return View("Register");
                    }
                }
                else
                {
                    TempData["Message"] = "OTP Mismached";
                    return View("Register");
                }
            }
            catch 
            {
                return RedirectToAction("../Home/Error");
            }
        }

        // GET: Login 
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_users", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@Email", Obj.Email);
                    SqlCmd.Parameters.AddWithValue("@Password", Obj.Password);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    if (sdr.Read())
                    {
                        Session["UserId"] = Convert.ToInt32(sdr[0]);
                        Session["UserName"] = sdr[1].ToString();
                        Session["UserEmail"] = sdr[2].ToString();
                        Session["UserRole"] = sdr[5].ToString();
                        Session["UserPassword"] = sdr[6].ToString();

                        return RedirectToAction("../Home/Index");                        
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }
                }
            }
            catch 
            {
                return RedirectToAction("../Home/Error");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("../Home/Index");
        }

        public ActionResult UserEdit(int id)
        {
            try
            {
                User Obj = new User();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_users", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@UserID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new User
                        {
                            UserID = Convert.ToInt32(sdr[0]),
                            Name = sdr[1].ToString(),
                            Email = sdr[2].ToString(),
                            Phone = Convert.ToInt64(sdr[3]),
                            Address = sdr[4].ToString(),
                            Role = sdr[5].ToString(),
                            Password = sdr[6].ToString()
                        };
                    }
                    DbCon.Close();
                }
                return View(Obj);
            }
            catch 
            {
                return RedirectToAction("../Home/Error");
            }
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult UserEdit(int id, User Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_users", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@UserID", id);
                    SqlCmd.Parameters.AddWithValue("@Name", Obj.Name);
                    SqlCmd.Parameters.AddWithValue("@Phone", Obj.Phone);
                    SqlCmd.Parameters.AddWithValue("@Address", Obj.Address);

                    SqlCmd.ExecuteNonQuery();
                    DbCon.Close();
                }
                return RedirectToAction("../Home/Index");
            }
            catch 
            {
                return RedirectToAction("../Home/Error");
            }
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(CombinedUser Obj)
        {
            try
            {
                if (Obj == null)
                {
                    TempData["Message"] = "Invalid user information.";
                    return RedirectToAction("../Home/Error");
                }
                if (Obj.Users.Password == Obj.UserDTOs.ConfirmPassword)
                {
                    using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                    {
                        DbCon.Open();
                        SqlCommand SqlCmd = new SqlCommand("sp_update_users", DbCon);
                        SqlCmd.CommandType = CommandType.StoredProcedure;
                        SqlCmd.Parameters.AddWithValue("@UserID", Session["UserId"]);
                        SqlCmd.Parameters.AddWithValue("@Email", Session["UserEmail"]);
                        SqlCmd.Parameters.AddWithValue("@Password", Obj.Users.Password);
                        SqlCmd.Parameters.AddWithValue("@OldPassword", Obj.UserDTOs.OldPassword);

                        int a = SqlCmd.ExecuteNonQuery();
                        DbCon.Close();

                        if (a > 0)
                        {
                            TempData["Message"] = "Successfull.";
                            return RedirectToAction("../Home/Index");
                        }
                        else
                        {
                            TempData["Message"] = "Error!";
                            return RedirectToAction("ResetPassword");
                        }
                    }
                }
                else
                {
                    TempData["Message"] = "Password Mismached";
                    return View("ResetPassword");
                }
            }
            catch 
            {
                return RedirectToAction("../Home/Error");
            }
        }

        public ActionResult ForgotPwdOtp(CombinedUser Obj)
        {
            try
            {
                string UserEmail;

                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_admin", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    
                    SqlDataReader sdr = SqlCmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        AdminEmail = sdr[2].ToString();
                        AdminEmailPass = sdr[7].ToString();
                    }
                    sdr.Close();

                    SqlCommand SqlCmd2 = new SqlCommand("sp_select_users_mail", DbCon);
                    SqlCmd2.CommandType = CommandType.StoredProcedure;
                    SqlCmd2.Parameters.AddWithValue("@Email", Obj.Users.Email);
                    SqlDataReader sdr2 = SqlCmd2.ExecuteReader();
                    if (sdr2.Read())
                    {
                        UserEmail = sdr2[2].ToString();

                        DbCon.Close();

                        string from, pass, messageBody, to;
                        Random random = new Random();
                        Session["ForgotPwdrandom"] = (random.Next(999999)).ToString();
                        MailMessage message = new MailMessage();
                        to = UserEmail;
                        from = AdminEmail;
                        pass = AdminEmailPass;
                        messageBody = "Your Email Verification Code: " + Session["ForgotPwdrandom"];
                        message.To.Add(to);
                        message.From = new MailAddress(from);
                        message.Body = messageBody;
                        message.Subject = "Verification Code:";
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.EnableSsl = true;
                        smtp.Port = 587;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential(from, pass);
                        try
                        {
                            smtp.Send(message);
                            TempData["TimeOut"] = "OtpRequest()";
                            return RedirectToAction("ForgotPassword", new { email = Obj.Users.Email });
                        }
                        catch 
                        {
                            TempData["Message"] = "OTP Send Failed!";
                            return RedirectToAction("ForgotPassword");
                        }
                    }
                    else 
                    {
                        TempData["Message"] = "Email Not Registered with us!";
                        return RedirectToAction("ForgotPassword");
                    }
                }
            }
            catch 
            {
                return RedirectToAction("../Home/Error");
            }
        }
        public ActionResult ForgotPassword(string email)
        {
            try
            {


                CombinedUser Obj = new CombinedUser();
                Obj.Users = new User();

                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd2 = new SqlCommand("sp_select_users_mail", DbCon);
                    SqlCmd2.CommandType = CommandType.StoredProcedure;
                    SqlCmd2.Parameters.AddWithValue("@Email", email);
                    SqlDataReader sdr2 = SqlCmd2.ExecuteReader();
                    if (sdr2.Read())
                    {
                        Obj.Users.Email = sdr2[2].ToString();
                    }
                }
                return View(Obj);
            }
            catch
            {
                return RedirectToAction("../Home/Error");
            }

        }

        [HttpPost]
        public ActionResult ForgotPassword(CombinedUser Obj)
        {
            try
            {
                if (Obj == null)
                {
                    TempData["Message"] = "Invalid user information.";
                    return RedirectToAction("../Home/Error");
                }

                string randomcode = Session["ForgotPwdrandom"].ToString();

                if (Convert.ToString(Obj.UserDTOs.OTP).Trim() == randomcode.Trim())
                {
                    if (Obj.Users.Password == Obj.UserDTOs.ConfirmPassword)
                    {
                        using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                        {
                            DbCon.Open();
                            SqlCommand SqlCmd = new SqlCommand("sp_update_users", DbCon);
                            SqlCmd.CommandType = CommandType.StoredProcedure;
                            SqlCmd.Parameters.AddWithValue("@Email", Obj.Users.Email);
                            SqlCmd.Parameters.AddWithValue("@Password", Obj.Users.Password);

                            int a = SqlCmd.ExecuteNonQuery();
                            DbCon.Close();

                            if (a > 0)
                            {
                                TempData["Message"] = "Successfull";
                                return RedirectToAction("../Home/Index");
                            }
                            else
                            {
                                TempData["Message"] = "Error";
                                return RedirectToAction("ForgotPassword");
                            }
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Password Mismached";
                        return View("ForgotPassword");
                    }
                }
                else
                {
                    TempData["Message"] = "OTP Mismached";
                    return View("ForgotPassword");
                }
            }
            catch 
            {
                return RedirectToAction("../Home/Error");
            }
        }
    }    
}
