using System.Collections;
using System.ComponentModel.DataAnnotations;
using TMS1.Models;

namespace TMS1.Models
{
    public class VehicleInfo
    {
        [Key]
        [Display(Name = "Vehicle ID")]
        public string VehicleId { get; set; }
        [Display(Name = "Seat Capacity")]
        public int VehicleCapacity { get; set; }
        [Display(Name = "Seat Availablity")]
        public int SeatAvailablity { get; set; } 
        

    }
}
