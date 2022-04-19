using System;
using System.Collections.Generic;
	
using SMS.Data.Models;
	
namespace SMS.Data.Services
{
    // This interface describes the operations that a StudentService class should implement
    public interface IStudentService
    {
        // Initialise the repository (database)  
        void Initialise();
     
        // ---------------- Student Management --------------
        IList<Student> GetStudents();       
        Student GetStudent(int id);
        Student GetStudentByEmail(string email);
        Student AddStudent(string name, string course, string email, int age, double grade, string photoUrl);
        Student UpdateStudent(Student updated);  
        bool    DeleteStudent(int id);

        bool IsDuplicateStudentEmail(string email, int studentId);
        
        // ---------------- Ticket Management ---------------
        Ticket CreateTicket(int studentId, string issue);
        Ticket GetTicket(int id);
        Ticket CloseTicket(int id, string resolution);
        bool   DeleteTicket(int id);
        IList<Ticket> GetAllTickets();
        IList<Ticket> GetOpenTickets();        
        IList<Ticket> SearchTickets(TicketRange range, string query);
    
        // -------------- Module Management -----------------
        Module AddModule(string name);
        StudentModule AddStudentToModule(int studentId, int moduleId, int mark);
        bool RemoveStudentFromModule(int studentId, int moduleId);


        // ------------- User Management -------------------
        User Authenticate(string email, string password);
        User Register(string name, string email, string password, Role role);
        User GetUserByEmail(string email);
    
    }
    
}