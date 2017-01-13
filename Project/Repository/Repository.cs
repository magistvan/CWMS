using System.Collections.Generic;

namespace Project.Repository
{
    interface IRepository<T>
    {
        List<T> getAll();

        T add(T element);

        void update(T element);

        void delete(T element);

        T getById(int id);

        int GetMaxId();
    }
}
