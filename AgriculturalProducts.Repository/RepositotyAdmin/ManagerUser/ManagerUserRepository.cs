using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class ManagerUserRepository : BaseRepository<User>, IManagerUserRepository
    {
        private readonly ApplicationContext _applicationContext;
        public ManagerUserRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public List<object> GetListUsersSearchString(string name)
        {
            var data = _applicationContext.Users.Join(_applicationContext.UserInfors, u => u.Id, ui => ui.UserId, (u, ui) => new { u, ui })
                .Where(x => x.u.FirstName + " " + x.u.LastName == name)
                .Select(us => new
                {
                    Id = us.u.Id,
                    Name = us.u.FirstName + " " + us.u.LastName,
                    Email = us.u.Email,
                    Address = us.ui.Address,
                    BirthDay = us.ui.BirthDay,
                    Gender = us.ui.Gender
                }).ToList();
            List<object> users = new List<object>();
            foreach (var item in data)
            {
                users.Add(item);
            }
            return users;
        }

        public List<object> GetListUsers()
        {
            var data = _applicationContext.Users.Join(_applicationContext.UserInfors, u => u.Id, ui => ui.UserId, (u, ui) => new { u, ui }).Select(us => new
            {
                Name = us.u.FirstName + " " + us.u.LastName,
                Email = us.u.Email,
                Address = us.ui.Address,
                BirthDay = us.ui.BirthDay,
                Gender = us.ui.Gender
            }).ToList();
            List<object> users = new List<object>();
            foreach (var item in data)
            {
                users.Add(item);
            }
            return users;
        }
    }
}
