using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

using SMS.Data.Models;
using SMS.Data.Services;
using SMS.Web.Models;

namespace SMS.Web.Controllers
{
    [Authorize]
    public class TicketController : BaseController
    {
        private readonly IStudentService svc;

        // use constructor dependency injection to initialise service
        public TicketController(IStudentService ss)
        {
            svc = ss;
        } 

        // GET /ticket/index
        public IActionResult Index(TicketSearchViewModel m)
        {                  
            // set the viewmodel Tickets property by calling service method 
            // using the range and query values from the viewmodel 
            m.Tickets = svc.SearchTickets(m.Range, m.Query);

            return View(m);
        }       
               
        // GET/ticket/{id}
        public IActionResult Details(int id)
        {
            var ticket = svc.GetTicket(id);
            if (ticket == null)
            {
                Alert("Ticket Not Found", AlertType.warning);  
                return RedirectToAction(nameof(Index));             
            }

            return View(ticket);
        }

        // POST /ticket/close/{id}
        [HttpPost]
        [Authorize(Roles="admin,manager")]
        public IActionResult Close([Bind("Id, Resolution")] Ticket t)
        {
            // close ticket via service
            var ticket = svc.CloseTicket(t.Id, t.Resolution);
            if (ticket == null)
            {
                Alert("Ticket Not Found", AlertType.warning);                               
            }
            else
            {
                Alert($"Ticket {t.Id } closed", AlertType.info);  
            }

            // redirect to the index view
            return RedirectToAction(nameof(Index));
        }
       
        // GET /ticket/create
        [Authorize(Roles="admin,manager")]
        public IActionResult Create()
        {
            var students = svc.GetStudents();
            // populate viewmodel select list property
            var tvm = new TicketCreateViewModel {
                Students = new SelectList(students,"Id","Name") 
            };
            
            // render blank form
            return View( tvm );
        }
       
        // POST /ticket/create
        [HttpPost]
        [Authorize(Roles="admin,manager")]
        public IActionResult Create(TicketCreateViewModel tvm)
        {
            if (ModelState.IsValid)
            {
                svc.CreateTicket(tvm.StudentId, tvm.Issue);
     
                Alert($"Ticket Created", AlertType.info);  
                return RedirectToAction(nameof(Index));
            }
            
            // redisplay the form for editing
            return View(tvm);
        }

    }
}
