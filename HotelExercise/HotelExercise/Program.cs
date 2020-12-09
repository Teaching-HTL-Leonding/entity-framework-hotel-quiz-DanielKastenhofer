using HotelExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelExercise
{
    class Program
    { 
        static async System.Threading.Tasks.Task Main(string[] args)
        {

            HotelContextFactory contextFactory = new HotelContextFactory();

            var hotelController = new Controller();


            string choice;

            bool exit = false;
            do
            {
                Console.Write("Enter what u want to do(1 => add Data | 2 => display Data: | 3 => exit):");
                choice = Console.ReadLine();

                switch (choice?.Trim())
                {
                    case "1":
                        var currentHotel = new Hotel();

                        Console.Write("Enter hotel name: ");
                        currentHotel.Name = Console.ReadLine();
                        Console.Write("Enter hotel adress: ");
                        currentHotel.Adress = EnterAdress(Console.ReadLine());
                        Console.Write("Enter hotel specialities: ");
                        var specialities = Console.ReadLine().Trim().Split(", ").Select(s => new Speciality() { Name = s}).ToList();
                        currentHotel.Rooms = await EnterRoomsAsync(currentHotel, hotelController);
                        Console.WriteLine();
                        await hotelController.AddHotel(currentHotel);
                        break;

                    case "2":
                        /*List<Hotel>*/var hotels = hotelController.GetAllHotels();
                        foreach (var hotel in hotels)
                        {
                            Console.WriteLine(hotel.Id);
                            Console.WriteLine(hotel.Name);
                            Console.WriteLine("=================================");
                        }
                        Console.WriteLine();
                        
                        break;

                    default:
                        exit = true;
                        break;
                }

            } while (!exit);
            Console.WriteLine("Bye!");
        }

        public static async System.Threading.Tasks.Task<List<RoomType>> EnterRoomsAsync(Hotel currentHotel, Controller cntrl)
        {
            bool exit = false;
            List<RoomType> rooms = new List<RoomType>();
            List<Price> prices = new List<Price>();
            do
            {
                Console.WriteLine("Enter Rooms");
                Console.WriteLine("=======================");
                Console.Write("Room size(in m^2): ");
                var roomSize = Convert.ToInt32(Console.ReadLine());
                Console.Write("Room title: ");
                var roomTitle = Console.ReadLine();
                Console.Write("Room description: ");
                var roomDescription = Console.ReadLine();


                Console.Write("Room price: ");
                var pricePerNight = Convert.ToInt32(Console.ReadLine());

                Console.Write("Room accessibility (true | false): ");
                var roomAccessibility = false;
                if (Console.ReadLine() == "true")
                {
                    roomAccessibility = true;
                }
                Console.Write("How many rooms are available: ");
                var roomsAvailable = Convert.ToInt32(Console.ReadLine());

                var currentRoom = new RoomType() { Hotel = currentHotel, Title = roomTitle, Description = roomDescription, Size = roomSize, Accessibility = roomAccessibility, AvailableRooms = roomsAvailable };
                var roomPrice = new Price() { Room = currentRoom, PricePerNight = pricePerNight };
                prices.Add(roomPrice);
                rooms.Add(currentRoom);
                Console.Write("Do you want to add another room?(Y/N): ");
                if (Console.ReadLine() == "N")
                {
                    exit = true;
                }
            } while (!exit);
            await cntrl.AddPrices(prices);
            return rooms;
        }

        public static Adress EnterAdress(string rawAdress)
        {
            var splitAdress = rawAdress.Split(", ");
            var street = splitAdress[0];
            var splitZipAndCity = splitAdress[1].Split(" ");
            var zipCode = Convert.ToInt32(splitZipAndCity[0]);
            var city = splitZipAndCity[1];

            return new Adress() { Street = street, ZipCode = zipCode, City = city };
        }
    }
}
