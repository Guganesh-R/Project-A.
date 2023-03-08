using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TMS1.Areas.Identity.Data;

namespace TMS1.Areas.Identity.Data;

public class DataTMS1Context : IdentityDbContext<TMS1User> 
{
    public DataTMS1Context(DbContextOptions<DataTMS1Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}

public class DataTMS1Context1 : TMS1Context
{
    public DataTMS1Context1(DbContextOptions<TMS1Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
{
    base.OnModelCreating(builder);
    // Customize the ASP.NET Identity model and override the defaults if needed.
    // For example, you can rename the ASP.NET Identity table names and more.
    // Add your customizations after calling base.OnModelCreating(builder);
}
}

