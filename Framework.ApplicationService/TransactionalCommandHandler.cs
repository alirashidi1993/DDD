using Framework.Core.ApplicationService;
using Framework.Core.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.ApplicationService
{
    public class TransactionalCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : Command
    {
        private readonly IDiContainer diContainer;
        private readonly ICommandHandler<TCommand> commandHandler;

        public TransactionalCommandHandler(IDiContainer diContainer,ICommandHandler<TCommand> commandHandler)
        {
            this.diContainer = diContainer;
            this.commandHandler = commandHandler;
        }
        public void Execute(TCommand command)
        {
            var unitOfWork = diContainer.Resolve<IUnitOfWork>();
            try
            {
                commandHandler.Execute(command);
                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.RollBack();
                throw;
            }
        }
    }
}
