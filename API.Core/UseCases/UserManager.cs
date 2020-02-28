using API.Core.Interfaces;
using API.Entities.Entities;
using API.Entities.Response;
using API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Core.UseCases
{
    public class UserManager : IDataRepository<User>
    {
        readonly DataContext _employeeContext;

        public UserManager(DataContext context)
        {
            _employeeContext = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _employeeContext.Users.ToList();
        }

        public User Get(string email, string password)
        {
            return _employeeContext.Users.FirstOrDefault(e => e.email == email && e.password == password);
        }

        public int Count(long id)
        {
            return _employeeContext.Users.Where(x => x.id == id).Count();
        }

        public void Add(User entity)
        {
            _employeeContext.Users.Add(entity);
            _employeeContext.SaveChanges();
        }

        public void Update(User user, User entity)
        {
            user.id = user.id;
            user.username = entity.username;
            user.email = entity.email;
            user.password = entity.password;
            _employeeContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Receipt obj = _employeeContext.Receipts.FirstOrDefault(e => e.id == id);
            _employeeContext.Receipts.Remove(obj);
            _employeeContext.SaveChanges();
        }

        public ResponseAPI Validate(User receipt)
        {
            throw new NotImplementedException();
        }

        public User Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}
