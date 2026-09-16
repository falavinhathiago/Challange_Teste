using Domain.Challenge.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Challenge.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // DbSet para a entidade
        public DbSet<SolicitacaoModels> Solicitacoes { get; set; }
       
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da chave primária
            modelBuilder.Entity<SolicitacaoModels>()
                .HasKey(s => s.Id);

            // Índice composto em Status e Prioridade
            modelBuilder.Entity<SolicitacaoModels>()
                .HasIndex(s => new { s.Status, s.Prioridade });

            base.OnModelCreating(modelBuilder);
        }
    }
}
