﻿namespace ToDoTasks.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;
    }
}
