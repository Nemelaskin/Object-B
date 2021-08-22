using System;
using System.Collections.Generic;
using System.Linq;
using Object_B.Models.Context;

namespace Object_B.Models
{
    public static class SampleData
    {
        public static void Initialize(AllDataContext context)
        {
            if (!context.Roles.Any() && !context.Companies.Any() && !context.Rooms.Any())
            {
                var role1 = new Role { NameRole = "user" };
                var role2 = new Role { NameRole = "admin" };

                var position1 = new Position { NamePosition = "worker", Salary = 11.11m };
                var position2 = new Position { NamePosition = "manager", Salary = 21.11m };
                var position3 = new Position { NamePosition = "owner", Salary = 31.11m };

                var user1 = new User { FirstName = "big", SecondName = "boss", Email = "@dd", Password = "12345", Phone = "12345", Position = position3, Role = role2 };
                var user2 = new User { FirstName = "simple", SecondName = "admn", Email = "@as", Password = "qwerty", Phone = "54321", Position = position2, Role = role2 };
                var user3 = new User { FirstName = "standart", SecondName = "work", Email = "@hhhh", Password = "w1", Phone = "777", Position = position1, Role = role1 };

                var room1 = new Room { NameRoom = "testRoom", CoordinatesRoom = "22 22 11", IsACoridor = false };
                var room2 = new Room { NameRoom = "testRoom2", CoordinatesRoom = "33 662 1" ,IsACoridor = false };
                var room3 = new Room { NameRoom = "testRoom3", CoordinatesRoom = "88 13 22" ,IsACoridor = false };
                var room4 = new Room { NameRoom = "Coridor", CoordinatesRoom = "88 13 22" ,IsACoridor = true };

                var company1 = new Company { MapLink = "", Room = new List<Room> { room1 }, Owner = "Empty", NameCompany = "TestCompany1" };
               
                room1.Company = company1;
                room2.Company = company1;
                room3.Company = company1;
                room4.Company = company1;

                var sensor1 = new Sensor { User = user1, X = 222.2, Y = 454.33,  NameSensor = "testsen3" };
                var sensor2 = new Sensor { User = user2, X = 122.2, Y = 554.33, NameSensor = "testsen2" };
                var sensor3 = new Sensor { User = user3, X = 222.2, Y = 504.33, NameSensor = "testsen1"};

                var visit1 = new Visit { VisitTime = DateTime.Now, Room = room1, User = user1 };
                var visit2 = new Visit { VisitTime = DateTime.Now, Room = room2, User = user1 };
                var visit3 = new Visit { VisitTime = DateTime.Now, Room = room1, User = user3 };
                context.Users.AddRange(user1, user2, user3);
                context.Roles.AddRange(role1, role2);
                context.Rooms.AddRange(room1, room2, room3, room4);
                context.Companies.AddRange(company1);
                context.Visits.AddRange(visit1, visit2, visit3);
                context.Positions.AddRange(position1, position2, position3);
                context.Sensors.AddRange(sensor1, sensor2, sensor3);

                context.SaveChanges();
            }
        }
    }
}
