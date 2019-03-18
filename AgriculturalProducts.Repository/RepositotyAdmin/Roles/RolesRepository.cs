using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public class RolesRepository : BaseRepository<Roles>, IRolesRepository
    {
        private readonly ApplicationContext _applicationContext;
        public RolesRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void DeleteRoles(Roles role)
        {
            Delete(role);
        }

        public async Task<Roles> FindRolesById(Guid id)
        {
            return await GetFirstOrDefault(id);
        }

        public IEnumerable<Roles> GetAllRoles()
        {
            return GetAllRecords();
        }

        public Roles GetRolesClient()
        {
            return _applicationContext.Roles.SingleOrDefault(x => x.Name == "Users");
        }

        public void InsertRoles(Roles role)
        {
            Add(role);
        }

        public void UpdateRoles(Roles role)
        {
            Update(role);
        }
    }
}
