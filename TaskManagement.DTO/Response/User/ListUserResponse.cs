namespace TaskManagement.DTO.Response.User
{
    public class ListUserResponse
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // Employee, Manager, Admin
    }
}
