using ChitChatAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChitChatAPI.Persistence.Contexts
{
    public class ChitChatDbContext : DbContext
    {
        public ChitChatDbContext(DbContextOptions<ChitChatDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; } 
        public DbSet<Domain.Entities.Group> Groups { get; set; }
        public DbSet<GroupMessage> GroupMessages { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User Relationships
            modelBuilder.Entity<User>()
                .HasMany(u => u.SentMessages)
                .WithOne(m => m.Sender)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Cascade); // Kullanıcı silinirse gönderdiği mesajlar silinir

            modelBuilder.Entity<User>()
                .HasMany(u => u.GroupUsers)
                .WithOne(gu => gu.User)
                .HasForeignKey(gu => gu.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Kullanıcı silinirse grup üyelikleri silinir

            modelBuilder.Entity<User>()
                .HasMany(u => u.CreatedGroups)
                .WithOne(g => g.CreatedBy)
                .HasForeignKey(g => g.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.RefreshTokens)
                .WithOne(rt => rt.User)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Kullanıcı silinirse token'ları silinir

            modelBuilder.Entity<User>()
                .HasMany(u => u.ReceivedMessages)
                .WithMany(m => m.ReadedUsers)
                .UsingEntity(j => j.ToTable("MessageReads")); // Mesaj okuma ilişkisi (M:N)

            // Group Relationships
            modelBuilder.Entity<Domain.Entities.Group>()
                .HasMany(g => g.GroupUsers)
                .WithOne(gu => gu.Group)
                .HasForeignKey(gu => gu.GroupId)
                .OnDelete(DeleteBehavior.Cascade); // Grup silinirse üyelikler silinir

            modelBuilder.Entity<Domain.Entities.Group>()
                .HasMany(g => g.GroupMessages)
                .WithOne(m => m.Group)
                .HasForeignKey(m => m.GroupId)
                .OnDelete(DeleteBehavior.Cascade); // Grup silinirse mesajlar silinir

            // GroupMessage Relationships
            modelBuilder.Entity<GroupMessage>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict); // Mesajı gönderen kullanıcı silindiğinde mesaj kalır

            modelBuilder.Entity<GroupMessage>()
                .HasOne(m => m.Group)
                .WithMany(g => g.GroupMessages)
                .HasForeignKey(m => m.GroupId)
                .OnDelete(DeleteBehavior.Cascade); // Grup silinirse mesajlar silinir

            // GroupUser Relationships
            modelBuilder.Entity<GroupUser>()
                .HasKey(gu => new { gu.GroupId, gu.UserId });

            modelBuilder.Entity<GroupUser>()
                .HasOne(gu => gu.Group)
                .WithMany(g => g.GroupUsers)
                .HasForeignKey(gu => gu.GroupId)
                .OnDelete(DeleteBehavior.Cascade); // Grup silinirse üyelikler silinir

            modelBuilder.Entity<GroupUser>()
                .HasOne(gu => gu.User)
                .WithMany(u => u.GroupUsers)
                .HasForeignKey(gu => gu.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Kullanıcı silinirse grup üyelikleri silinir

            // Notification Relationships
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Kullanıcı silinirse bildirimi silinir

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.GroupMessage)
                .WithMany()
                .HasForeignKey(n => n.GroupMessageId)
                .OnDelete(DeleteBehavior.SetNull); // Grup mesajı silinirse bildirim null olur

            // RefreshToken Relationships
            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Kullanıcı silinirse token'ları silinir
        }


    }
}
