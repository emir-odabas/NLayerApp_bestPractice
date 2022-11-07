namespace NLayer.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        //Bu design pattern veritabanına yapılacak işlemlerin tek bir transaction(işlem) üzerinden yapılabilmesini sağlıyor 
        Task CommitAsync();

        void Commit();

    }
}
