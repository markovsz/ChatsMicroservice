using Messager.Chats.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Chats.Infrastructure.Data
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatMember> ChatMembers { get; set; }

        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Chat>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<Message>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Message>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Message>()
                .HasOne(m => m.MessageChat)
                .WithMany(c => c.ChatMessages)
                .HasForeignKey(m => m.ChatId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<ChatMember>()
                .Property(cm => cm.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<ChatMember>()
                .HasKey(cm => cm.Id);

            modelBuilder.Entity<ChatMember>()
                .HasOne(cm => cm.UserChat)
                .WithMany(c => c.ChatMembers)
                .HasForeignKey(cm => cm.ChatId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
