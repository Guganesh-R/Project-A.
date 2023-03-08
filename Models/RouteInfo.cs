using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TMS1.Models;

namespace TMS1.Models
{
    public class RouteInfo
    {
        [Key]
        [Display(Name = "Route ID")]
        public int RouteId { get; set; }

        [Display(Name = "Starting Point")]
        public string? stop1 { get; set; }
        [Display(Name = "Drop Point")]
        public string? stop2 { get; set; }

    }
}