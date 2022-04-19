
using SMS.Data.Models;

namespace SMS.Web.Models
{   
    public class TicketSearchViewModel
    {
        // result set
        public IList<Ticket> Tickets { get; set;} = new List<Ticket>();

        // search options        
        public string Query { get; set; } = "";
        public TicketRange Range { get; set; } = TicketRange.OPEN;
    }
}
