using FitZone.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Security.Policy;
using System.Web.Helpers;
using System.Xml.Linq;

namespace FitZone.Controllers
{
    public class TrainerController : Controller
    {
        private string NewsqlConn = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        // GET
        public ActionResult Index()
        {
            try
            {
                List<Trainer> Obj = new List<Trainer>();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_fetch_Trainers", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj.Add(new Trainer
                        {
                            TrainerID = Convert.ToInt32(sdr[0]),
                            Name = sdr[1].ToString(),
                            Email = sdr[2].ToString(),
                            Phone = sdr[3].ToString(),
                            Address = sdr[4].ToString(),
                            Specialization = sdr[5].ToString(),
                            ExperienceYears = Convert.ToInt32(sdr[6])
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
                Trainer Obj = new Trainer();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Trainers", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@TrainerID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Trainer
                        {
                            TrainerID = Convert.ToInt32(sdr[0]),
                            Name = sdr[1].ToString(),
                            Email = sdr[2].ToString(),
                            Phone = sdr[3].ToString(),
                            Address = sdr[4].ToString(),
                            Specialization = sdr[5].ToString(),
                            ExperienceYears = Convert.ToInt32(sdr[6])
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
        public ActionResult Create(Trainer Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_insert_Trainers", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@TrainerID", Obj.TrainerID);
                    SqlCmd.Parameters.AddWithValue("@Name", Obj.Name);
                    SqlCmd.Parameters.AddWithValue("@Email", Obj.Email);
                    SqlCmd.Parameters.AddWithValue("@Phone", Obj.Phone);
                    SqlCmd.Parameters.AddWithValue("@Address", Obj.Address);
                    SqlCmd.Parameters.AddWithValue("@Specialization", Obj.Specialization);
                    SqlCmd.Parameters.AddWithValue("@ExperienceYears", Obj.ExperienceYears);

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
                Trainer Obj = new Trainer();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Trainers", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@TrainerID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Trainer
                        {
                            TrainerID = Convert.ToInt32(sdr[0]),
                            Name = sdr[1].ToString(),
                            Email = sdr[2].ToString(),
                            Phone = sdr[3].ToString(),
                            Address = sdr[4].ToString(),
                            Specialization = sdr[5].ToString(),
                            ExperienceYears = Convert.ToInt32(sdr[6])
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
        public ActionResult Edit(int id, Trainer Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_update_Trainers", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@TrainerID", Obj.TrainerID);
                    SqlCmd.Parameters.AddWithValue("@Name", Obj.Name);
                    SqlCmd.Parameters.AddWithValue("@Email", Obj.Email);
                    SqlCmd.Parameters.AddWithValue("@Phone", Obj.Phone);
                    SqlCmd.Parameters.AddWithValue("@Address", Obj.Address);
                    SqlCmd.Parameters.AddWithValue("@Specialization", Obj.Specialization);
                    SqlCmd.Parameters.AddWithValue("@ExperienceYears", Obj.ExperienceYears);

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
                Trainer Obj = new Trainer();
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_select_Trainers", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@TrainerID", id);
                    SqlDataReader sdr = SqlCmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Obj = new Trainer
                        {
                            TrainerID = Convert.ToInt32(sdr[0]),
                            Name = sdr[1].ToString(),
                            Email = sdr[2].ToString(),
                            Phone = sdr[3].ToString(),
                            Address = sdr[4].ToString(),
                            Specialization = sdr[5].ToString(),
                            ExperienceYears = Convert.ToInt32(sdr[6])
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
        public ActionResult Delete(int id, Trainer Obj)
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(NewsqlConn))
                {
                    DbCon.Open();
                    SqlCommand SqlCmd = new SqlCommand("sp_delete_Trainers", DbCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@TrainerID", id);

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
