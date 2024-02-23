using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace BlazorTicketsAPI.Database
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<TicketModel> Tickets { get; set; }
		public DbSet<TagModel> Tags { get; set; }
		public DbSet<ResponseModel> Responses { get; set; }
		public DbSet<TicketTag> TicketTags { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<TicketTag>()
			.HasKey(tt => new { tt.TicketId, tt.TagId }); // Sätter en sammansatt p
														  // Konfigurera många-till-många relationen mellan TicketModel och TagMo
			modelBuilder.Entity<TicketTag>()
			.HasOne(tt => tt.Ticket)
			.WithMany(t => t.TicketTags)
			.HasForeignKey(tt => tt.TicketId);
			modelBuilder.Entity<TicketTag>()
			.HasOne(tt => tt.Tag)
			.WithMany(t => t.TicketTags)
			.HasForeignKey(tt => tt.TagId);
			// Konfigurera en-till-många-relationen mellan TicketModel och ResponseMode
			modelBuilder.Entity<ResponseModel>()
			.HasOne(r => r.Ticket)
			.WithMany(t => t.Responses)
			.HasForeignKey(r => r.TicketId);

			modelBuilder.Entity<TagModel>().HasData(
			   new TagModel { Id = 1, Name = "CSharp" },
			   new TagModel { Id = 2, Name = "DotNet" },
			   new TagModel { Id = 3, Name = "Blazor" },
			   new TagModel { Id = 4, Name = "Java" },
			   new TagModel { Id = 5, Name = "JavaScript" },
			   new TagModel { Id = 6, Name = "Python" },
			   new TagModel { Id = 7, Name = "HTML" },
			   new TagModel { Id = 8, Name = "CSS" },
			   new TagModel { Id = 9, Name = "SQL" },
			   new TagModel { Id = 10, Name = "NoSQL" },
			   new TagModel { Id = 11, Name = "Git" },
			   new TagModel { Id = 12, Name = "Docker" },
			   new TagModel { Id = 13, Name = "Kubernetes" },
			   new TagModel { Id = 14, Name = "MachineLearning" },
			   new TagModel { Id = 15, Name = "ArtificialIntelligence" },
			   new TagModel { Id = 16, Name = "DataScience" },
			   new TagModel { Id = 17, Name = "WebDevelopment" },
			   new TagModel { Id = 18, Name = "MobileDevelopment" },
			   new TagModel { Id = 19, Name = "GameDevelopment" },
			   new TagModel { Id = 20, Name = "CloudComputing" },
			   new TagModel { Id = 21, Name = "AWS" },
			   new TagModel { Id = 22, Name = "BlazorTickets4Azure" },
			   new TagModel { Id = 23, Name = "GCP" },
			   new TagModel { Id = 24, Name = "DevOps" },
			   new TagModel { Id = 25, Name = "CI_CD" },
			   new TagModel { Id = 26, Name = "Agile" },
			   new TagModel { Id = 27, Name = "Scrum" },
			   new TagModel { Id = 28, Name = "Security" },
			   new TagModel { Id = 29, Name = "Blockchain" },
			   new TagModel { Id = 30, Name = "IoT" },
			   new TagModel { Id = 31, Name = "AR_VR" },
			   new TagModel { Id = 32, Name = "UI_UX" },
			   new TagModel { Id = 33, Name = "Algorithms" },
			   new TagModel { Id = 34, Name = "DataStructures" },
			   new TagModel { Id = 35, Name = "DesignPatterns" },
			   new TagModel { Id = 36, Name = "FunctionalProgramming" },
			   new TagModel { Id = 37, Name = "ObjectOrientedProgramming" });


			modelBuilder.Entity<TicketModel>().HasData(
			new TicketModel
			{
				Id = 1,
				Title = "Ticket 1",
				Description = "Description for Ticket 1",
				SubmittedBy = "User1",
				IsResolved = false
			},
			new TicketModel
			{
				Id = 2,
				Title = "Ticket 2",
				Description = "Description for Ticket 2",
				SubmittedBy = "User2",
				IsResolved = false
			},
			new TicketModel
			{
				Id = 3,
				Title = "Ticket 3",
				Description = "Description for Ticket 3",
				SubmittedBy = "User3",
				IsResolved = false
			}
		);

			// Seed responses
			modelBuilder.Entity<ResponseModel>().HasData(
				new ResponseModel { Id = 1, Response = "Response for Ticket 1", SubmittedBy = "User1", TicketId = 1 },
				new ResponseModel { Id = 2, Response = "Response for Ticket 2", SubmittedBy = "User2", TicketId = 2 },
				new ResponseModel { Id = 3, Response = "Response for Ticket 3", SubmittedBy = "User3", TicketId = 3 }
			);

			modelBuilder.Entity<TicketTag>().HasData(new TicketTag { TicketId = 1, TagId = 1 }
			);
		}
	}
}