// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.AspNetCore.Authorization;

// using SMS.Data.Models;
// using SMS.Data.Services;
// using SMS.Web.Models;

// namespace SMS.Web.Controllers
// {
//     [ApiController]  
//     [Route("api/ticket")]
//     public class TicketApiController : BaseController
//     {
//         private readonly IStudentService svc;

//         public TicketApiController(IStudentService ss)
//         {
//             svc = ss; // initialise via dependency injection
//         } 

//         // GET /api/ticket
//         [HttpGet]
//         public IActionResult GetAll()
//         {
//             // get open tickets via service
//             var tickets = svc.GetAllTickets();

//             // convert each ticket into a custom Dto to be sent in response using a local private method
//             var response = tickets.Select(t => ConvertToCustomTicketObject(t)).ToList(); 
            
//             // OR optionally use an extension method defined in Models/Mapper.cs to do conversion
//             //var response = tickets.Select(t => t.ToDto() ).ToList(); 

//             return Ok(response); 
//         }

//         [HttpGet("open")]
//         public IActionResult GetOpen()
//         {
//              var response = svc.GetOpenTickets()
//                                .Select(t => ConvertToCustomTicketObject(t)
//                             ).ToList(); 
//             return Ok( response ); 
//         }

     
//         [HttpGet("search")]
//         public IActionResult Search(string query = "", TicketRange range = TicketRange.ALL)
//         {                             
//             var tickets = svc.SearchTickets(range, query);
//             var results = tickets.Select( t => ConvertToCustomTicketObject(t) ).ToList();
            
//             // return custom results list
//             return Ok(results);
//         }        
             
//         // GET /api/ticket/{id}
//         [HttpGet("{id}")]
//         public IActionResult GetOne(int id)
//         {
//             var ticket = svc.GetTicket(id);
//             if (ticket == null)
//             {
//                 return NotFound();             
//             }
//             // return custom ticket object
//             return Ok(ConvertToCustomTicketObject(ticket));
//         }

        
//         // PATCH /api/ticket/{id}
//         [HttpPatch("{id}")]       
//         public IActionResult Close([Bind("Id, Resolution")] Ticket t)
//         {
//             // close ticket via service
//             var ticket = svc.CloseTicket(t.Id, t.Resolution);           

//             // return updated ticket
//             return Ok(ticket);
//         }
       
//         // POST /api/ticket
//         [HttpPost]
//         public IActionResult Create(TicketCreateViewModel tvm)
//         {
//             if (ModelState.IsValid)
//             {
//                 var ticket = svc.CreateTicket(tvm.StudentId, tvm.Issue);
//                 return Ok(ticket);
//             }
            
//             // 
//             return NotFound();
//         }


//         // private method to convert a ticket into a custom object for json response
//         private object ConvertToCustomTicketObject(Ticket t)
//         {
//             return new {   
//                 Id = t.Id,
//                 Issue = t.Issue, 
//                 CreatedOn = t.CreatedOn.ToShortDateString(),
//                 Active = t.Active,
//                 Resolution = t.Resolution,
//                 Student = t.Student?.Name,
//                 Email = t.Student?.Email
//             };
//         }

//     }
// }
