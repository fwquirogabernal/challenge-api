﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.DataBase.Entities
{
    [Table("Tasks")]
    public class Task: BaseEntity
    {
        public int Codigo { get; set; }
        [Required]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsDeleted { get; set; }
    }
}
