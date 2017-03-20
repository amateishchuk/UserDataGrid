using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetAllUsers();
        T GetUserById(int id);
        void Add(T u);
        void Edit(T u);
        void Delete(T u);
        bool IsAvailableLogin(string login);
    }
}
