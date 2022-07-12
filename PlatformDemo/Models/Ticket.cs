using Microsoft.AspNetCore.Mvc;
using PlatformDemo.ModelValidations;
using System.ComponentModel.DataAnnotations;

namespace PlatformDemo.Models
{
    public class Ticket
    {

        
        public int? Id { get; set; }

        [Required]
        public int? ProjectId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        
        public string Description { get; set; }
        
        public string Owner { get; set; }

        [Ticket_EnsureDueDateForTicketOwner]
        [Ticket_EnsureDueDateIsFuture_Attribute]
        public DateTime? DueDate { get; set; }
        

        public DateTime? EnteredDate { get; set; }
        
    }
}
