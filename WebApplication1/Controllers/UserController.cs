using AutoMapper;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.DTO;
using DataAccess.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDal _userDal; 
        private readonly IMapper _mapper; 


        public UserController(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper; 
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _userDal.GetAll();

                return Ok(_mapper.Map<List<UserResponse>>(result.Data));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPost("SignUp")]
        public IActionResult SignUp(UserRequest userRequest)
        {
            try
            {
                var result = _userDal.Insert(_mapper.Map<User>(userRequest));

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPost("Login")]
        public IActionResult Login(UserRequest userRequest)
        {
            try
            {
                var result = _userDal.Login(userRequest);

                if (result.Success)
                {
                    return Ok(_mapper.Map<UserResponse>(result.Data));
                }
                return BadRequest(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }



        [HttpDelete("Delete")]
        public IActionResult Delete(int categoryId)
        {
            try
            {
                var result = _userDal.Delete(filter => filter.Id == categoryId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
