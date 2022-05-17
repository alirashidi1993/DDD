using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.ApplicationService
{
    public interface IUnitOfWork
    {
        void Commit();
        void RollBack();
    }
}
