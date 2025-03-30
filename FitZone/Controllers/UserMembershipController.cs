using FitZone.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FitZone.Controllers
{
    public class UserMembershipController : Controller
    {
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        // GET
        public ActionResult Index()
        {
            try
            {
                List<UserMembership> Obj = new List<UserMembership>();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_fetch_UserMemberships", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj.Add(new UserMembership
                        {
                            UserMembershipID = Convert.ToInt32(sdr[0]),
                            UserID = Convert.ToInt32(sdr[1]),
                            MembershipID = Convert.ToInt32(sdr[2]),
                            StartDate = Convert.ToDateTime(sdr[3]),
                            EndDate = Convert.ToDateTime(sdr[4]),
                            Status = sdr[5].ToString()
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

        // GET 
        public ActionResult Details(int id)
        {
            try
            {
                UserMembership Obj = new UserMembership();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_UserMemberships", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@UserMembershipID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new UserMembership
                        {
                            UserMembershipID = Convert.ToInt32(sdr[0]),
                            UserID = Convert.ToInt32(sdr[1]),
                            MembershipID = Convert.ToInt32(sdr[2]),
                            StartDate = Convert.ToDateTime(sdr[3]),
                            EndDate = Convert.ToDateTime(sdr[4]),
                            Status = sdr[5].ToString()
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

        // GET
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult Create(UserMembership Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_insert_UserMemberships", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@UserMembershipID", Obj.UserMembershipID);
                    SqlCmd.Parameters.AddWithValue("@UserID", Obj.UserID);
                    SqlCmd.Parameters.AddWithValue("@MembershipID", Obj.MembershipID);
                    SqlCmd.Parameters.AddWithValue("@StartDate", Obj.StartDate);
                    SqlCmd.Parameters.AddWithValue("@EndDate", Obj.EndDate);
                    SqlCmd.Parameters.AddWithValue("@Status", Obj.Status);

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

        // GET
        public ActionResult Edit(int id)
        {
            try
            {
                UserMembership Obj = new UserMembership();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_UserMemberships", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@UserMembershipID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new UserMembership
                        {
                            UserMembershipID = Convert.ToInt32(sdr[0]),
                            UserID = Convert.ToInt32(sdr[1]),
                            MembershipID = Convert.ToInt32(sdr[2]),
                            StartDate = Convert.ToDateTime(sdr[3]),
                            EndDate = Convert.ToDateTime(sdr[4]),
                            Status = sdr[5].ToString()
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

        // POST
        [HttpPost]
        public ActionResult Edit(int id, UserMembership Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_UserMemberships", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@UserMembershipID", Obj.UserMembershipID);
                    SqlCmd.Parameters.AddWithValue("@UserID", Obj.UserID);
                    SqlCmd.Parameters.AddWithValue("@MembershipID", Obj.MembershipID);
                    SqlCmd.Parameters.AddWithValue("@StartDate", Obj.StartDate);
                    SqlCmd.Parameters.AddWithValue("@EndDate", Obj.EndDate);
                    SqlCmd.Parameters.AddWithValue("@Status", Obj.Status);

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

        // GET
        public ActionResult Delete(int id)
        {
            try
            {
                UserMembership Obj = new UserMembership();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_UserMemberships", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@UserMembershipID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new UserMembership
                        {
                            UserMembershipID = Convert.ToInt32(sdr[0]),
                            UserID = Convert.ToInt32(sdr[1]),
                            MembershipID = Convert.ToInt32(sdr[2]),
                            StartDate = Convert.ToDateTime(sdr[3]),
                            EndDate = Convert.ToDateTime(sdr[4]),
                            Status = sdr[5].ToString()
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

        // POST
        [HttpPost]
        public ActionResult Delete(int id, UserMembership Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_delete_UserMemberships", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@UserMembershipID", id);

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
    }
}
