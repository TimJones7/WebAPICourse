using PlatformDemo.Models;
using System.ComponentModel.DataAnnotations;

namespace PlatformDemo.ModelValidations
{
    public class Ticket_EnsureDueDateIsFuture_Attribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = (Ticket)validationContext.ObjectInstance as Ticket;

            //  When creating a ticket, make sure duedate is in the future, 
            //  if ticket alrady has an id then we dont run the validation
            if (ticket.DueDate.HasValue && ticket.Id is null & ticket is not null)
            {
                if (ticket.DueDate.Value < DateTime.Now)
                {
                    return new ValidationResult("Due date must be in the future.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
