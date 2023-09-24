using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.DTO;
using DataAccess.Entity;
using DataAccess.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class FavoriteDal : IFavoriteDal
    {
        public IResult DeleteFavorite(UserWordRequest userWordRequest)
        {
            using(var context = new BaseContext())
            {
                try
                {
                    var entity = context.Set<Favorites>().Where(f => f.UserId == userWordRequest.UserId && f.WordId == userWordRequest.WordId).FirstOrDefault();
                    if(entity == null)
                    {
                        return new ResultError("Bilgi Bulunamadı");
                    }
                    context.Remove(entity);
                    context.SaveChanges();
                    return new ResultSuccess("İşlem Başarıyla Gerçekleşti");
                }
                catch (Exception)
                {
                    return new ResultError("İşlem Başarısız Oldu");
                }
            }
        }

        public IDataResult<List<WordResponse>> GetFavWordsForUser(int userId)
        {
            using (var context = new BaseContext())
            {
                try
                {
                    var data = context.Set<Favorites>().Where(f => f.UserId == userId ).Select(f=> new WordResponse() { Id=f.WordId, Turkish= f.Word.Turkish ,English = f.Word.English }).ToList();
                    if (data == null)
                    {
                        return new DataResultError<List<WordResponse>>("Bilgi Bulunamadı");
                    } 
                    return new DataResultSuccess<List<WordResponse>>(data,"İşlem Başarıyla Gerçekleşti");
                }
                catch (Exception)
                {
                    return new DataResultError<List<WordResponse>>("İşlem Başarısız Oldu");
                }
            }
        }

        public IResult InsertFavorite(UserWordRequest userWordRequest)
        {
            using (var context = new BaseContext())
            {
                try
                {
                    var newEntity = new Favorites()
                    {
                        UserId = userWordRequest.UserId,
                        WordId = userWordRequest.WordId
                    };
                    context.Set<Favorites>().Add(newEntity);
                    context.SaveChanges();
                    return new ResultSuccess("İşlem Başarıyla Gerçekleştirildi");
                }
                catch (Exception)
                {
                    return new ResultError("İşlem Başarısız Oldu");
                }
            }
        }
    }
}
