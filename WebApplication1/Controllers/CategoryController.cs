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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;


        public CategoryController(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _categoryDal.GetAll();

                return Ok(_mapper.Map<List<CategoryResponse>>(result.Data));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("GetAllForUser")]
        public IActionResult GetAllForUser(int userId)
        {
            try
            {
                var result = _categoryDal.GetAllForUser(userId);

                return Ok(_mapper.Map<List<CategoryResponse>>(result.Data));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPost("Insert")]
        public IActionResult Insert(CateogoryRequest cateogoryRequest)
        {
            try
            {
                var result = _categoryDal.Insert(_mapper.Map<Category>(cateogoryRequest));

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(CateogoryRequest cateogoryRequest)
        {
            try
            {
                var result = _categoryDal.Update(_mapper.Map<Category>(cateogoryRequest));

                return Ok(result);
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
                var result = _categoryDal.Delete(filter => filter.Id == categoryId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
