using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SUP_INV1._0.Models;

namespace SUP_INV1._0.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SUP_INV1._0.Models.FarmProducts> FarmProducts { get; set; } = default!;
        public DbSet<SUP_INV1._0.Models.PackedFoods> PackedFoods { get; set; } = default!;
        public DbSet<SUP_INV1._0.Models.Pharmaceuticals> Pharmaceuticals { get; set; } = default!;
        public DbSet<SUP_INV1._0.Models.Tools> Tools { get; set; } = default!;
        public DbSet<SUP_INV1._0.Models.Others> Others { get; set; } = default!;
        public DbSet<SUP_INV1._0.Models.FARMPRODUCTSSALESRECORD> FARMPRODUCTSSALESRECORD { get; set; } = default!;
        public DbSet<SUP_INV1._0.Models.PACKEDFOODSSALESRECORD> PACKEDFOODSSALESRECORD { get; set; } = default!;
        public DbSet<SUP_INV1._0.Models.PHARMACEUTICALSSALESRECORD> PHARMACEUTICALSSALESRECORD { get; set; } = default!;
        public DbSet<SUP_INV1._0.Models.TOOLSSALESRECORD> TOOLSSALESRECORD { get; set; } = default!;
        public DbSet<SUP_INV1._0.Models.OTHERSSALESRECORD> OTHERSSALESRECORD { get; set; } = default!;
        public DbSet<SUP_INV1._0.Models.FARMPRODUCTSPREPAREDRECORD> FARMPRODUCTSPREPAREDRECORD { get; set; } = default!;
        public DbSet<SUP_INV1._0.Models.OTHERSPREPAREDRECORD> OTHERSPREPAREDRECORD { get; set; } = default!;
        public DbSet<SUP_INV1._0.Models.PACKEDFOODPREPAREDRECORD> PACKEDFOODPREPAREDRECORD { get; set; } = default!;
        public DbSet<SUP_INV1._0.Models.PHARMACEUTICALSPREPAREDRECORD> PHARMACEUTICALSPREPAREDRECORD { get; set; } = default!;
        public DbSet<SUP_INV1._0.Models.TOOLSPREPAREDRECORD> TOOLSPREPAREDRECORD { get; set; } = default!;
        public DbSet<SUP_INV1._0.Models.PREPAREDRECORD> PREPAREDRECORD { get; set; } = default!;
    }
}
