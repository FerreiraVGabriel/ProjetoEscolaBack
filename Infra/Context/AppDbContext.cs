using Infra.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Escola> Escola { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Aluno> Aluno { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ESCOLA
            modelBuilder.Entity<Escola>(entity =>
            {
                entity.HasKey(e => e.ICodEscola);

                entity.Property(u => u.ICodEscola)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SDescricao)
                      .IsRequired()
                      .HasMaxLength(100); 

                entity.HasMany(e => e.Alunos)
                      .WithOne(a => a.Escola)
                      .HasForeignKey(a => a.ICodEscola);
            });

            //ALUNO
            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(a => a.ICodAluno);

                entity.Property(u => u.ICodAluno)
                      .ValueGeneratedOnAdd();

                entity.Property(a => a.SNome)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(a => a.DNascimento)
                      .IsRequired();

                entity.Property(a => a.SCPF)
                      .IsRequired()
                      .HasMaxLength(14); 

                entity.Property(a => a.SCelular)
                      .IsRequired()
                      .HasMaxLength(15);

                entity.Property(a => a.SEndereco)
                      .HasMaxLength(200);

                entity.HasOne(a => a.Escola)
                      .WithMany(e => e.Alunos)
                      .HasForeignKey(a => a.ICodEscola);
            });

            //USUARIO
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.ICodUsuario);

                entity.Property(u => u.ICodUsuario)
                      .ValueGeneratedOnAdd(); 

                entity.Property(u => u.SNome)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(u => u.SSenha)
                      .IsRequired()
                      .HasMaxLength(100);
            });



        }
    }
}
