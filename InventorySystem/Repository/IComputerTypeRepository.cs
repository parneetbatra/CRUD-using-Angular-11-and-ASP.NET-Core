using InventorySystem.Models;
using InventorySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Repository
{
    public interface IComputerTypeRepository
    {
        public List<ComputerType> GetAll();

        public ComputerType GetById(int? id);

        public ComputerType Add(ComputerType computerType);

        public int Delete(int? id);

        public ComputerType Update(ComputerType computerType);
    }
}
