using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
    public class Properties
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ComputerType")]
        public int ComputerTypeId { get; set; }
        public ComputerType ComputerType { get; set; }

        [Required]
        public string Processor { get; set; }

        [Required]
        public string Brand { get; set; }
        public int? UsbPorts { get; set; }
        public int? RamSlots { get; set; }
        public string FromFactor { get; set; }
        public int? Quantity { get; set; }
        public string ScreenSize { get; set; }
    }
}
