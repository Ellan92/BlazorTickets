using System.ComponentModel.DataAnnotations;

namespace BlazorTicketsClient.ViewModels
{
	public class TicketViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Name is required!")]
		[MinLength(2, ErrorMessage = "Title must be at least 2 characters long!")]
		public string? Title { get; set; }
		[MinLength(6, ErrorMessage = "Description must be at least 6 characters long!")]
		public string Description { get; set; }
	}
}
