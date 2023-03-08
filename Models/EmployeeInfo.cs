using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TMS1.Models;

namespace TMS1.Models
{
    public class EmployeeInfo
    {
        [Key]
        [Display(Name = "Employee ID")]
        public int EmployeeID { get; set; }
        [Display(Name = "Employee Name")]
        public string? EmployeeName { get; set; }
        [Display(Name = "Employee Address")]
        public string? EmployeeAdress { get; set; }
        [Display(Name = "Employee Age")]
        public int EmployeeAge { get; set; }
        [ForeignKey("VehicleInfo")]
        [Display(Name = "Vehicle ID")]
        public string VehicleId { get; set; }
        public VehicleInfo? VehicleInfo { get; set; }
        [ForeignKey("RouteInfo")]
        public int RouteId { get; set; }
        public RouteInfo? RouteInfo { get; set; }

    }
}