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
    public interface ICategoryDal: IRepository<Category>
    {
        public IDataResult<List<ViewModelCategory>> GetAllForUser(int userId);
    }
}
