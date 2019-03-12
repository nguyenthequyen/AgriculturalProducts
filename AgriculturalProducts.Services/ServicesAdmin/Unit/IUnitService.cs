using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public interface IUnitService : IBlogsService<Unit>
    {
        void InsertUnit(List<Unit> unit);
        void UpdateUnit(List<Unit> unit);
        IEnumerable<Unit> GetAllUnit();
        void DeleteUnit(List<Unit> unit);
        Task<Unit> FindUnitById(Guid id);
        PageList<Unit> GetUnitPageList(PagingParams pagingParams);
    }
}
