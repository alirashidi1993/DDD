using Framework.Core.ApplicationService;
using Framework.Domain;
using HR.EmployeeContext.ApplicationService.Contracts.Shifts;
using HR.EmployeeContext.Domain.Shifts;
using HR.EmployeeContext.Domain.Shifts.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HR.EmployeeContext.ApplicationService.Shifts
{
    public class EditShiftCommandHandler : ICommandHandler<EditShiftCommand>
    {
        private readonly IShiftRepository shiftRepository;
        private readonly IShiftNameDuplicateCheckService shiftNameDuplicateCheckService;

        public EditShiftCommandHandler(
            IShiftRepository shiftRepository,
            IShiftNameDuplicateCheckService shiftNameDuplicateCheckService
            )
        {
            this.shiftRepository = shiftRepository;
            this.shiftNameDuplicateCheckService = shiftNameDuplicateCheckService;

        }
        public void Execute(EditShiftCommand command)
        {
            var shift = shiftRepository.FindById(command.Id);
            shift.setName(command.Name, shiftNameDuplicateCheckService);

            var existingPatterns = shift.Patterns.ToList();
            var updatedPatterns = new List<ShiftPattern>();

            command.ShiftPatternEditObjects.ForEach(pattern =>
            {
                var shiftPattern = new ShiftPattern(
                    pattern.DayOrder,
                    pattern.StartTime,
                    pattern.EndTime
                    );
                updatedPatterns.Add(shiftPattern);
            });

            existingPatterns.UpdateFrom(updatedPatterns);
            shift.setPatterns(existingPatterns, command.CycleDurationInDays);

            shiftRepository.Edit(shift);
        }
    }
}
