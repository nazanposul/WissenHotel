using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WissenHotel.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}