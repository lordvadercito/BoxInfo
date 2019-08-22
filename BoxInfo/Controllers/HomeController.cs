using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BoxInfo.Models;
using BoxInfo.DB;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;

namespace BoxInfo.Controllers
{
    public class HomeController : Controller
    {
        private readonly BoxInfoDbContext _context;

        public HomeController(BoxInfoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetBoxes(string codbar)
        {
            Box box = new Box();
            string storedProcedure = "HH_getBoxInformation";
            string connStr = _context.Database.GetDbConnection().ConnectionString;
            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(storedProcedure, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CODBAR", SqlDbType.VarChar);
                cmd.Parameters["@CODBAR"].Value = codbar;
                conn.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    rdr.Read();
                    

                    box.Codbar = (string)rdr["CODBAR"];
                    box.FechaProduccion = (DateTime)rdr["FECHA_PRODUCCION"];
                    box.Turno = (int)rdr["TURNO"];
                    box.NroPlan = (int)rdr["PLAN"];
                    box.NombrePlan = (string)rdr["NOMBRE PLAN"];

                }
                else
                {
                    return View("NotFound");
                }

            }

            return View("ResultGrid", box);
        }
    }
}
