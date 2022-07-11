using Microsoft.AspNetCore.Mvc;

namespace PlatformDemo.Models
{
    public class Ticket
    {

        
        public int Id { get; set; }
        
        public int ProjectId { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
    }
}
