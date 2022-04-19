using SMS.Data.Models;

namespace SMS.Web.Models
{
    public static class Mapper    
    {
        public static object ToDto(this Ticket t)
        {
             return new {   
                Id = t.Id,
                Issue = t.Issue, 
                CreatedOn = t.CreatedOn,
                Active = t.Active,
                Resolution = t.Resolution,
                Student = t.Student?.Name
            };
        }
    }
}

