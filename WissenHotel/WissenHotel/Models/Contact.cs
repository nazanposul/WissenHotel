using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WissenHotel.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(50), Required(ErrorMessage = "Bu alan doldurulmalıdır!"), DisplayName("Soyad")]
        public string Surname { get; set; }
        [StringLength(20), Required(ErrorMessage = "Bu alan doldurulmalıdır!"), DisplayName("TC")]
        public string TC { get; set; }
        [StringLength(200), Required(ErrorMessage = "Bu alan doldurulmalıdır!"), DisplayName("Adres")]
        public string Address { get; set; }
        [StringLength(50), Required(ErrorMessage = "Bu alan doldurulmalıdır!"), DisplayName("Mail")]
        public string EMail { get; set; }
        [StringLength(50), Required(ErrorMessage = "Bu alan doldurulmalıdır!"), DisplayName("Telefon Numarası")]
        public string PhoneNumber { get; set; }
        [StringLength(50), DisplayName("Açıklama")]
        public string Explanation { get; set; }

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
        
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}