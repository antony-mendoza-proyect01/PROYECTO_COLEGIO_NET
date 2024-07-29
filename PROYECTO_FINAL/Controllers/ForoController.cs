using PROYECTO_FINAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web.Mvc;

namespace PROYECTO_FINAL.Controllers
{
    public class ForoController : Controller
    {
        //cadena de conexion
        static string cadena = "Data Source=(local);Initial Catalog=DBPROYECTO;Integrated Security=true";
        private static List<Foro> oLista = new List<Foro>();
        // GET: Foro
        public ActionResult Foro()
        {
            oLista = new List<Foro>();
            using(SqlConnection oconexion = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM FORO", oconexion);
                cmd.CommandType = CommandType.Text;
                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Foro nuevoForo = new Foro();
                        nuevoForo.IdForo = Convert.ToInt32(dr["IdForo"]);
                        nuevoForo.Titulo = dr["Titulo"].ToString();
                        nuevoForo.Comentario = dr["Comentario"].ToString();

                        oLista.Add(nuevoForo);
                    }
                }
            }
            return View(oLista);
        }
        [HttpGet]
        public ActionResult Crear() {

            return View();
        }

        [HttpPost]
        public ActionResult Crear(Foro oforo)
        {
            using (SqlConnection oconexion = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarForo", oconexion);
                cmd.Parameters.AddWithValue("Titulo", oforo.Titulo);
                cmd.Parameters.AddWithValue("Comentario", oforo.Comentario);
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteReader();
            }
            return RedirectToAction("Foro", "Foro");
        }

        [HttpGet]
        public ActionResult Editar(int? idforo)
        {
            if (idforo == null)
                return RedirectToAction("Foro", "Foro");

            Foro oforo = oLista.Where(c=> c.IdForo == idforo).FirstOrDefault();

            return View(oforo);
        }

        [HttpPost]
        public ActionResult Editar(Foro oforo)
        {
            using (SqlConnection oconexion = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_EditarForo", oconexion);
                cmd.Parameters.AddWithValue("IdForo", oforo.IdForo);
                cmd.Parameters.AddWithValue("Titulo", oforo.Titulo);
                cmd.Parameters.AddWithValue("Comentario", oforo.Comentario);
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteReader();
            }
            return RedirectToAction("Foro", "Foro");
        }
        [HttpGet]
        public ActionResult Eliminar(int? idforo)
        {
            if (idforo == null)
                return RedirectToAction("Foro", "Foro");

            Foro oforo = oLista.Where(c => c.IdForo == idforo).FirstOrDefault();

            return View(oforo);
        }
        [HttpPost]
        public ActionResult Eliminar(string IdForo)
        {
            using (SqlConnection oconexion = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_Eliminar", oconexion);
                cmd.Parameters.AddWithValue("IdForo", IdForo);
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteReader();
            }
            return RedirectToAction("Foro", "Foro");
        }

    }
}