using Core.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Ticket
    {
        public int? TicketId { get; set; }

        [Required]
        public int? ProjectId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string Owner { get; set; }

        [Ticket_EnsureReportDatePresence]
        public DateTime? ReportDate { get; set; }

        [Ticket_EnsureDueDateAfterReportDate]
        [Ticket_EnsureFutureDueDateOnCreate]
        [Ticket_EnsureDueDatePresence]
        public DateTime? DueDate { get; set; }

        public Project Project { get; set; }

        
        
        /// <summary>
        /// When creating a ticket, if due date is entered, it has to be in the future
        /// </summary>
        /// <returns></returns>
        public bool ValidateFutureDueDate()
        {
            if (TicketId.HasValue) return true;
            if (!DueDate.HasValue) return true;

            return (DueDate.Value > DateTime.Now);
        }

        /// <summary>
        /// When owner is assigned, the report date has to be present
        /// </summary>
        /// <returns></returns>
        public bool ValidateReportDatePresence()
        {
            if (string.IsNullOrWhiteSpace(Owner)) return true;

            return (ReportDate.HasValue);
        }

        /// <summary>
        /// When owner is assigned, the due date has to be present
        /// </summary>
        /// <returns></returns>
        public bool ValidateDueDatePresence()
        {
            if (string.IsNullOrWhiteSpace(Owner)) return true;

            return (DueDate.HasValue);
        }

        /// <summary>
        /// When due date and report date are present, due date has to be later than report date
        /// </summary>
        /// <returns></returns>
        public bool ValidateDueDateAfterReportDate()
        {
            if (!DueDate.HasValue || !ReportDate.HasValue) return true;

            return (DueDate.Value.Date > ReportDate.Value.Date);
        }
        


    }
}
