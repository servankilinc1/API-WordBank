using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.DTO;
using DataAccess.Entity;
using DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class LearningDal : ILearningDal
    {
        public IResult DeleteLearnedWords(UserLearnedWordsRequest userLearnedWordsRequest)
        {
            using (var context = new BaseContext())
            {
                try
                {
                    if (userLearnedWordsRequest != null && userLearnedWordsRequest.WordIds != null)
                    {
                        foreach (var wordId in userLearnedWordsRequest.WordIds)
                        {
                            var entity = context.Set<Learned>().Where(l => l.UserId == userLearnedWordsRequest.UserId && l.WordId == wordId).FirstOrDefault();
                            if (entity != null)
                            {
                                context.Set<Learned>().Remove(entity);
                            }
                        }
                        context.SaveChanges();
                        return new ResultSuccess("İşlem Başarıyla Gerçekleştirildi");
                    }
                    else
                    {
                        return new ResultError("Eklenecek Bilgi Bulunamadı");
                    }
                }
                catch (Exception)
                {
                    return new ResultError("İşlem Başarısız Oldu");
                }
            }
        }

        public IDataResult<List<WordResponse>> GetLearnedWordsForUser(int userId)
        {
            using (var context = new BaseContext())
            {
                try
                {
                    var data = context.Set<Learned>().Where(l => l.UserId == userId).Select(l => new WordResponse() { Id = l.WordId, Turkish = l.Word.Turkish, English = l.Word.English }).ToList();
                    if (data == null)
                    {
                        return new DataResultError<List<WordResponse>>("Bilgi Bulunamadı");
                    }
                    return new DataResultSuccess<List<WordResponse>>(data, "İşlem Başarıyla Gerçekleşti");
                }
                catch (Exception)
                {
                    return new DataResultError<List<WordResponse>>("İşlem Başarısız Oldu");
                }
            }
        } 

        public IResult InsertLearnedWords(UserLearnedWordsRequest userLearnedWordsRequest)
        {
            using (var context = new BaseContext())
            {
                try
                {
                    if(userLearnedWordsRequest != null && userLearnedWordsRequest.WordIds != null)
                    {
                        foreach (var wordId in  userLearnedWordsRequest.WordIds )
                        {
                            var newEntity = new Learned()
                            {
                                UserId = userLearnedWordsRequest.UserId,
                                WordId = wordId
                            };
                            context.Set<Learned>().Add(newEntity);
                        }
                        context.SaveChanges();
                        return new ResultSuccess("İşlem Başarıyla Gerçekleştirildi");
                    }
                    else
                    {
                        return new ResultError("Eklenecek Bilgi Bulunamadı"); 
                    }
                }
                catch (Exception)
                {
                    return new ResultError("İşlem Başarısız Oldu");
                }
            }
        }
    }
}
