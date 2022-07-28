using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business;
using Entities;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace PruebaSII_Thales.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeBusiness bs = new EmployeeBusiness();
        // GET: EmployeeController
        public async Task<ActionResult> Index(int? EmployeeId)
        {
            var list = await bs.listEmployees();
            ViewBag.response = "true";
            if (list.Count == 0 && EmployeeId == null)
            {
                @ViewBag.response = "false";
                @ViewBag.Msj = "Data not found. Please try again.!";
            }
            else
            {
                list = bs.AnnualSalary(list);

                if (EmployeeId != 0 && EmployeeId != null)
                {
                    ViewBag.Id = EmployeeId;
                    var query = await bs.GetEmployeeId(EmployeeId);
                    query = bs.AnnualSalary(query);
                    if (query.ToList().Count == 1)
                    {
                        return View(query);
                    }
                }
            }
            return View(list);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
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

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
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
    }
}
