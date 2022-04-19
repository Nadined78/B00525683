
using Xunit;
using SMS.Data.Models;
using SMS.Data.Services;

namespace SMS.Test
{

    public class ServiceTests
    {
        private readonly IStudentService svc;

        public ServiceTests()
        {
            // general arrangement
            svc = new StudentServiceDb();

            // ensure data source is empty before each test
            svc.Initialise();
        }

        // ========================== Student Tests =========================
        [Fact] 
        public void Student_AddStudent_WhenDuplicateEmail_ShouldReturnNull()
        {
            // act 
            var s1 = svc.AddStudent("XXX", "xxx@email.com", "Computing", 20, 0, "");
            // this is a duplicate as the email address is same as previous student
            var s2 = svc.AddStudent("XXX", "xxx@email.com", "Computing", 20, 0, "");
            
            // assert
            Assert.NotNull(s1); // this student should have been added correctly
            Assert.Null(s2); // this student should NOT have been added        
        }

        [Fact]
        public void Student_AddStudent_WhenNone_ShouldSetAllProperties()
        {
            // act 
            var added = svc.AddStudent("XXX", "Computing", "xxx@email.com", 20, 0, "");
            
            // retrieve student just added by using the Id returned by EF
            var s = svc.GetStudent(added.Id);

            // assert - that student is not null
            Assert.NotNull(s);
            
            // now assert that the properties were set properly
            Assert.Equal(s.Id, s.Id);
            Assert.Equal("XXX", s.Name);
            Assert.Equal("xxx@email.com", s.Email);
            Assert.Equal("Computing", s.Course);
            Assert.Equal(20, s.Age);
            Assert.Equal(0, s.Grade);
        }

        [Fact]
        public void Student_UpdateStudent_ThatExists_ShouldSetAllProperties()
        {
            // arrange - create test student
            var s = svc.AddStudent("ZZZ", "zzz@email.com",  "Maths", 30, 100, "");
                        
            // act - create a copy and update any student properties (except Id) 
            var u = new Student {
                Id = s.Id,
                Name = "XXX",
                Email = "xxx@email.com",
                Course = "Computing",
                Age = 31,
                Grade = 50,
                PhotoUrl = "http://photo.com"
            };
            // save updated student
            svc.UpdateStudent(u); 

            // reload updated student from database into us
            var us = svc.GetStudent(s.Id);

            // assert
            Assert.NotNull(u);           

            // now assert that the properties were set properly           
            Assert.Equal(u.Name, us.Name);
            Assert.Equal(u.Email, us.Email);
            Assert.Equal(u.Course, us.Course);
            Assert.Equal(u.Age, us.Age);
            Assert.Equal(u.Grade, us.Grade);
            Assert.Equal(u.PhotoUrl, us.PhotoUrl);
            
        }

        [Fact] 
        public void Student_GetAllStudents_WhenNone_ShouldReturn0()
        {
            // act 
            var students = svc.GetStudents();
            var count = students.Count;

            // assert
            Assert.Equal(0, count);
        }


        [Fact]
        public void Student_GetStudents_When2Exist_ShouldReturn2()
        {
            // arrange
            var s1 = svc.AddStudent("XXX", "Computing",   "xxx@email.com", 20, 0, "");
            var s2 = svc.AddStudent("YYY", "Engineering", "yyy@email.com", 23, 0, "");

            // act
            var students = svc.GetStudents();
            var count = students.Count;

            // assert
            Assert.Equal(2, count);
        }


        [Fact] 
        public void Student_GetStudent_WhenNonExistent_ShouldReturnNull()
        {
            // act 
            var student = svc.GetStudent(1); // non existent student

            // assert
            Assert.Null(student);
        }

        [Fact] 
        public void Student_GetStudent_ThatExists_ShouldReturnStudent()
        {
            // act 
            var s = svc.AddStudent("XXX", "Computing", "xxx@email.com", 20, 0, "");

            var ns = svc.GetStudent(s.Id);

            // assert
            Assert.NotNull(ns);
            Assert.Equal(s.Id, ns.Id);
        }

        [Fact] 
        public void Student_GetStudent_ThatExistsWithTickets_ShouldReturnStudentWithTickets()
        {
            // arrange 
            var s = svc.AddStudent("XXX", "Computing", "xxx@email.com", 20, 0, "");
            svc.CreateTicket(s.Id, "Ticket 1");
            svc.CreateTicket(s.Id, "Ticket 2");
            
            // act
            var student = svc.GetStudent(s.Id);

            // assert
            Assert.NotNull(s);    
            Assert.Equal(2, student.Tickets.Count);
        }

