using Microsoft.AspNetCore.Mvc;
using WebAppMVC_Sqldemo.Models;

namespace WebAppMVC_Sqldemo.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeRepository _emprepo;

        public EmployeeController(IEmployeeRepository _emprepo)
        {
            this._emprepo = _emprepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var ListEmp = _emprepo.GetAllEmployee();
            return View(ListEmp);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var emp = _emprepo.GetEmployee(id);
            return View(emp);
        }

        [HttpGet]

        public IActionResult create()
        {
            return View();
        }


        [HttpPost]

        public IActionResult create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                 _emprepo.Add(employee);
                return RedirectToAction(nameof(Index));
            }
           return View();
           // return "Not Added";
        }

        [HttpGet]

        public ActionResult Edit(int id)
        {
            return View(_emprepo.GetEmployee(id));
        }

        [HttpPost]

        public ActionResult Edit(int id, Employee employee)
        {
            if (ModelState.IsValid)
            {
                _emprepo.Update(employee);

                return RedirectToAction("Index");
            }

            return View();

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(_emprepo.GetEmployee(id));
        }

        [HttpPost]

        public ActionResult Delete(int id, Employee employee)
        {
            _emprepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
