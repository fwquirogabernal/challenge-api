using Challenge.DataBase.Entities;
using System;

namespace Challenge.Api.Dtos
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }

        public Task ToEntity(bool isUpdate = false)
        {
            return new Task
            {
                Id = !isUpdate ? Guid.NewGuid() : Id,
                Codigo = Codigo,
                Description = Description,
                IsCompleted = IsCompleted
            };
        }
    }
}
