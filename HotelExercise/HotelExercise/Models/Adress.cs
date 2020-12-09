using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelExercise.Models
{
    public class Adress
    {
        public int Id { get; set; }
        [MaxLength(60)]
        public string Street { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }

    }
}
