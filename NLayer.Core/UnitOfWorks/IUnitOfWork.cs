using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.UnitOfWorks
{
    public  interface IUnitOfWork
    {
       //Bu design pattern veritabanına yapılacak işlemlerin tek bir transaction üzerinden yapılabilmesini sağlıyor 
        Task CommitAsync();

        void Commit();

    }
}
