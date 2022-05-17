using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Facade.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeCommandFacade commandFacade;

        public EmployeeController(IEmployeeCommandFacade commandFacade)
        {
            this.commandFacade = commandFacade;
        }

        [HttpPost]
        public ActionResult CreateEmployee(EmployeeCreateCommand command)
        {
            commandFacade.CreateEmployee(command);
            return Ok();
        }
        [HttpPut]
        public ActionResult EditEmployee(EmployeeEditCommand command)
        {
            commandFacade.EditEmployee(command);
            return Ok();
        }
        [HttpDelete]
        public ActionResult RemoveEmployee(EmployeeRemoveCommand command)
        {
            commandFacade.RemoveEmployee(command);
            return Ok();
        }
        [HttpPost]
        [Route("AddContract")]
        public ActionResult AddContract(CreateContractCommand command)
        {
            commandFacade.AddContract(command);
            return Ok();
        }
        [HttpPut]
        [Route("EditContract")]
        public ActionResult EditContract(EditContractCommand command)
        {
            commandFacade.EditContract(command);
            return Ok();
        }
        [HttpPost]
        [Route("AssignShift")]
        public ActionResult AssignShift(AssignShiftCommand command)
        {
            commandFacade.AssignShift(command);
            return Ok();
        }

        [HttpPost]
        [Route("GenerateAllEmployeeOverallWorkSummary")]
        public ActionResult GenerateAllEmployeeOverallWorkSummary(GenerateAllEmployeeOverallWorkSummaryCommand command)
        {
            commandFacade.GenerateAllEmployeeOverallWorkSummary(command);
            return Ok();
        }
    }
}
