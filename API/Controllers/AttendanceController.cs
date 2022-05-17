using HR.EmployeeContext.ApplicationService.Contracts.Attendances;
using HR.EmployeeContext.Facade.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/Attendance")]
    public class AttendanceController:ControllerBase
    {
        private readonly IAttendanceCommandFacade commandFacade;

        public AttendanceController(IAttendanceCommandFacade commandFacade)
        {
            this.commandFacade = commandFacade;
        }

        [HttpPost]
        public ActionResult AddAttendance(AddAttendanceCommand command)
        {
            commandFacade.AddAttendance(command);
            return Ok();
        }
    }
}
