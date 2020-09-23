using Challenge.DataBase.Entities;
using Challenge.DataBase.Setup;
using System;

namespace Challenge.CommandsAndQueries.Queries
{
    public abstract class BaseQuery<TEntity> where TEntity: BaseEntity
    {
        private readonly IDataBaseContext _context;

        public BaseQuery(IDataBaseContext context)
        {
            _context = context;
        }

        protected T ExecuteQuery<T>(Func<IDataBaseContext, T> function)
        {
            using (_context)
            {
                return function(_context);
            }
        }
    }
}
