using FitZone.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitZone.Controllers
{
    public class ScheduleController : Controller
    {
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        // GET
        public ActionResult Index()
        {
            try
            {
                List<Schedule> Obj = new List<Schedule>();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_fetch_Schedules", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj.Add(new Schedule
                        {
                            ScheduleID = Convert.ToInt32(sdr[0]),
                            ClassID = Convert.ToInt32(sdr[1]),
                            StartTime = Convert.ToDateTime(sdr[2]),
                            EndTime = Convert.ToDateTime(sdr[3]),
                            Location = sdr[4].ToString()
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
                Schedule Obj = new Schedule();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Schedules", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@ScheduleID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Schedule
                        {
                            ScheduleID = Convert.ToInt32(sdr[0]),
                            ClassID = Convert.ToInt32(sdr[1]),
                            StartTime = Convert.ToDateTime(sdr[2]),
                            EndTime = Convert.ToDateTime(sdr[3]),
                            Location = sdr[4].ToString()
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
        public ActionResult Create(Schedule Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_insert_Schedules", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@ScheduleID", Obj.ScheduleID);
                    SqlCmd.Parameters.AddWithValue("@ClassID", Obj.ClassID);
                    SqlCmd.Parameters.AddWithValue("@StartTime", Obj.StartTime);
                    SqlCmd.Parameters.AddWithValue("@EndTime", Obj.EndTime);
                    SqlCmd.Parameters.AddWithValue("@Location", Obj.Location);

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
                Schedule Obj = new Schedule();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Schedules", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@ScheduleID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Schedule
                        {
                            ScheduleID = Convert.ToInt32(sdr[0]),
                            ClassID = Convert.ToInt32(sdr[1]),
                            StartTime = Convert.ToDateTime(sdr[2]),
                            EndTime = Convert.ToDateTime(sdr[3]),
                            Location = sdr[4].ToString()
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
        public ActionResult Edit(int id, Schedule Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_Schedules", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@ScheduleID", Obj.ScheduleID);
                    SqlCmd.Parameters.AddWithValue("@ClassID", Obj.ClassID);
                    SqlCmd.Parameters.AddWithValue("@StartTime", Obj.StartTime);
                    SqlCmd.Parameters.AddWithValue("@EndTime", Obj.EndTime);
                    SqlCmd.Parameters.AddWithValue("@Location", Obj.Location);

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
                Schedule Obj = new Schedule();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Schedules", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@ScheduleID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Schedule
                        {
                            ScheduleID = Convert.ToInt32(sdr[0]),
                            ClassID = Convert.ToInt32(sdr[1]),
                            StartTime = Convert.ToDateTime(sdr[2]),
                            EndTime = Convert.ToDateTime(sdr[3]),
                            Location = sdr[4].ToString()
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
        public ActionResult Delete(int id, Schedule Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_delete_Schedules", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@ScheduleID", id);

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
