using AutoMapper;
using DataAccess.Abstract;
using DataAccess.DTO;
using DataAccess.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningController : ControllerBase
    {
        private readonly ILearningDal _learningDal; 


        public LearningController(ILearningDal learningDal)
        {
            _learningDal = learningDal; 
        }


        [HttpGet("GetLearnedWordsForUser")]
        public IActionResult GetLearnedWordsForUser(int userId)
        {
            try
            {
                var result = _learningDal.GetLearnedWordsForUser(userId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPost("DeleteLearnedWords")]
        public IActionResult DeleteLearnedWords(UserLearnedWordsRequest userLearnedWordsRequest)
        {
            try
            {
                var result = _learningDal.DeleteLearnedWords(userLearnedWordsRequest);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        

        [HttpPost("InsertLearnedWords")]
        public IActionResult InsertLearnedWords(UserLearnedWordsRequest userLearnedWordsRequest)
        {
            try
            {
                var result = _learningDal.DeleteLearnedWords(userLearnedWordsRequest);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
 
    }
}
