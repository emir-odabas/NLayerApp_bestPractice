using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        //productRepository.GetAll(x=>x.id>5).ToListAsync();       
        //IQueryable dönen şeyler veri tabanına sorgu atılmaz
        // bunlar((x=>x.id>5) vb..) memoryde birleştirilir ve tek seferde veri tabanına gönderilir.     
        IQueryable<T> GetAll();

        //productRepository.where(x=>x.id>5).OrderBy.ToListAsync();
        //ToListAsync() Dersem veritabanından sorgu yapar
        // IQueryable<T>  önce orderby vb.. yapar en son ToListAsync()       
        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);   //varmı yokmu..

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);   //Birden fazla kaydedilebilmesi için 

        void Update(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

    }
}
