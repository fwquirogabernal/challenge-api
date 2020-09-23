﻿using Challenge.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.CommandsAndQueries.Commands
{
    public interface ITaskCommand<TEntity> where TEntity: BaseEntity
    {
        void Add(TEntity entity);

        void Update(TEntity entity, bool remove = false);
    }
}
