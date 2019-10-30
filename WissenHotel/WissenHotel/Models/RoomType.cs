using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WissenHotel.Models
{
    public class RoomType
    {
        public int Id { get; set; }

        [StringLength(10), Required(ErrorMessage = "Bu alan doldurulmalıdır!"), DisplayName("Oda Tipi")]
        public string RoomTypeName { get; set; }
        [Required(ErrorMessage = "Bu alan doldurulmalıdır!"), DisplayName("Oda Tipi Kapasitesi")]
        public int RoomTypeCapasity { get; set; }
        [Required(ErrorMessage = "Bu alan doldurulmalıdır!"), DisplayName("Günlük Oda Ücreti")]
        public decimal DailyCost { get; set; }

        [StringLength(100), Required(ErrorMessage = "Bu alan doldurulmalıdır!"), DisplayName("Oda Türü Açıklaması")]
        public string Explanation { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}