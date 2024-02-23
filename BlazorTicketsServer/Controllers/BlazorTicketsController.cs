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
		public static List<TicketModel> Tickets { get; set; } = new()
		{
			new TicketModel
			{
				Id = 1,
				Title = "Test",
				Description = "TestDescription",
			},
			new TicketModel
			{
				Id = 2,
				Title = "Test2",
				Description = "TestDescription2",

			},
			new TicketModel
			{
				Id = 3,
				Title = "Test3",
				Description = "TestDescription3",
			},
		};

		[HttpGet]
		public ActionResult<List<TicketModel>> Get()
		{
			return Ok(Tickets);
		}

		[HttpPost]
		public ActionResult<List<TicketModel>> Post(TicketModel ticket)
		{
			if(ticket != null)
			{
				Tickets.Add(ticket);
				return Ok();
			}

			return BadRequest();
		}
	}


}
