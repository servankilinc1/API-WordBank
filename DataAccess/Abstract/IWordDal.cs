using DataAccess.Concrete;
using DataAccess.Concrete.Context;
using DataAccess.DTO;
using DataAccess.Entity;
using DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IWordDal: IRepository<Word>
    {
        public IDataResult<List<ViewModelWord>> GetAllByCategory(int categoryId, int userId);
    }
}
