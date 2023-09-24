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
    public class UserDal:EFCoreRepositoryBase<User, BaseContext>, IUserDal
    {
        public IDataResult<User> Login( UserRequest userRequest)
        {
            using (var context = new BaseContext())
            {
                try
                {
                    var data = context.Set<User>().Where(filter => filter.Email == userRequest.Email && filter.Password == userRequest.Password).FirstOrDefault();
                    if (data != null)
                    { 
                        return new DataResultSuccess<User>(data, "İşlem Başarıyla Gerçekleşti");
                    }
                    return new DataResultError<User>("Kullanıcı Bulunamadı");
                }
                catch (Exception)
                {
                    return new DataResultError<User>("İşlem Başarısız Oldu");
                }
            }
        }
    }
}
