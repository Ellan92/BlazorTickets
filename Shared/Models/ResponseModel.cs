using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
	public class ResponseModel
	{
		public int Id { get; set; }
		public string Response { get; set; }
		public string SubmittedBy { get; set; }
		public int TicketId { get; set; }
		public TicketModel Ticket { get; set; }
	}
}
