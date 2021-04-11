using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AP_Proto.Models
{
    public class AssetModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public AssetType assetType { get; set; }

        public string Note { get; set; }
    }

    public enum AssetType
    {
        PC = 1,
        Laptop = 2,
        Whiteboard = 3,
        Projector = 4,
        TV = 5,
        Monitor = 6,
        Keyboard = 7,
        Mouse = 8,
        Speakers = 9,
        MiscCable = 10
    }

}
