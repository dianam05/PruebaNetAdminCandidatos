using AdminCandidatos.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AdminCandidatos.Infrastructure.Persistence
{
    public class AdminCandidatosDBContext:DbContext
    {

        public DbSet<Candidates> Candidates { get; set; }
        public DbSet<CandidateExperience> CandidateExperience { get; set; }

        public AdminCandidatosDBContext(DbContextOptions<AdminCandidatosDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidates>()
                .HasMany(c => c.Experiences)
                .WithOne(e => e.Candidates)
                .HasForeignKey(e => e.IdCandidate)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
