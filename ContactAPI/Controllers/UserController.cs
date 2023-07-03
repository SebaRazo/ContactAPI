using AutoMapper;
using ContactAPI.Data;
using ContactAPI.Entities;
using ContactAPI.Models.DTOs;
using ContactAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _automapper;
        public UserController(IUserRepository userRepository, IMapper automapper)
        {

            _userRepository = userRepository;
            _automapper = automapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetAll());
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOneById(int Id)
        {
            try
            {
                var User_Id = await _userRepository.GetById(Id);
                if(User_Id == null)
                {
                    return NotFound();
                }
                var dto = _automapper.Map<GetUserByIdReponse>(User_Id);
                return Ok(dto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUser dto)
        {
            try 
            {
                var user = _automapper.Map<User>(dto);
                await _userRepository.Create(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", dto);
            
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(int id_user, CreateUser dto)
        {
            try
            {
                var userItem = await _userRepository.GetById(id_user);
                if(userItem == null)
                {
                    return NotFound();
                }
                await _userRepository.Update(id_user, dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            try
            {
                var user = await _userRepository.GetById(Id);
                if (user == null)
                {
                    return NotFound();
                }
                if(user.Rol == 0)
                {
                    await _userRepository.Archive(user);
                }
                else
                {
                    await _userRepository.Delete(user);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
