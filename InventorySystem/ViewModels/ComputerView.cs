using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.ViewModels
{
    public class ComputerView
    {
        public int PropertyId { get; set; }
        public int ComputerTypeId { get; set; }
        public string ComputerTypeName { get; set; }
        public string Processor { get; set; }
        public string Brand { get; set; }
        public int? UsbPorts { get; set; }
        public int? RamSlots { get; set; }
        public string FromFactor { get; set; }
        public int? Quantity { get; set; }
        public string ScreenSize { get; set; }
    }
}
