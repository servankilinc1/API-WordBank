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
    public class CategoryDal: EFCoreRepositoryBase<Category, BaseContext>, ICategoryDal
    {
        public IDataResult<List<ViewModelCategory>> GetAllForUser(int userId)
        {
            using (var context = new BaseContext())
            {
                try
                {
                    var Categories = context.Set<Category>().ToList();

                    var data = new List<ViewModelCategory>();

                    foreach (var _category in Categories)
                    {
                        var _learnedWordCount = context.Set<Learned>().Where(l => l.UserId == userId && l.Word.CategoryId == _category.Id).Count();
                        data.Add(new ViewModelCategory() { Category = _category, TotalWordCount = _category.Words != null ? _category.Words.Count() : 0, LearnedWordCount = _learnedWordCount });
                    } 
                    return new DataResultSuccess<List<ViewModelCategory>>(data, "İşlem Başarıyla Gerçekleşti");
                }
                catch (Exception)
                {
                    return new DataResultError<List<ViewModelCategory>>("İşlem Başarıyla Gerçekleşti");
                }
            }
        }
    }
}
