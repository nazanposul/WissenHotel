using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WissenHotel.Models;

namespace WissenHotel.Controllers
{
    //[Authorize]
    public class ReservationsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Reservations
        public async Task<ActionResult> Index()
        {
            var reservations = db.Reservations.Include(r => r.Contact).Include(r => r.Hotel).Include(r => r.RoomType);
            return View(await reservations.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = await db.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            var reservation = new Reservation();
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Name");
            ViewBag.HotelId = new SelectList(db.Hotels, "Id", "HotelName");
            ViewBag.RoomTypeId = new SelectList(db.RoomTypes, "Id", "RoomTypeName");
            return View(reservation);
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,HotelId,RoomTypeId,ContactId,EntryDate,ReleaseDate,Status,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                reservation.CreateDate = DateTime.Now;
                reservation.CreatedBy = "Unknown";
                reservation.UpdateDate = DateTime.Now;
                reservation.UpdatedBy = "Unknown";
                db.Reservations.Add(reservation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Name", reservation.ContactId);
            ViewBag.HotelId = new SelectList(db.Hotels, "Id", "HotelName", reservation.HotelId);
            ViewBag.RoomTypeId = new SelectList(db.RoomTypes, "Id", "RoomTypeName", reservation.RoomTypeId);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = await db.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Name", reservation.ContactId);
            ViewBag.HotelId = new SelectList(db.Hotels, "Id", "HotelName", reservation.HotelId);
            ViewBag.RoomTypeId = new SelectList(db.RoomTypes, "Id", "RoomTypeName", reservation.RoomTypeId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,HotelId,RoomTypeId,ContactId,EntryDate,ReleaseDate,Status,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                reservation.UpdateDate = DateTime.Now;
                reservation.UpdatedBy = "Unknown";
                db.Entry(reservation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Name", reservation.ContactId);
            ViewBag.HotelId = new SelectList(db.Hotels, "Id", "HotelName", reservation.HotelId);
            ViewBag.RoomTypeId = new SelectList(db.RoomTypes, "Id", "RoomTypeName", reservation.RoomTypeId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = await db.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Reservation reservation = await db.Reservations.FindAsync(id);
            db.Reservations.Remove(reservation);
            await db.SaveChangesAsync();
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
    }
}
