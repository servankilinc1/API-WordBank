using DataAccess.DTO;
using DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IFavoriteDal
    {
        public IResult InsertFavorite(UserWordRequest userWordRequest);
        public IResult DeleteFavorite(UserWordRequest userWordRequest);
        public IDataResult<List<WordResponse>> GetFavWordsForUser(int userId);
    }
}
