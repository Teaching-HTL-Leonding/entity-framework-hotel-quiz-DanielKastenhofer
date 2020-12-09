using System;
using System.Collections.Generic;
using System.Text;
using HotelExercise.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelExercise
{
    public class HotelContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Price> Prices { get; set; }

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        { }
    }
}