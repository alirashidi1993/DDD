using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.ApplicationService
{
    public abstract class Command
    {
        protected Command()
        {
            ExecutionDateTime = DateTime.Now;
        }

        public  DateTime ExecutionDateTime { get; }
    }
}
