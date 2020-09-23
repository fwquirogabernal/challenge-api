using Challenge.DataBase.Setup;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.CommandsAndQueries.Commands
{
    public abstract class BaseCommand
    {
        private readonly IDataBaseContext _context;

        public BaseCommand(IDataBaseContext context)
        {
            _context = context;
        }

        protected void ExecuteCommandInternal(Action<IDataBaseContext> action)
        {
            using (_context)
            {
                action(_context);
                _context.SaveChanges();
            }
        }
    }
}