        [Fact]
        public void Student_DeleteStudent_ThatExists_ShouldReturnTrue()
        {
            // act 
            var s = svc.AddStudent("XXX", "Computing", "xxx@email.com", 20, 0, "");
            var deleted = svc.DeleteStudent(s.Id);

            // try to retrieve deleted student
            var s1 = svc.GetStudent(s.Id);

            // assert
            Assert.True(deleted); // delete student should return true
            Assert.Null(s1);      // s1 should be null
        }

        [Fact]
        public void Student_DeleteStudent_ThatDoesntExist_ShouldReturnFalse()
        {
            // act 	
            var deleted = svc.DeleteStudent(0);

            // assert
            Assert.False(deleted);
        }        

        [Fact]
        public void Student_UpdateStudent_ThatExistsWithAgePlusOne_ShouldWork()
        {
            // arrange
            var added = svc.AddStudent("Clare", "Computing", "clare@gmail.com", 21, 0, "");

            // act
            // create a copy of added student and increment age by 1
            var s = new Student {
                Id = added.Id,
                Name = added.Name,
                Course = added.Course,
                Email = added.Email,
                Age =  added.Age + 1,
                Grade = added.Grade                
            };
            // update this student
            svc.UpdateStudent(s);

            // now load the student and verify age was updated
            var su = svc.GetStudent(s.Id);

            // assert
            Assert.Equal(s.Age, su.Age);
        }


        // ---------------------- Ticket Tests ------------------------
        
        [Fact] 
        public void Ticket_CreateTicket_ForExistingStudent_ShouldBeCreated()
        {
            // arrange
            var s = svc.AddStudent("XXX", "xxx@email.com", "Computing", 20, 0, "http://photo.com");
         
            // act
            var t = svc.CreateTicket(s.Id, "Dummy Ticket 1");
           
            // assert
            Assert.NotNull(t);
            Assert.Equal(s.Id, t.StudentId);
            Assert.True(t.Active); 
        }

         [Fact] // --- GetTicket should include Student
        public void Ticket_GetTicket_WhenExists_ShouldReturnTicketAndStudent()
        {
            // arrange
            var s = svc.AddStudent("XXX", "xxx@email.com", "Computing", 20, 0, "http://photo.com");
            var t = svc.CreateTicket(s.Id, "Dummy Ticket 1");

            // act
            var ticket = svc.GetTicket(t.Id);

            // assert
            Assert.NotNull(ticket);
            Assert.NotNull(ticket.Student);
            Assert.Equal(s.Name, ticket.Student.Name); 
        }

        [Fact] // --- GetOpenTickets When two added should return two 
        public void Ticket_GetOpenTickets_WhenTwoAdded_ShouldReturnTwo()
        {
            // arrange
            var s = svc.AddStudent("XXX", "xxx@email.com", "Computing", 20, 0, "http://photo.com");
            var t1 = svc.CreateTicket(s.Id, "Dummy Ticket 1");
            var t2 = svc.CreateTicket(s.Id, "Dummy Ticket 2");

            // act
            var open = svc.GetOpenTickets();

            // assert
            Assert.Equal(2,open.Count);                        
        }

        [Fact] 
        public void Ticket_CloseTicket_WhenOpen_ShouldReturnTicket()
        {
            // arrange
            var s = svc.AddStudent("XXX", "xxx@email.com", "Computing", 20, 0, "http://photo.com");
            var t = svc.CreateTicket(s.Id, "Dummy Ticket");

            // act
            var r = svc.CloseTicket(t.Id, "Resolved");

            // assert
            Assert.NotNull(r);              // verify closed ticket returned          
            Assert.False(r.Active);
            Assert.Equal("Resolved",r.Resolution);
        }

        [Fact] 
        public void Ticket_CloseTicket_WhenAlreadyClosed_ShouldReturnNull()
        {
            // arrange
            var s = svc.AddStudent("XXX", "xxx@email.com", "Computing", 20, 0, "http://photo.com");
            var t = svc.CreateTicket(s.Id, "Dummy Ticket");

            // act
            var closed = svc.CloseTicket(t.Id, "Solved");     // close active ticket    
            closed = svc.CloseTicket(t.Id,"Solved");         // close non active ticket

            // assert
            Assert.Null(closed);                    // no ticket returned as already closed
        }

