using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public interface IRolesRepository : IBaseRepository<Roles>
    {
        void InsertRoles(Roles roles);
        void UpdateRoles(Roles roles);
        IEnumerable<Roles> GetAllRoles();
        void DeleteRoles(Roles roles);
        Task<Roles> FindRolesById(Guid id);
    }
}
