using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ValidationAttributes
{
    public class Ticket_EnsureDueDatePresenceAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = (Ticket)validationContext.ObjectInstance as Ticket;

            if (!ticket.ValidateDueDatePresence())
            {
                return new ValidationResult("Due Date is Required.");
            }

            return ValidationResult.Success;
        }
    }
}
