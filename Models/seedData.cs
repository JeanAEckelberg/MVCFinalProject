using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Data;
using MVCFinalProject.Models;

namespace MVCFinalProject.Models
{
    public class seedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVCFinalProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MVCFinalProjectContext>>()))
            {

                if (context.Computer.Any())
                {
                    return;   // DB has been seeded
                }

                context.Computer.AddRange(
                    new Computer
                    {
                        ManufactererSerialNumber = 45,
                        OfficeRoomNumber = "Room 420",
                        OfficeLocation = "South Location",
                        ComputerSpecification = "Standard",
                        OperatingSystem = "Linux",
                        OwnerName = "John Smith",
                        InstallationDate = DateTime.Parse("2022-2-12"),
                        Price = 1000M
                    },

                    new Computer
                    {
                        ManufactererSerialNumber = 46,
                        OfficeRoomNumber = "Room 420",
                        OfficeLocation = "South Location",
                        ComputerSpecification = "Standard",
                        OperatingSystem = "Linux",
                        OwnerName = "Stan Smith",
                        InstallationDate = DateTime.Parse("2022-2-12"),
                        Price = 1000M
                    },

                    new Computer
                    {
                        ManufactererSerialNumber = 47,
                        OfficeRoomNumber = "Room 421",
                        OfficeLocation = "South Location",
                        ComputerSpecification = "Engineer",
                        OperatingSystem = "Linux",
                        OwnerName = "Joe Biden",
                        InstallationDate = DateTime.Parse("2022-2-12"),
                        Price = 2000M
                    },

                    new Computer
                    {
                        ManufactererSerialNumber = 48,
                        OfficeRoomNumber = "Room 69",
                        OfficeLocation = "North Location",
                        ComputerSpecification = "Executive",
                        OperatingSystem = "Windows 11",
                        OwnerName = "Sean Hagen",
                        Price = 100000M
                    },

                    new Computer
                    {
                        ManufactererSerialNumber = 69420,
                        OfficeRoomNumber = "Room 200",
                        OfficeLocation = "North Location",
                        ComputerSpecification = "Subpar",
                        OperatingSystem = "Linux",
                        OwnerName = "John Rodger",
                        Price = 250M
                    },

                    new Computer
                    {
                        ManufactererSerialNumber = 69421,
                        OfficeRoomNumber = "Room 200",
                        OfficeLocation = "North Location",
                        ComputerSpecification = "Subpar",
                        OperatingSystem = "Linux",
                        OwnerName = "Jane Rodger",
                        Price = 2500M
                    },

                    new Computer
                    {
                        ManufactererSerialNumber = 4229,
                        OfficeRoomNumber = "Room 201",
                        OfficeLocation = "North Location",
                        ComputerSpecification = "Standard",
                        OperatingSystem = "Macintosh",
                        OwnerName = "Dave Johnson",
                        InstallationDate = DateTime.Parse("2022-3-12"),
                        Price = 1000M
                    },

                    new Computer
                    {
                        ManufactererSerialNumber = 45789,
                        OfficeRoomNumber = "Room 201",
                        OfficeLocation = "East Location",
                        ComputerSpecification = "Executive",
                        OperatingSystem = "Windows 11",
                        OwnerName = "Fmanda Aetzer",
                        InstallationDate = DateTime.Parse("2022-3-12"),
                        Price = 100M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
