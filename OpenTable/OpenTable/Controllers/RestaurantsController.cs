using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using OpenTable.Models;
using OpenTable.Repositories;
using OpenTable.ViewModels;

namespace OpenTable.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RestaurantsController(
            IUnitOfWork unitOfWork,
            ITableRepository tableRepository
            )
        {
            _unitOfWork = unitOfWork;
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Restaurants
        public ActionResult Index()
        {
            var tables = db.Tables;
            var restaurants = _unitOfWork.RestaurantRepository.GetAll();
            foreach (var restaurant in restaurants)
            {
                restaurant.Tables = tables.Where(t => t.RestaurantId == restaurant.Id).ToList();
            };

            var restaurantViewModel = new RestaurantsViewModel
            {
                Restaurants = restaurants
            };

            return View(restaurantViewModel);
        }
        
        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Manage(int id)
        {
            var restaurant = _unitOfWork.RestaurantRepository.GetById(id);
            restaurant.Tables = _unitOfWork.TableRepository.GetByRestaurantId(restaurant.Id);
            var tablesJson = "[]";
            var tablesMaxId = restaurant.Tables.Count == 0 ? 1 : restaurant.Tables.Select(t => t.Id).Max() + 1;

            if (restaurant.Tables.Any())
                tablesJson = new JavaScriptSerializer()
                    .Serialize(restaurant.Tables
                    .Select(s => new { s.Id, s.Left, s.Top, s.RestaurantId }));

            var tableManagementViewModel = new TableManagementViewModel
            {
                RestaurantId = id,
                RestaurantName = restaurant.Name,
                TablesMaxId = tablesMaxId,
                Tables = tablesJson
            };
            return View(tableManagementViewModel);
        }
        
        public void SaveTablesSet(List<Table> tables)
        {
            if (tables == null)
                return;

            foreach (var table in tables.Where(t => t != null))
            {
                var tableFromDatabase = _unitOfWork.TableRepository.GetById(table.Id);
                if (tableFromDatabase == null)
                    _unitOfWork.TableRepository.Add(table);
                else
                    _unitOfWork.TableRepository.Update(table);                
            }
            _unitOfWork.TableRepository.Delete(tables);

            _unitOfWork.Complete();
        }
    }
}
