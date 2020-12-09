using System;
using System.Collections.Generic;
using System.Text;

namespace HotelExercise.Models
{
    public class Price
    {
        public int Id { get; set; }
        public RoomType Room { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? UntilDate { get; set; }
        public int PricePerNight { get; set; }

    }
}
