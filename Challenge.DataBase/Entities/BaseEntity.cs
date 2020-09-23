using System;
using System.ComponentModel.DataAnnotations;

namespace Challenge.DataBase.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
