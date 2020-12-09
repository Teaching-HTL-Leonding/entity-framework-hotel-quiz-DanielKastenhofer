using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelExercise
{
    class HotelContextFactory : IDesignTimeDbContextFactory<HotelContext>
    {
        private string[] LaunchArgs { get; }

        public HotelContextFactory() { }
        public HotelContextFactory(string[] args)
        {
            LaunchArgs = args;
        }

        public HotelContext GetNewDbContext()
        {
            return CreateDbContext(LaunchArgs);
        }

        public HotelContext CreateDbContext(string[]? args = null)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var optionsBuilder = new DbContextOptionsBuilder<HotelContext>();
            optionsBuilder
                // Uncomment the following line if you want to print generated
                // SQL statements on the console.
                // .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);

            return new HotelContext(optionsBuilder.Options);
        }
    }
}
