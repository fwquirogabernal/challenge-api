using Challenge.DataBase.Entities;
using Challenge.DataBase.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Challenge.CommandsAndQueries.Queries
{
    public class TasksQueries : BaseQuery<Task>, ITaskQuery
    {
        public TasksQueries(IDataBaseContext context) : base(context)
        {
        }

        public IEnumerable<Task> GetAll()
        {
            return ExecuteQuery(t => t.Tasks.ToArray());   
        }
    }
}
