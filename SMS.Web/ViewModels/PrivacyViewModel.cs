 using System;
    
    namespace SMS.Web.ViewModels
    {
       public class PrivacyViewModel      
       {
          public string Title { get; set; }
          public string Aim { get; set; }
          public DateTime Formed { get; set; } = DateTime.Now;
          public string FormedString => Formed.ToLongDateString();

       }
    }