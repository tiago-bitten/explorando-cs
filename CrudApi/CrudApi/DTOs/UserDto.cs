﻿using System.ComponentModel.DataAnnotations;

namespace CrudApi.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
