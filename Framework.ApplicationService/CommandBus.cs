using Framework.Core.ApplicationService;
using Framework.Core.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.ApplicationService
{
    public class CommandBus : ICommandBus
    {
        private readonly IDiContainer diContainer;

        public CommandBus(IDiContainer diContainer)
        {
            this.diContainer = diContainer;
        }
        public void Dispatch<TCommand>(TCommand command) where TCommand : Command
        {
            var commandHandler = diContainer.Resolve<ICommandHandler<TCommand>>();
            var transactionalCommandHandler = new TransactionalCommandHandler<TCommand>
                (diContainer, commandHandler);
            transactionalCommandHandler.Execute(command);
        }
    }
}
