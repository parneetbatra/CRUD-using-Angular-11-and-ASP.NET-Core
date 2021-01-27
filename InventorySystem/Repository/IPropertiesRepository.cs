using InventorySystem.Models;
using InventorySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Repository
{
    public interface IPropertiesRepository
    {
        public List<ComputerView> GetAll();

        public ComputerView GetById(int? id);

        public Properties Add(Properties properties);

        public int Delete(int? id);

        public Properties Update(Properties properties);
    }
}
