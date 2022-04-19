using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using SMS.Data.Models;
using SMS.Data.Repository;
using SMS.Data.Security;

namespace SMS.Data.Services
{
    public class StudentServiceDb : IStudentService
    {
        private readonly DataContext db;

        public StudentServiceDb()
        {
            db = new DataContext();
        }

        public void Initialise()
        {
            db.Initialise(); // recreate database
        }

        // -------- Student Related Operations ------------

        // retrieve list of Students
        public IList<Student> GetStudents()
        {
            return db.Students.ToList();
        }


        // Retrive student by Id and related tickets
        public Student GetStudent(int id)
        {
            return db.Students
                     .Include(s => s.Tickets)
                     .Include(s => s.StudentModules)
                     // drill down and include each studentmodule module entity     
                     .ThenInclude(sm => sm.Module) 
                     .FirstOrDefault(s => s.Id == id);
        }

        // Add a new student checking email is unique
        public Student AddStudent(string name, string course, string email,
                                    int age, double grade, string photoUrl)
        {
            // check if student with email exists            
            var exists = GetStudentByEmail(email);
            if (exists != null)
            {
                return null;
            } 

            // create new student
            var s = new Student
            {
                Name = name,
                Course = course,
                Email = email,
                Age = age,
                Grade = grade,
                PhotoUrl = photoUrl
            };
            db.Students.Add(s); // add student to the list
            db.SaveChanges();
            return s; // return newly added student
        }

        // Delete the student identified by Id returning true if 
        // deleted and false if not found
        public bool DeleteStudent(int id)
        {
            var s = GetStudent(id);
            if (s == null)
            {
                return false;
            }
            db.Students.Remove(s);
            db.SaveChanges();
            return true;
        }

        // Update the student with the details in updated 
        public Student UpdateStudent(Student updated)
        {
            // verify the student exists
            var student = GetStudent(updated.Id);
            if (student == null)
            {
                return null;
            }
            // update the details of the student retrieved and save
            student.Name = updated.Name;
            student.Email = updated.Email;
            student.Course = updated.Course;
            student.Age = updated.Age;
            student.Grade = updated.Grade;
            student.PhotoUrl = updated.PhotoUrl;

            db.SaveChanges();
            return student;
        }

        public Student GetStudentByEmail(string email)
        {
            return db.Students.FirstOrDefault(s => s.Email == email);
        }
       
        public bool IsDuplicateStudentEmail(string email, int studentId) 
        {
            var existing = GetStudentByEmail(email);
            // if a student with email exists and the Id does not match
            // the studentId (if provided), then they cannot use the email
            return existing != null && studentId != existing.Id;           
        }


        // ===================== Ticket Management ==========================
        public Ticket CreateTicket(int studentId, string issue)
        {
            var student = GetStudent(studentId);
            if (student == null) return null;

            var ticket = new Ticket
            {
                // Id created by Database
                Issue = issue,        
                StudentId = studentId,
                // set by default in model but we can override here if required
                CreatedOn = DateTime.Now,
                Active = true,
            };
            db.Tickets.Add(ticket);
            db.SaveChanges(); // write to database
            return ticket;
        }

        public Ticket GetTicket(int id)
        {
            // return ticket and related student or null if not found
            return db.Tickets
                     .Include(t => t.Student)
                     .FirstOrDefault(t => t.Id == id);
        }

        public Ticket CloseTicket(int id, string resolution)
        {
            var ticket = GetTicket(id);
            // if ticket does not exist or is already closed return null
            if (ticket == null || !ticket.Active) return null;
            
            // ticket exists and is active so close
            ticket.Active = false;
            ticket.Resolution = resolution;
            ticket.ResolvedOn = DateTime.Now;
           
            db.SaveChanges(); // write to database
            return ticket;
        }

        public bool DeleteTicket(int id)
        {
            // find ticket
            var ticket = GetTicket(id);
            if (ticket == null) return false;
            
            // remove ticket 
            var result = db.Tickets.Remove(ticket);
            
            db.SaveChanges();
            return true;
        }

        // Retrieve all tickets and the student associated with the ticket
        public IList<Ticket> GetAllTickets()
        {
            return db.Tickets
                     .Include(t => t.Student)
                     .ToList();
        }

        // Retrieve all open tickets (Active)
        public IList<Ticket> GetOpenTickets()
        {
            // return open tickets with associated students
            return db.Tickets
                     .Include(t => t.Student) 
                     .Where(t => t.Active)
                     .ToList();
        } 

        // perform a search of the tickets based on a query and
        // an active range 'ALL', 'OPEN', 'CLOSED'
        public IList<Ticket> SearchTickets(TicketRange range, string query) 
        {
            // ensure query is not null    
            query = query == null ? "" : query.ToLower();

            // search ticket issue, active status and student name
            var results = db.Tickets
                            .Include(t => t.Student)
                            .Where(t => (t.Issue.ToLower().Contains(query) || 
                                         t.Student.Name.ToLower().Contains(query)
                                        ) &&
                                        (range == TicketRange.OPEN && t.Active ||
                                         range == TicketRange.CLOSED && !t.Active ||
                                         range == TicketRange.ALL
                                        ) 
                            ).ToList();
            return  results;  
        }

        // ========================= Module Management ========================
     
        public Module AddModule(string title)
        {
            var m = new Module { Title = title };
            db.Modules.Add(m);
            db.SaveChanges();

            return m;
        }

        public StudentModule AddStudentToModule(int studentId, int moduleId, int mark)
        {
            // check if this student module already exists and return null if found
            var sm = db.StudentModules
                       .FirstOrDefault(o => o.StudentId == studentId && 
                                            o.ModuleId == moduleId);
            if (sm != null)  {  return null;  }

            // locate the student and the module
            var s = db.Students.FirstOrDefault(s => s.Id == studentId);
            var m = db.Modules.FirstOrDefault(m => m.Id == moduleId);
            // if either don't exist then return null
            if (s == null || m == null) { return null;  }

            // create the student module and add to database
            var nsm = new StudentModule { StudentId = s.Id, ModuleId = m.Id, Mark = mark };
            db.StudentModules.Add(nsm);
            db.SaveChanges();
            return nsm;
        }

        public bool RemoveStudentFromModule(int studentId, int moduleId)
        {
            // check student is taking the module
            var sm = db.StudentModules.FirstOrDefault(
                m => m.StudentId == studentId && m.ModuleId == moduleId
            );
            if (sm == null) {  return false;  }
            
            // remove the student module
            db.StudentModules.Remove(sm);
            db.SaveChanges();
            return true;
        }

        // ==================== User Management ==================
        public User Authenticate(string email, string password)
        {
            // retrieve the user based on the EmailAddress (assumes EmailAddress is unique)
            var user = GetUserByEmail(email);

            // Verify the user exists and Hashed User password matches the password provided
            return (user != null && Hasher.ValidateHash(user.Password, password)) ? user : null;
        }

        public User Register(string name, string email, string password, Role role)
        {
            // check that the user does not already exist (unique user name)
            var exists = GetUserByEmail(email);
            if (exists != null)
            {
                return null;
            }

            // Custom Hasher used to encrypt the password before storing in database
            var user = new User 
            {
                Name = name,
                Email = email,
                Password = Hasher.CalculateHash(password),
                Role = role   
            };
   
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }

        public User GetUserByEmail(string email)
        {
            return db.Users.FirstOrDefault(u => u.Email == email);
        }


    }
}
