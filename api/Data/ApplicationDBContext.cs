using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Models.Activities;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Models.Activities.Activity> Activities { get; set; }
        public DbSet<JobInterview> JobInterviews { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingRoom> MeetingRooms { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Models.Activities.Activity>()
        //         .HasOne(a => a.MeetingRoom)
        //         .WithMany(mr => mr.Activities)
        //         .HasForeignKey(a => a.MeetingRoomId)
        //         .IsRequired(false) // This makes the foreign key optional
        //         .OnDelete(DeleteBehavior.Restrict); // Optional: Specify delete behavior

        //     base.OnModelCreating(modelBuilder);
        // }
    }
}