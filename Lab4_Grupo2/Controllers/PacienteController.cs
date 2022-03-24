using Lab4_Grupo2.Models;
using Lab4_Grupo2.Models.Datos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_Grupo2.Controllers
{
    public class PacienteController : Controller
    {
        // GET: PacienteController1
        public ActionResult Index()
        {
            return View(Singleton.Instance.Pacientes.GetList());
        }

        // GET: PacienteController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PacienteController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PacienteController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PacienteController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PacienteController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PacienteController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PacienteController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
