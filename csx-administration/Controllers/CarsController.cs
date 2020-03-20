using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess.Model;
using DataAccess.Interface;
using DataAccess.Repository;
using csx_administration.Models;

namespace csx_administration.Controllers
{
    public class CarsController : Controller
    {
        private ICarRepository carsRepository;
        private IDriverRepository driverRepository;

        public CarsController(ICarRepository _carsRepository, IDriverRepository _driverRepository)
        {
            carsRepository = _carsRepository;
            driverRepository = _driverRepository;
        }
        // GET: Cars
        public ActionResult Index()
        {
            var cars = carsRepository.GetAll();
            return View(cars);
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = carsRepository.GetById((int)id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.Drivers = driverRepository.GetAll();
            return View();
        }

        // POST: Cars/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car, int currentDriverId)
        {
            if (ModelState.IsValid)
            {
                car.CurrentDriver = driverRepository.GetById(currentDriverId);
                carsRepository.Create(car);
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = carsRepository.GetById((int)id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.Drivers = driverRepository.GetAll();
            return View(car);
        }

        // POST: Cars/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                carsRepository.Update(car);
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = carsRepository.GetById((int)id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = carsRepository.GetById((int) id);
            carsRepository.Delete(car);

            return RedirectToAction("Index");
        }
    }
}
