using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public interface IRepository
    {
        IEnumerable<User> GetAllUsers();
        User Select(int id);
        void Insert(User u);
        void Update(User u);
        void Delete(User u);
    }
}
