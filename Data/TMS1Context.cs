using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TMS1.Models;

    public class TMS1Context : DbContext
    {
        public TMS1Context (DbContextOptions<TMS1Context> options)
            : base(options)
        {
        }

        public DbSet<TMS1.Models.VehicleInfo> VehicleInfo { get; set; } = default!;

        public DbSet<TMS1.Models.EmployeeInfo> EmployeeInfo { get; set; } = default!;

        public DbSet<TMS1.Models.RouteInfo> RouteInfo { get; set; } = default!;
        public DbSet<TMS1.Models.Allocate> Allocate { get; set; } = default!;
        public DbSet<TMS1.Models.Transport> Transport { get; set; }


}
