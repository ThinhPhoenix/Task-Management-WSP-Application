using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementRepo.Models;

namespace TaskManagementRepo
{
    internal class GenericRepo<T> where T : class
    {
        TaskManagementContext TMcontext;
        DbSet<T> dbSet;

        public GenericRepo()
        {
            TMcontext = new TaskManagementContext();
            dbSet = TMcontext.Set<T>();
        }

        public void Add(T Entity)
        {
            dbSet.Add(Entity);
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public void Delete(T Entity)
        {
            dbSet.Remove(Entity);
        }

        public void Update(T Entity)
        {
            var tracker = TMcontext.Attach(Entity);
            tracker.State = EntityState.Modified;
            TMcontext.Update(tracker);
        }

    }
}
