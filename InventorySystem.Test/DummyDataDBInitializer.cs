using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem.Test
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {
        }

        public void Seed(DatabaseContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.ComputerTypes.AddRange(
                new Models.ComputerType() { Name = "Desktop Pc" },
                new Models.ComputerType() { Name = "Laptop" }
            );

            context.Properties.AddRange(
                new Properties()
                {
                    ComputerTypeId = 1,
                    Processor = "Intel i3",
                    Brand = "Dell",
                    UsbPorts = 2,
                    RamSlots = 2,
                    FromFactor = "Tower",
                    Quantity = 2,
                    ScreenSize = ""
                },
                new Properties()
                {
                    ComputerTypeId = 2,
                    Processor = "Intel i5",
                    Brand = "HP",
                    UsbPorts = 1,
                    RamSlots = 2,
                    FromFactor = "Tower",
                    Quantity = 5,
                    ScreenSize = "15-inch"
                }
            );
            context.SaveChanges();
        }
    }
}
