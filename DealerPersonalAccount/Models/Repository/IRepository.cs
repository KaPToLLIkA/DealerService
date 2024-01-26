using DealerPersonalAccount.Models.ViewModels;
using System.Collections.Generic;

namespace DealerPersonalAccount.Models.Repository
{
    public interface IRepository<T>
    {
        void Insert(T entity);

        void Remove(T entity);
        void Remove(int id);

        T Get(int id);
        IEnumerable<T> GetAll();

        IViewModel<T> GetViewModel(int id);
        IEnumerable<IViewModel<T>> GetAllViewModels();
 
        void Update(T entity);
        void Update(int id, T entity);
    }
}
