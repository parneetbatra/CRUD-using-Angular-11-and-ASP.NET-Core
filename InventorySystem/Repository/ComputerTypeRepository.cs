using InventorySystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace InventorySystem.Repository
{
    public class ComputerTypeRepository : IComputerTypeRepository
    {
        DatabaseContext db;
        public ComputerTypeRepository(DatabaseContext _db)
        {
            db = _db;
        }

        public ComputerType Add(ComputerType computerType)
        {
            try
            {
                if (db != null)
                {
                    db.ComputerTypes.AddAsync(computerType);
                    db.SaveChanges();

                    return computerType;
                }

                return null;
            }
            catch (System.Exception)
            {
                return null;
            }            
        }

        public int Delete(int? id)
        {
            int result = 0;

            try
            {
                if (db != null)
                {
                    //Find the computer type for specific id
                    var computerType = db.ComputerTypes.FirstOrDefault(x => x.Id == id);

                    if (computerType != null)
                    {
                        //Delete that computer type
                        db.ComputerTypes.Remove(computerType);

                        //Commit the transaction
                        result = db.SaveChanges();
                    }
                    return result;
                }
                return result;
            }
            catch (System.Exception)
            {
                return result;
            }
        }

        public ComputerType GetById(int? id)
        {
            try
            {
                if (db != null)
                {
                    return db.ComputerTypes.Where(x => x.Id == id).FirstOrDefault();
                }

                return null;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public List<ComputerType> GetAll()
        {
            try
            {
                if (db != null)
                {
                    return (from c in db.ComputerTypes
                            select new ComputerType
                            {
                                Id = c.Id,
                                Name = c.Name
                            }).ToList();
                }

                return null;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public ComputerType Update(ComputerType computerType)
        {
            try
            {
                if (db != null)
                {
                    //Delete that computer type
                    db.ComputerTypes.Update(computerType);

                    //Commit the transaction
                    db.SaveChanges();

                    return computerType;
                }

                return null;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
