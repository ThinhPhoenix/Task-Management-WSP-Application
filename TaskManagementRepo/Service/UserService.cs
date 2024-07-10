using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskManagementRepo.Models;

namespace TaskManagementRepo.Service
{
    internal class UserService : GenericRepo<User> 
    {
        TaskManagementContext _context;
        DbSet<User> _users;

        public UserService()
        {
            _context = new TaskManagementContext();
            _users = _context.Set<User>();
        }
        
        public List<User> GetUser(string username, string password)
        {
            return _context.Users.Where(a=> a.Username == username && a.Password == password).ToList();
        }
    }
}
