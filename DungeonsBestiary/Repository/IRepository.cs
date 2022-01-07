using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsBestiary.Repository
{
    public interface IRepository<T> {

        List<T> GetAll();
        T ReturnId(int id);
        void Insert(T entity);

        void Delete(int id);

        void Update(int id, T entity);

        int NextId();
    }
}
