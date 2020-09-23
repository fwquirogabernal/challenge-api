using Challenge.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Challenge.DataBase.Setup
{
    public interface IDataBaseContext: IDisposable
    {
        public DbSet<Task> Tasks { get; }
    }
}