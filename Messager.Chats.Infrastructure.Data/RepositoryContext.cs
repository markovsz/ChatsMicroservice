using Messager.Chats.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

            modelBuilder.Entity<Message>()
                .HasOne(m => m.MessageChat)
                .WithMany(c => c.ChatMessages)
                .HasForeignKey(m => m.ChatId)
                .OnDelete(DeleteBehavior.Cascade); /*!*/

            modelBuilder.Entity<ChatMember>()
                .HasOne(cm => cm.CustomerChat)
                .WithMany(c => c.ChatMembers)
                .HasForeignKey(cm => cm.ChatId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
