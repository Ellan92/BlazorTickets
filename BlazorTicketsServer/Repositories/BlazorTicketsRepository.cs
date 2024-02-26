using BlazorTicketsAPI.Database;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace BlazorTicketsApi.Repositories
{
	public class BlazorTicketsRepository
	{
        private readonly AppDbContext _context;
        public BlazorTicketsRepository(AppDbContext context)
        {
            _context = context;
        }

        // Tickets

        public async Task<TicketModel?> GetTicketByIdAsync(int ticketId)
        {
            return await _context.Tickets.FirstOrDefaultAsync(p => p.Id == ticketId);
        }



        public async Task<List<TicketModel>> GetAllTicketsAsync()
        {
            //return await _context.Tickets.ToListAsync();
            return await _context.Tickets.Include(t => t.TicketTags).ThenInclude(tt => tt.Tag).Include(t => t.Responses).ToListAsync();
        }

        public async Task AddTicketAsync(TicketModel ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveTicketAsync(int id)
        {
            TicketModel? ticketToDelete = await GetTicketByIdAsync(id);

            if(ticketToDelete != null)
            {
                _context.Tickets.Remove(ticketToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateTicket(TicketModel ticket)
        {
            TicketModel? ticketToUpdate = await GetTicketByIdAsync(ticket.Id);

            if(ticketToUpdate != null)
            {
                ticketToUpdate.Description = ticket.Description;
                await _context.SaveChangesAsync();
            }
        }

        // Responses

        public async Task<List<ResponseModel>> GetAllResponsesAsync()
        {
            return await _context.Responses.ToListAsync();
        }

        public async Task<List<ResponseModel>> GetResponsesForTicketAsync(int ticketId)
        {
            return await _context.Responses.Where(r => r.TicketId == ticketId).ToListAsync();

            
        }

        public async Task AddResponseAsync(ResponseModel response)
        {
            _context.Responses.Add(response);
            await _context.SaveChangesAsync();
        }
    }
}
