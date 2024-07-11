using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using WebApi.Interfaces;
using WebApi.Entities.Models;
using AutoMapper;
using WebApi.Entities.DataTransferObjects;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        //private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var users = _unitOfWork.Users.GetAll();
            return Ok(users);
        }

        // POST: api/User
        [HttpPost]
        [Route("Create")]
        public IActionResult CreateUser(UserForCreateDto user)
        {
            try
            {


                if (user == null)
                    return BadRequest("User data is invalid.");

                var _user = _unitOfWork.Users.Find(x => x.UserName == user.UserName).Any();
                if (_user)
                {
                    return BadRequest($"User with UserName: {user.UserName}, already exists in DB");
                }

                var userEntity = _mapper.Map<User>(user);

                // Generate UserId (you can use GUID or any other method)

                userEntity.UserId = Guid.NewGuid();
                _unitOfWork.Users.Create(userEntity);

                _unitOfWork.Complete();

                var CreateUser = _mapper.Map<User>(userEntity);

                return Ok(CreateUser);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong inside CreateUser action: {ex.Message}");
            }
        }
        [HttpPost]
        [Route("Validate")]
        public IActionResult ValidateUser(UserForCreateDto user)
        {
            try
            {
                var _user = _unitOfWork.Users.Find(x => x.UserName == user.UserName 
                && x.UserPassword == user.UserPassword).Any();

                if (_user)
                    return BadRequest(_user);

                return Ok(_user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong inside ValidateUser action: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            try
            {
                var User = _unitOfWork.Users.Find(user => user.UserId.Equals(id)).FirstOrDefault();
                if (User == null)
                {
                    return NotFound($"User with id: {id}, hasn't been found in db.");
                }

                _unitOfWork.Users.Remove(User);
                _unitOfWork.Complete();


                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong inside DeleteUser action: {ex.Message}");
            }
        }
    }

}
