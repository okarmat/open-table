using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using OpenTable.Extensions;
using OpenTable.Models;
using OpenTable.Repositories;
using OpenTable.ViewModels;

namespace OpenTable.Controllers
{
    public class ReservationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IUnitOfWork _unitOfWork;

        public ReservationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Reservations
        public ActionResult Index()
        {
            var reservations = db.Reservations.Include(r => r.Table);
            return View(reservations.ToList());
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create/RestaurantId
        public ActionResult Create(int restaurantId)
        {
            var restaurant = _unitOfWork.RestaurantRepository.GetById(restaurantId);
            var tables = _unitOfWork.TableRepository.GetByRestaurantId(restaurantId);

            var createReservationViewModel = new CreateReservationViewModel
            {
                RestaurantId = restaurantId,
                RestaurantName = restaurant.Name,
                Tables = tables.ToJson(),
                ReservationDate = DateTime.Now
            };

            return View(createReservationViewModel);
        }

        // POST: Reservations/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]        
        public ActionResult Create([Bind(Include = "ReservingPersonEmail,ReservationDate,RestaurantId,RestaurantName,TableId,Tables")] CreateReservationViewModel reservationViewModel)
        {            
            if (ModelState.IsValid)
            {
                var reservation = new Reservation
                {
                    ReservationDate = reservationViewModel.ReservationDate,
                    ReservingPersonEmail = reservationViewModel.ReservingPersonEmail,
                    TableId = reservationViewModel.TableId
                };
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index", "Restaurants");
            }

            var restaurant = _unitOfWork.RestaurantRepository.GetById(reservationViewModel.RestaurantId);
            var tables = _unitOfWork.TableRepository.GetByRestaurantId(reservationViewModel.RestaurantId);

            var createReservationViewModelAgain = new CreateReservationViewModel
            {
                RestaurantId = reservationViewModel.RestaurantId,
                RestaurantName = reservationViewModel.RestaurantName,
                Tables = tables.ToJson(),
                ReservationDate = DateTime.Now
            };

            return View(reservationViewModel);
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.TableId = new SelectList(db.Tables, "Id", "Id", reservation.TableId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReservingPersonEmail,ReservationDate,TableId")] CreateReservationViewModel reservationViewModel)
        {
            if (ModelState.IsValid)
            {
                var reservation = new Reservation
                {
                    ReservationDate = reservationViewModel.ReservationDate,
                    TableId = reservationViewModel.TableId
                };

                db.Entry(reservationViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reservationViewModel);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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

        public void Reserve(Reservation reservation)
        {
            _unitOfWork.ReservationRepository.Add(reservation);
            _unitOfWork.Complete();
        }
    }
}
