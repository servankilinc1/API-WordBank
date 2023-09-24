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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccess.Concrete
{
    public class WordDal: EFCoreRepositoryBase<Word, BaseContext>, IWordDal
    {
        public IDataResult<List<ViewModelWord>> GetAllByCategory(int categoryId, int userId)
        {
            using(var context = new BaseContext())
            {
                try
                {
                var data = context.Words.Where(filter =>  filter.CategoryId == categoryId)
                    .Select( word =>
                        new ViewModelWord()
                        {

                            Word = word,
                            IsUeserAddedFav = userId != null ? word.Favorites.Any(f => f.UserId == userId ): false 
                        }).ToList();
                    return new DataResultSuccess<List<ViewModelWord>>(data,"İşlem Başarıyla Gerçekleşti"); 
                }
                catch (Exception)
                { 
                    return new DataResultError<List<ViewModelWord>>("İşlem Başarıyla Gerçekleşti"); 
                }
            }
        }
    }
}
