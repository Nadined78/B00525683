using SMS.Data.Models;

namespace SMS.Web.ViewModels
{   
    public class UserSearchViewModel
    {
        public IList<User> Users { get; set;} = new List<User>();

        // search options by query of user name  
        public string Query { get; set; } = "";
        
        public AllUsers Range { get; set; } = AllUsers.ALL;
        
    }
}