        [Fact] 
        public void Ticket_DeleteTicket_WhenExists_ShouldReturnTrue()
        {
            // arrange
            var s = svc.AddStudent("XXX", "xxx@email.com", "Computing", 20, 0, "http://photo.com");
            var t = svc.CreateTicket(s.Id, "Dummy Ticket");

            // act
            var deleted = svc.DeleteTicket(t.Id);     // delete ticket    
            
            // assert
            Assert.True(deleted);                    // ticket should be deleted
        }   

        [Fact] 
        public void Ticket_DeleteTicket_WhenNonExistant_ShouldReturnFalse()
        {
            // arrange
           
            // act
            var deleted = svc.DeleteTicket(1);     // delete non-existent ticket    
            
            // assert
            Assert.False(deleted);                  // ticket should not be deleted
        }  


        // ======================= Module Tests =======================
        
        [Fact] 
        public void Module_AddStudentToModule_WhenValid_ShouldReturnStudentModule()
        {
            // arrange
            var s = svc.AddStudent("XXX", "xxx@email.com", "Computing", 20, 0, "http://photo.com");
            var m = svc.AddModule("YYY");

            // act
            var sm = svc.AddStudentToModule(s.Id, m.Id, 0);
        
            // assert
            Assert.NotNull(sm);
            Assert.Equal(s.Id, sm.StudentId);
            Assert.Equal(m.Id, sm.ModuleId);                      
        }

         [Fact] 
        public void Student_GetStudent_WhenContainsTicketsAndModules_ShouldReturnAll()
        {
            // arrange
            var s = svc.AddStudent("XXX", "xxx@email.com", "Computing", 20, 0, "http://photo.com");
            var m = svc.AddModule("YYY");

            var sm = svc.AddStudentToModule(s.Id, m.Id, 0);
            var t = svc.CreateTicket(s.Id, "XXX");
        
            // act

            var r = svc.GetStudent(s.Id);

            // assert
            Assert.NotNull(r);
            Assert.Equal(1, r.Tickets.Count);
            Assert.Equal(1, r.StudentModules.Count);                      
        }

        [Fact] 
        public void AddStudentToModule_WhenAlreadyTakingModule_ShouldReturNull()
        {
            // arrange
            var s = svc.AddStudent("XXX", "xxx@email.com", "Computing", 20, 0, "http://photo.com");
            var m = svc.AddModule("YYY");

            // act
            var sm1 = svc.AddStudentToModule(s.Id, m.Id, 0);
            var sm2 = svc.AddStudentToModule(s.Id, m.Id, 0); // duplicate

            // assert
            Assert.Null(sm2);           
        }  

         //  =================  User Tests ===========================
        
        [Fact] // --- Register Valid User test
        public void User_Register_WhenValid_ShouldReturnUser()
        {
            // arrange 
            var reg = svc.Register("XXX", "xxx@email.com", "admin", Role.admin);
            
            // act
            var user = svc.GetUserByEmail(reg.Email);
            
            // assert
            Assert.NotNull(reg);
            Assert.NotNull(user);
        } 

        [Fact] // --- Register Duplicate Test
        public void User_Register_WhenDuplicateEmail_ShouldReturnNull()
        {
            // arrange 
            var s1 = svc.Register("XXX", "xxx@email.com", "admin", Role.admin);
            
            // act
            var s2 = svc.Register("XXX", "xxx@email.com", "admin", Role.admin);

            // assert
            Assert.NotNull(s1);
            Assert.Null(s2);
        } 

        [Fact] // --- Authenticate Invalid Test
        public void User_Authenticate_WhenInValidCredentials_ShouldReturnNull()
        {
            // arrange 
            var s1 = svc.Register("XXX", "xxx@email.com", "admin", Role.admin);
        
            // act
            var user = svc.Authenticate("xxx@email.com", "guest");
            // assert
            Assert.Null(user);

        } 

        [Fact] // --- Authenticate Valid Test
        public void User_Authenticate_WhenValidCredentials_ShouldReturnUser()
        {
            // arrange 
            var s1 = svc.Register("XXX", "xxx@email.com", "admin", Role.admin);
        
            // act
            var user = svc.Authenticate("xxx@email.com", "admin");
            
            // assert
            Assert.NotNull(user);
        } 
    
    }
}