using DataAccess.Abstract;
using DataAccess.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EFCoreRepositoryBase<T, TContext> : IRepository<T> 
        where T: class, new()
            where TContext: DbContext, new()
    {
        public IResult Delete(Expression<Func<T, bool>> filter)
        {
            using(var context = new TContext())
            {
                try
                {
                    var entity = context.Set<T>().SingleOrDefault();
                    if(entity == null)
                    { 
                        return new ResultError("Silinmek İstenen Bilgi Bulunamadı.");
                    }
                    context.Remove(entity);
                    context.SaveChanges();
                    return new ResultSuccess("İşlem Başarılı Oldu.");
                }
                catch (Exception)
                { 
                    return new ResultError("İşlem Başarısız Oldu.");
                } 
            }
        }

        public IDataResult<T> Get(Expression<Func<T, bool>> filter)
        {
            using (var context = new TContext())
            {
                try
                {
                    var data = context.Set<T>().SingleOrDefault(filter);
                    if (data == null)
                    {
                        return new DataResultError<T>("Bilgi Bulunamadı.");
                    } 
                    return new DataResultSuccess<T>(data, "İşlem Başarılı Oldu.");
                }
                catch (Exception)
                {
                    return new DataResultError<T>("İşlem Başarısız Oldu.");
                }
            }
        }

        public IDataResult<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                try
                {
                    var data = filter == null ? context.Set<T>().ToList() : context.Set<T>().Where(filter).ToList();
                    if (data == null)
                    {
                        return new DataResultError<List<T>>("Bilgi Bulunamadı.");
                    }
                    return new DataResultSuccess<List<T>>(data, "İşlem Başarılı Oldu.");
                }
                catch (Exception)
                {
                    return new DataResultError<List<T>>("İşlem Başarısız Oldu.");
                }
            }
        }

        public IResult Insert(T entity)
        {
            using (var context = new TContext())
            {
                try
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added; 
                    context.SaveChanges();
                    return new ResultSuccess("İşlem Başarılı Oldu.");
                }
                catch (Exception)
                {
                    return new ResultError("İşlem Başarısız Oldu.");
                }
            }
        }

        public IResult Update(T entity)
        {
            using (var context = new TContext())
            {
                try
                {
                    var updatedEntity = context.Entry(entity);
                    updatedEntity.State = EntityState.Modified;
                    context.SaveChanges();
                    return new ResultSuccess("İşlem Başarılı Oldu.");
                }
                catch (Exception)
                {
                    return new ResultError("İşlem Başarısız Oldu.");
                }
            }
        }
    }
}
