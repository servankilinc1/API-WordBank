using DataAccess.DTO;
using DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ILearningDal
    {
        public IResult InsertLearnedWords(UserLearnedWordsRequest userLearnedWordsRequest);
        public IResult DeleteLearnedWords(UserLearnedWordsRequest userLearnedWordsRequest);
        public IDataResult<List<WordResponse>> GetLearnedWordsForUser(int  userId); 
    }
}
