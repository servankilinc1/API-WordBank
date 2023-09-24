using AutoMapper;
using DataAccess.Abstract;
using DataAccess.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteDal _favoriteDal; 

        public FavoriteController(IFavoriteDal favoriteDal)
        {
            _favoriteDal = favoriteDal; 
        }


        [HttpGet("GetFavWordsForUser")]
        public IActionResult GetFavWordsForUser(int userId)
        {
            try
            {
                var result = _favoriteDal.GetFavWordsForUser(userId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPost("DeleteFavorite")]
        public IActionResult DeleteFavorite(UserWordRequest userWordRequest)
        {
            try
            {
                var result = _favoriteDal.DeleteFavorite(userWordRequest);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPost("InsertFavorite")]
        public IActionResult InsertFavorite(UserWordRequest userWordRequest)
        {
            try
            {
                var result = _favoriteDal.InsertFavorite(userWordRequest);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
