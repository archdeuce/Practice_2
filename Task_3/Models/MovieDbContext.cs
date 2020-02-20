using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3.Models
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MovieDirection> MovieDirections { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Database = MovieDatabase; Trusted_Connection = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieDirection>(entity =>
            {
                entity.HasKey(md => new { md.DirectorId, md.MovieId });

                entity.HasOne(md => md.Director)
                      .WithMany(d => d.MovieDirections)
                      .HasForeignKey(md => md.DirectorId);

                entity.HasOne(md => md.Movie)
                      .WithMany(d => d.MovieDirections)
                     .HasForeignKey(md => md.MovieId);
            });

            modelBuilder.Entity<MovieGenre>(entity =>
            {
                entity.HasKey(mg => new { mg.GenreId, mg.MovieId });

                entity.HasOne(mg => mg.Genre)
                      .WithMany(d => d.MovieGenres)
                      .HasForeignKey(mg => mg.GenreId);

                entity.HasOne(mg => mg.Movie)
                      .WithMany(d => d.MovieGenres)
                      .HasForeignKey(mg => mg.MovieId);
            });

            modelBuilder.Entity<MovieCast>(entity =>
            {
                entity.Property(e => e.Role).HasMaxLength(20);

                entity.HasKey(mc => new { mc.ActorId, mc.MovieId });

                entity.HasOne(mc => mc.Actor)
                      .WithMany(d => d.MovieCasts)
                      .HasForeignKey(mc => mc.ActorId);

                entity.HasOne(mc => mc.Movie)
                      .WithMany(d => d.MovieCasts)
                      .HasForeignKey(mc => mc.MovieId);
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.Stars).HasDefaultValue(0);
                entity.Property(e => e.Position).HasDefaultValue(0);

                entity.HasKey(r => new { r.ReviewerId, r.MovieId });

                entity.HasOne(r => r.Reviewer)
                      .WithMany(r => r.Ratings)
                      .HasForeignKey(r => r.ReviewerId);

                entity.HasOne(r => r.Movie)
                      .WithMany(m => m.Ratings)
                      .HasForeignKey(r => r.MovieId);
            });

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).HasMaxLength(20);
                entity.Property(e => e.LastName).HasMaxLength(20);
                entity.Property(e => e.Gender).HasMaxLength(1);

                entity.HasMany(a => a.MovieCasts)
                      .WithOne(mc => mc.Actor)
                      .HasForeignKey(mc => mc.ActorId);
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).HasMaxLength(20);
                entity.Property(e => e.LastName).HasMaxLength(20);

                entity.HasMany(d => d.MovieDirections)
                      .WithOne(md => md.Director)
                      .HasForeignKey(md => md.DirectorId);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Title).HasMaxLength(50);
                entity.Property(e => e.Year).HasDefaultValue(0);
                entity.Property(e => e.Time).HasDefaultValue(0);
                entity.Property(e => e.Language).HasMaxLength(50);
                entity.Property(e => e.ReleaseDate);
                entity.Property(e => e.ReleaseCountry).HasMaxLength(5);

                entity.HasMany(m => m.MovieDirections)
                    .WithOne(md => md.Movie);

                entity.HasMany(a => a.MovieCasts)
                    .WithOne(mc => mc.Movie);

                entity.HasMany(m => m.MovieGenres)
                    .WithOne(mg => mg.Movie);
            });

            modelBuilder.Entity<Reviewer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(30);

                entity.HasMany(r => r.Ratings)
                      .WithOne(r => r.Reviewer)
                      .HasForeignKey(d => d.ReviewerId);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Title).HasMaxLength(20);

                entity.HasMany(g => g.MovieGenres)
                      .WithOne(mg => mg.Genre)
                      .HasForeignKey(mg => mg.GenreId);
            });
        }
    }
}
