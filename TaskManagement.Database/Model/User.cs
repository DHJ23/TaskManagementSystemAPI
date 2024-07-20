using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Database.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // Employee, Manager, Admin
        public ICollection<Task> CreatedTasks { get; set; }
        public ICollection<Task> AssignedTasks { get; set; }
    }
}
