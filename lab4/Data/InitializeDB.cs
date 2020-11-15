using lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Data
{
    public static class InitializeDB
    {
        private static Random random = new Random();

        private static string[] names =
        {
            "Никита", "Евгений", "Михаил", "Даниил", "Юрий", "Илья", "Алексей", "Сергей", "Виталий",
            "Денис", "Михаил", "Артем", "Иван", "Виктор", "Александр"
        };

        private static string[] surnames =
        {
            "Кириленко", "Панфилов", "Дубровский", "Долгов", "Яркин", "Черкасов", "Рябцев", "Жилин", "Фокин",
            "Мосин", "Агапов", "Якубовский", "Никулин", "Котов", "Прохоров"
        };

        private static string[] middleNames =
        {
            "Алексеевич", "Дмитриевич", "Владимирович", "Евгеньевич", "Артёмович", "Павловнич", "Николаевнич",
            "Антонович", "Викторович", "Кириллович", "Андреевич", "Геннадьевич", "Даниилович", "Олегович", "Егорович"
        };

        private static string[] lists =
        {
            "Уборка", "Замена белья", "Стирка вещей", "Доставка", "Обед", "Ужин", "Завтрак", "Пользование стоянкой", "Услуги тренажерного зала"
        };

        private static string[] types =
        {
            "Одноместный", "Двухместный", "Трехместный", "Четырехместный", "Люкс", "Президентский Люкс"
        };

        private static char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static string GetRandomEl(string[] arr)
        {
            return arr[random.Next(0, arr.Length)];
        }
        private static DateTime NextDateTime()
        {
            DateTime start = new DateTime(2015, 1, 1);
            int range = (DateTime.Today - start).Days;

            return start.AddDays(random.Next(range));
        }

        private static string GetString(int minStringLength, int maxStringLength)
        {
            string result = "";

            int stringLimit = minStringLength + random.Next(maxStringLength - minStringLength);

            int stringPosition;
            for (int i = 0; i < stringLimit; i++)
            {
                stringPosition = random.Next(letters.Length);

                result += letters[stringPosition];
            }

            return result;
        }
        public static void Initialize(HotelContext db)
        {
            db.Database.EnsureCreated();
            int rowCount;
            int rowIndex;

            if (!db.Clients.Any())
            {
                rowCount = 2000;
                rowIndex = 0;

                while (rowIndex < rowCount)
                {
                    Client client = new Client
                    {
                        Name = GetRandomEl(names),
                        Middlename = GetRandomEl(middleNames),
                        Surname = GetRandomEl(surnames),
                        PassportData = GetString(8, 8),
                        NameOfRoom = GetString(10, 16),
                        List = GetRandomEl(lists),
                        TotalCost = (decimal)random.Next(90, 4000)
                    };
                    db.Clients.Add(client);
                    rowIndex++;
                }

                db.SaveChanges();
            }

            if (!db.Rooms.Any())
            {
                rowCount = 2000;
                rowIndex = 0;

                while (rowIndex < rowCount)
                {
                    Room room = new Room
                    {
                        Type = GetRandomEl(types),
                        Capacity = random.Next(1, 4),
                        Specification = GetString(8, 16)
                    };
                    db.Rooms.Add(room);
                    rowIndex++;
                }

                db.SaveChanges();
            }

            if (!db.Orders.Any())
            {
                rowIndex = 0;
                rowCount = 2000;

                int minClientId = db.Clients.Min(x => x.Id);
                int maxClientId = db.Clients.Max(x => x.Id);

                int minEmployeeId = db.Employees.Min(x => x.Id);
                int maxEmployeeId = db.Employees.Max(x => x.Id);

                int minRoomId = db.Rooms.Min(x => x.Id);
                int maxRoomId = db.Rooms.Max(x => x.Id);

                while (rowIndex < rowCount)
                {
                    Order order = new Order
                    {
                        CheckInDate = NextDateTime(),
                        CheckOut = NextDateTime(),
                        EmployeeId = random.Next(minEmployeeId, maxEmployeeId + 1),
                        ClientId = random.Next(minClientId, maxClientId + 1),
                        RoomId = random.Next(minRoomId, maxRoomId + 1)
                    };
                    db.Orders.Add(order);
                    rowIndex++;
                }

                db.SaveChanges();

            }
        }
    }
}
