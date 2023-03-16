using FluxoDeCaixa.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Infrastructure.PostgreSQL
{
    public class FluxoDeCaixaDbContext : DbContext
    {
        public FluxoDeCaixaDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Lancamento> Lancamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lancamento>(
                e =>
                {
                    e.ToTable("lancamentos");
                    e.HasKey("_id");
                    e.Property(x => x._data).HasConversion
                        (
                            src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
                            dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
                        );
                    e.Property("_valor");
                    e.Property("_tipo");
                });
        }
    }
}
