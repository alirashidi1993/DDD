using HR.EmployeeContext.ApplicationService.Contracts.Shifts;
using HR.EmployeeContext.Facade.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/Shift")]
    public class ShiftController:ControllerBase
    {
        private readonly IShiftCommandFacade commandFacade;

        public ShiftController(IShiftCommandFacade commandFacade)
        {
            this.commandFacade = commandFacade;
        }

        [HttpPost]
        public ActionResult Create(CreateShiftCommand command)
        {
            commandFacade.CreateShift(command);
            return Ok();
        }

        [HttpPut]
        public ActionResult Edit(EditShiftCommand command)
        {
            commandFacade.EditShift(command);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Remove(RemoveShiftCommand command)
        {
            commandFacade.RemoveShift(command);
            return Ok();
        }
    }
}
