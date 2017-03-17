using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class UserRepository : IDisposable, IRepository
    {
        UserContext db = new UserContext();

        public IEnumerable<User> GetAllUsers()
        {
            return db.Users.Include(u=>u.UserProfile);
        }
        public void Insert(User u)
        {
            db.Users.Add(u);
            db.SaveChanges();
        }
        public User Select(int id)
        {
            return db.Users.Include(u=>u.UserProfile).FirstOrDefault(u=>u.Id == id);
        }
        public void Update(User u)
        {
            db.Entry(u).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(User u)
        {
            db.Users.Remove(u);
            db.SaveChanges();
        }        
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}