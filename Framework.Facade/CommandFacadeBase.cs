using Framework.Core.ApplicationService;
using Framework.Core.Facade;
using System;

namespace Framework.Facade
{
    public abstract class CommandFacadeBase:ICommandFacade
    {
        protected readonly ICommandBus commandBus;

        protected CommandFacadeBase(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }
    }
}
