using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMS1.Models
{
    [Keyless]
    public class Transport
    {
        
        public int EmployeeId { get; set; }
        public string ? EmployeeName { get; set; }
        public string ? EmployeeAdress { get; set; }
        public int EmployeeAge { get; set; }
        public int VehicleId { get; set; }
        public int RouteId { get; set; }
        public string ? stop1 { get; set; }
        public string ? stop2 { get; set; }
    }
}
