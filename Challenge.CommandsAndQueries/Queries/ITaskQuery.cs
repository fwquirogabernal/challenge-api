using Challenge.DataBase.Entities;
using System.Collections.Generic;

namespace Challenge.CommandsAndQueries.Queries
{
    public interface ITaskQuery
    {
        IEnumerable<Task> GetAll();
    }
}
