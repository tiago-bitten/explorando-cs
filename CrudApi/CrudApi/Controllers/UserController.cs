﻿using CrudApi.DTOs;
using CrudApi.Models;
using CrudApi.Repositories;
using CrudApi.Repositories.Interfaces;
using CrudApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] int skip = 0,
            [FromQuery] int take = 10)
        {
            return Ok(await _userService.FindAll(skip, take));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            return Ok(await _userService.FindById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            return Created("", await _userService.Create(dto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto dto, int id)
        {
            await _userService.Update(dto, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return NoContent();
        }
    }
}
