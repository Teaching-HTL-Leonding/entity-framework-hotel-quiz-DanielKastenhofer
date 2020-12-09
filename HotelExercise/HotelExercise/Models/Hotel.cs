using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace HotelExercise.Models
{
    public class Hotel
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public Adress Adress { get; set; }
        public List<Speciality> Specialities { get; set; }
        public List<RoomType> Rooms{ get; set; }

    }
}
