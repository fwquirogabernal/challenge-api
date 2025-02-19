﻿using Challenge.DataBase.Entities;
using Challenge.DataBase.Setup;
using System;
using System.Linq;

namespace Challenge.CommandsAndQueries.Commands
{
    public class TasksCommands : BaseCommand, ITaskCommand<Task>
    {
        public TasksCommands(IDataBaseContext context) : base(context)
        {
        }

        public void Add(Task entity)
        {
            if (entity == null || string.IsNullOrEmpty(entity.Description))
                throw new ArgumentNullException(nameof(entity));

            ExecuteCommandInternal(t => t.Tasks.Add(entity));
        }

        public void Update(Task entity, bool remove = false)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            ExecuteCommandInternal(t =>
            {
                var old = t.Tasks.SingleOrDefault(t => t.Id == entity.Id);
                if (old == null)
                    throw new ArgumentNullException(nameof(entity));
                old.Codigo = !remove ? entity.Codigo : 0;
                old.Description = entity.Description;
                old.IsCompleted = entity.IsCompleted;
                old.IsDeleted = remove;

                t.Tasks.Update(old);

            });
        }

        public void UpdateAll(Task[] entities, bool remove = false)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            ExecuteCommandInternal(t =>
            {
                foreach (var entity in entities)
                {
                    var old = t.Tasks.SingleOrDefault(t => t.Id == entity.Id);
                    if (old == null)
                        throw new ArgumentNullException(nameof(entity));
                    old.Codigo = !remove ? entity.Codigo : 0;
                    old.Description = entity.Description;
                    old.IsCompleted = entity.IsCompleted;
                    old.IsDeleted = remove;

                    t.Tasks.Update(old);
                }
            });
        }
    }
}
