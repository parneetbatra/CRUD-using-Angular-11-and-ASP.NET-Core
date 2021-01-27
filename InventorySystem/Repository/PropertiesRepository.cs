using InventorySystem.Models;
using InventorySystem.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace InventorySystem.Repository
{
    public class PropertiesRepository : IPropertiesRepository
    {
        DatabaseContext db;
        public PropertiesRepository(DatabaseContext _db)
        {
            db = _db;
        }

        public Properties Add(Properties properties)
        {
            if (db != null)
            {
                db.Properties.Add(properties);
                db.SaveChanges();

                return properties;
            }

            return null;
        }

        public int Delete(int? id)
        {
            int result = 0;

            if (db != null)
            {
                //Find the computer for specific id
                var computer = db.Properties.FirstOrDefault(x => x.Id == id);

                if (computer != null)
                {
                    //Delete that computer
                    db.Properties.Remove(computer);

                    //Commit the transaction
                    result = db.SaveChanges();
                }
                return result;
            }

            return result;
        }

        public ComputerView GetById(int? id)
        {
            try
            {
                if (db != null)
                {
                    return (from p in db.Properties
                            from c in db.ComputerTypes
                            where p.ComputerTypeId == c.Id && p.Id == id
                            select new ComputerView
                            {
                                PropertyId = p.Id,
                                ComputerTypeId = c.Id,
                                ComputerTypeName = c.Name,
                                Processor = p.Processor,
                                Brand = p.Brand,
                                UsbPorts = p.UsbPorts,
                                RamSlots = p.RamSlots,
                                FromFactor = p.FromFactor,
                                Quantity = p.Quantity,
                                ScreenSize = p.ScreenSize
                            }).FirstOrDefault();
                }

                return null;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public List<ComputerView> GetAll()
        {
            if (db != null)
            {
                return (from p in db.Properties
                             from c in db.ComputerTypes
                             where p.ComputerTypeId == c.Id
                             select new ComputerView
                             {
                                 PropertyId = p.Id,
                                 ComputerTypeId = c.Id,
                                 ComputerTypeName = c.Name,
                                 Processor = p.Processor,
                                 Brand = p.Brand,
                                 UsbPorts = p.UsbPorts,
                                 RamSlots = p.RamSlots,
                                 FromFactor = p.FromFactor,
                                 Quantity = p.Quantity,
                                 ScreenSize = p.ScreenSize
                             }).ToList();
            }

            return null;
        }

        public Properties Update(Properties properties)
        {
            if (db != null)
            {
                //Delete that computer
                db.Properties.Update(properties);

                //Commit the transaction
                db.SaveChanges();

                return properties;
            }

            return null;
        }
    }
}
