using BlazorTicketsApi.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace BlazorTicketsApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlazorTicketsController : ControllerBase
	{
		private readonly BlazorTicketsRepository _repository;

        public BlazorTicketsController(BlazorTicketsRepository repository)
        {
			_repository = repository;
        }
  //      public static List<TicketModel> Tickets { get; set; } = new()
		//{
		//	new TicketModel
		//	{
		//		Id = 1,
		//		Title = "Test",
		//		Description = "TestDescription",
		//	},
		//	new TicketModel
		//	{
		//		Id = 2,
		//		Title = "Test2",
		//		Description = "TestDescription2",

		//	},
		//	new TicketModel
		//	{
		//		Id = 3,
		//		Title = "Test3",
		//		Description = "TestDescription3",
		//	},
		//};

		[HttpGet]
		public async Task<ActionResult<List<TicketModel>>> Get()
		{
			
			var tickets = await _repository.GetAllTicketsAsync();
			return Ok(tickets);
			
		}

		[HttpPost]
		public async Task<TicketModel> Post(TicketModel ticket)
		{
			if(ticket != null)
			{
				await _repository.AddTicketAsync(ticket);
				
			}
			return null;
		}
	}


}
