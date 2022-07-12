using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PlatformDemo.Models;

namespace PlatformDemo.Filters
{
    public class Ticket_EnsureEnteredDate : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var ticket = context.ActionArguments["ticket"] as Ticket;

            if (ticket is not null && ticket.EnteredDate.HasValue == false && !string.IsNullOrEmpty(ticket.Owner))
            {
                context.ModelState.AddModelError("EnteredDate", "EnteredDate is required.");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }

            
        }
    }
}
