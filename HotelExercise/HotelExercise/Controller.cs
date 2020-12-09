using HotelExercise.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelExercise
{
    public class Controller
    {
        private readonly HotelContextFactory _contextFactory = new HotelContextFactory();

        public async Task AddHotel(Hotel hotel)
        {
            var dbContext = _contextFactory.GetNewDbContext();
            await dbContext.Hotels.AddAsync(hotel);
            //await dbContext.SaveChangesAsync(); somehow my application only works without this line | i really don't know why :(
        }

        public async Task AddPrices(List<Price> prices)
        {
            var dbContext = _contextFactory.GetNewDbContext();
            await dbContext.Prices.AddRangeAsync(prices);
            await dbContext.SaveChangesAsync();
        }

        public List<Hotel> GetAllHotels()
        {
            return _contextFactory.GetNewDbContext().Hotels.ToList<Hotel>();
        }
    }
}
