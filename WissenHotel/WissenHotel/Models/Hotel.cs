using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WissenHotel.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        [StringLength(200), Required(ErrorMessage = "Bu alan doldurulmalıdır!"), DisplayName("Otel İsmi")]
        public string HotelName { get; set; }

        [StringLength(200), Required(ErrorMessage = "Bu alan doldurulmalıdır!"), DisplayName("Adres")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Bu alan doldurulmalıdır!")]
        [DisplayName("İl")]
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [Required(ErrorMessage = "Bu alan doldurulmalıdır!"), DisplayName("İlçe")]
        public int TownId { get; set; }
        [ForeignKey("TownId")]
        public virtual Town Town { get; set; }

        [StringLength(500), DisplayName("Açıklama")]
        public string Explanation { get; set; }

        [Required(ErrorMessage = "Bu alan doldurulmalıdır!"), DisplayName("Oda Sayısı")]
        public int RoomCapacity { get; set; }

        public string HotelType { get; set; }

        [DisplayName("Oluşturulma Tarihi")]
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }
        [DisplayName("Oluşturan Kullanıcı")]
        public string CreatedBy { get; set; }
        [DisplayName("Güncelleme Tarihi")]
        [DataType(DataType.DateTime)]
        public DateTime UpdateDate { get; set; }
        [DisplayName("Güncelleyen Kullanıcı")]
        public string UpdatedBy { get; set; }

        [StringLength(350), DisplayName("Resim")]
        public string Foto { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}