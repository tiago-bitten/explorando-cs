﻿namespace EeFee.DTOs
{
    public class UserDTO
    {
        public int? Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

        public PositionDTO? PositionDTO { get; set; }
    }
}
