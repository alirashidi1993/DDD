using Framework.Domain;
using HR.EmployeeContext.Domain.Shifts.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.Domain.Shifts
{
    public class ShiftPattern : ValueObject<ShiftPattern>
    {
        protected ShiftPattern() { }
        public ShiftPattern(int dayOrder, string startTime, string endTime)
        {
            setDayOrder(dayOrder);

            setTimes(startTime,endTime);
        }
        private void setDayOrder(int dayOrder)
        {
            if (dayOrder == 0)
                throw new InvalidShiftPatternDayException();

            DayOrder = dayOrder;
        }

        private void setTimes(string startTime,string endTime)
        {
            ValidateTimes(startTime, endTime);

            this.StartTime = startTime.ConvertToTimeSpan();
            this.EndTime = endTime.ConvertToTimeSpan();
        }

        private void ValidateTimes(string startTime, string endTime)
        {
            if (startTime == null)
                throw new NullShiftPatternStartTimeException();

            if (endTime == null)
                throw new NullShiftPatternEndTimeException();

            if (!IsTimeValid(startTime))
                throw new ShiftPatternStartTimeInvalidFormatException();

            if (!IsTimeValid(endTime))
                throw new ShiftPatternEndTimeInvalidFormatException();
        }

        private bool IsTimeValid(string time)
        {
            if (!time.Contains(':'))
                return false;

            var hour = time.Split(':')[0];
            var minute = time.Split(':')?[1];

            if (hour.Length != 2 || minute?.Length != 2)
                return false;

            return true;
        }


        public int DayOrder { get; private set; }
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }


        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return this.DayOrder;
            yield return this.StartTime;
            yield return this.EndTime;
        }
    }
}
