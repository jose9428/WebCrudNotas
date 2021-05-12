using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCrudNotas.Models;

namespace WebCrudNotas.Controllers
{
    public class HomeController : Controller
    {
        AlumnoDAO obj = new AlumnoDAO();
        public ActionResult Index()
        {
            List<Alumno> lista = obj.lisAlumno();

            return View(lista);
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Alumno alu)
        {
            obj.Agregar(alu);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Modificar(int id)
        {
            Alumno a = obj.ObtenerPorId(id);

            return View(a);
        }

        [HttpPost]
        public ActionResult Modificar(Alumno alu)
        {
            obj.Modificar(alu);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EliminarAlu(int id)
        {
            obj.Eliminar(id);

            return RedirectToAction("Index");
        }
    }
}