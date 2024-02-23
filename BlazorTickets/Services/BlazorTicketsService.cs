using Newtonsoft.Json;
using Shared.Models;
using System.Net.Http.Json;

namespace BlazorTicketsClient.Services
{
	public class BlazorTicketsService : IBlazorTicketsService
	{
		public HttpClient Client { get; set; } = new()
		{
			BaseAddress = new Uri("https://localhost:7170/api/")
		};

		public async Task<List<TicketModel>> GetTicketsAsync()
		{
			var response = await Client.GetAsync("blazortickets");

			if (response.IsSuccessStatusCode)
			{
				string ticketsJson = await response.Content.ReadAsStringAsync();

				List<TicketModel>? tickets = JsonConvert.DeserializeObject<List<TicketModel>>(ticketsJson);

				if(tickets != null)
				{
					return tickets;
				}
				throw new JsonException();
			}
			throw new HttpRequestException();
		}

		public async Task PostTicket(TicketModel ticket)
		{
			await Client.PostAsJsonAsync("BlazorTickets", ticket);
		}
	}
}
