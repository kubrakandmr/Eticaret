using Eticaret.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Eticaret.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);

        List<T> GetList(Expression<Func<T, bool>> filter = null);
        //selectle ilgili hangi sorguyu yazarsam tek tabloda
        //ben expression ımı yazıcam bana veri tabanını generate edip o sorguyu basıcak.
        //yazman gereken sorguları yazmamamı sağlıyacak.

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
