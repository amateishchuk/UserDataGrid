using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class UserRepository : IDisposable, IRepository<UserProfile>
    {
        UserContext db = new UserContext();

        public IEnumerable<UserProfile> GetAllUsers()
        {
            return db.UserProfiles.Include(u=>u.User);
        }
        public bool IsAvailableLogin(string login)
        {
            return db.Users.Where(u => u.Login == login).Count() > 0 ? false : true;
        }
        public void Add(UserProfile u)
        {
            db.UserProfiles.Add(u);
            db.SaveChanges();
        }
        public UserProfile GetUserById(int id)
        {
            return db.UserProfiles.Include(u=>u.User).FirstOrDefault(u=>u.Id == id);
        }
        public void Edit(UserProfile u)
        {
            db.Entry(u).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(UserProfile u)
        {
            db.UserProfiles.Remove(u);
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