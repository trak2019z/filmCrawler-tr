﻿using Autofac;
using FilmCrawler.Core.Infrastructure.CQRS.CommandBase.Interfaces;

namespace FilmCrawler.Core.Infrastructure.CQRS.CommandBase
{
    public class AutofacCommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public AutofacCommandDispatcher(IComponentContext context)
        {
            this._context = context;
        }
        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _context.Resolve<ICommandHandler<TCommand>>();
            handler.Execute(command);
        }
    }
}
