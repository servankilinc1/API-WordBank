using AutoMapper;
using DataAccess.Abstract;
using DataAccess.DTO;
using DataAccess.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IWordDal _wordDal;
        private readonly IMapper _mapper;


        public WordController(IWordDal wordDal, IMapper mapper) { 
            _wordDal = wordDal;
            _mapper = mapper;
        }


        [HttpGet("GetAllByCategoryForUser")] 
        public IActionResult GetAllByCategoryForUser(int categoryId, int userId)
        {
            try
            {
                var result = _wordDal.GetAllByCategory(categoryId, userId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e); 
            }
        }


        [HttpPost("Insert")]
        public IActionResult Insert(WordRequest wordRequest)
        {
            try
            {
                var result = _wordDal.Insert(_mapper.Map<Word>(wordRequest));

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(WordUpdateRequest wordUpdateRequest)
        {
            try
            {
                var result = _wordDal.Update(_mapper.Map<Word>(wordUpdateRequest));

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpDelete("Delete")]
        public IActionResult Delete(int wordId)
        {
            try
            {
                var result = _wordDal.Delete(filter => filter.Id == wordId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
