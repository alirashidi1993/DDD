using Framework.Core.Domain;
using Framework.Domain;
using HR.EmployeeContext.Domain.Shifts.Exceptions;
using HR.EmployeeContext.Domain.Shifts.Services;
using System.Collections.Generic;

namespace HR.EmployeeContext.Domain.Shifts
{
    public class Shift : EntityBase, IAggregateRoot
    {
        
        private IShiftNameDuplicateCheckService shiftNameDuplicateCheckService;

        protected Shift() { }
        public Shift(
            string name,
            int cycleDurationInDays,
            List<ShiftPattern> patterns,
            
            IShiftNameDuplicateCheckService shiftNameDuplicateCheckService
            )
        {
            
            this.shiftNameDuplicateCheckService = shiftNameDuplicateCheckService;
            _Patterns = new List<ShiftPattern>();

            setName(name, shiftNameDuplicateCheckService);
            setPatterns(patterns, cycleDurationInDays);
            CycleDurationInDays = cycleDurationInDays;
        }
        public void setPatterns(List<ShiftPattern> patterns, int cycleDurationInDays)
        {
            if (patterns.Count != cycleDurationInDays)
                throw new CycleDurationInDaysNotQualToPatternsCountException();

            _Patterns = patterns;
        }
        public void setName(string name, IShiftNameDuplicateCheckService shiftNameDuplicateCheckService)
        {
            this.shiftNameDuplicateCheckService = shiftNameDuplicateCheckService;

            if (string.IsNullOrEmpty(name))
                throw new NullOrEmptyShiftNameException();

            if (this.shiftNameDuplicateCheckService.isDuplicate(Id, name))
                throw new DuplicateShiftNameException();

            Name = name;
        }

        public string Name { get; private set; }
        public int CycleDurationInDays { get; private set; }
        public IReadOnlyList<ShiftPattern> Patterns => _Patterns.AsReadOnly();

        private List<ShiftPattern> _Patterns;
    }
}
