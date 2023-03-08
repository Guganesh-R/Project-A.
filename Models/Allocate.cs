using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TMS1.Models;

namespace TMS1.Models
{
    public class Allocate
    {
        [Key]
        [Display(Name = "Allocate ID")]
        public int AllocatId { get; set; }
        [ForeignKey("VehicleInfo")]
        [Display(Name = "Vehicle ID")]
        public string? VehicleId { get; set; }
        public VehicleInfo? VehicleInfo { get; set; }
        [ForeignKey("RouteInfo")]
        [Display(Name = "Route ID")]
        public int RouteId { get; set; }
        public RouteInfo? RouteInfo { get; set; }
        [ForeignKey("EmployeeInfo")]
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }
        public EmployeeInfo? EmployeeInfo { get; set; }
    }
}