using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contracts.Shifts;
using HR.EmployeeContext.Domain.Shifts;
using HR.EmployeeContext.Domain.Shifts.Services;
using System;
using System.Collections.Generic;

namespace HR.EmployeeContext.ApplicationService.Shifts
{
    public class CreateShiftCommandHandler : ICommandHandler<CreateShiftCommand>
    {
        private readonly IShiftRepository shiftRepository;
        private readonly IShiftNameDuplicateCheckService shiftNameDuplicateCheckService;

        public CreateShiftCommandHandler(
            IShiftRepository shiftRepository,
            IShiftNameDuplicateCheckService shiftNameDuplicateCheckService
            )
        {
            this.shiftRepository = shiftRepository;
            this.shiftNameDuplicateCheckService = shiftNameDuplicateCheckService;
        }
        public void Execute(CreateShiftCommand command)
        {
            var patterns = new List<ShiftPattern>();
            foreach (var pattern in command.ShiftPatternCreateObjects)
            {
                
                var shiftPattern = new ShiftPattern
                    (
                    pattern.DayOrder,
                    pattern.StartTime,
                    pattern.EndTime
                    );
                patterns.Add(shiftPattern);
            }
            var shift = new Shift(
                command.Name,
                command.CycleDurationInDays,
                patterns,
                shiftNameDuplicateCheckService
                );

            shiftRepository.Create(shift);

        }
    }
}
