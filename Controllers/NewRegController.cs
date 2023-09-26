using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reguser.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;

namespace Reguser.Controllers
{
    public class NewRegController : Controller
    {
        // GET: NewReg
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User uc, HttpPostedFileBase file)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(mainconn);
           
            SqlCommand sqlcomm=new SqlCommand("sp_Insertion", sqlConn);
            sqlcomm.CommandType = CommandType.StoredProcedure;
            sqlConn.Open();
            sqlcomm.Parameters.AddWithValue("@name", uc.Name);
            sqlcomm.Parameters.AddWithValue("@email", uc.Email);
            sqlcomm.Parameters.AddWithValue("@password", uc.Password);
            sqlcomm.Parameters.AddWithValue("@gender", uc.Gender);



             if (file!= null && file.ContentLength>0) { 
                 string filename =Path.GetFileName(file.FileName);


                 string imgpath = Path.Combine(Server.MapPath("~/userimage/"),filename);
                 file.SaveAs(imgpath);

             }
         


            sqlcomm.Parameters. AddWithValue ("@img", "~/userimage/" + file.FileName);
            sqlcomm.ExecuteNonQuery();
            sqlConn.Close();
            ViewData["Message"]=("user record" +" "+ uc.Name +" "+"is saved Sucessfully");
            return View();
        }
    }
}