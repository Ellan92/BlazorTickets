using Shared.Models;

namespace BlazorTicketsClient.Services
{
	public interface IBlazorTicketsService
	{
		public HttpClient Client { get; set; }
		public Task<List<TicketModel>> GetTicketsAsync();
		public Task PostTicket(TicketModel ticket);
	}
}
